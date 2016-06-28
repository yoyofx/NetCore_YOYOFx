using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Collections.Concurrent;
using System.Xml.Serialization;
namespace ExtendPropertyLib
{
  
    /// <summary>
    /// 扩展对象基类
    /// </summary>
    [Serializable]
    public class ExtendObject : IDisposable, INotifyPropertyChanged, INotifyChildrenPropertyChanged
    {
        public static T DoCreate<T>() where T:ExtendObject
        {
           T m = (T)Activator.CreateInstance(typeof(T));
           m.OnDoCreate(m, null);
           return m;
        }


      
        /// <summary>
        /// 父对象
        /// </summary>
        [XmlIgnore]
        [field:NonSerialized]
        public virtual object Parent { set; get; }
        protected ConcurrentDictionary<int, object> propertyValues = new ConcurrentDictionary<int, object>();
        protected static ConcurrentDictionary<string, Type> childrenTypes = new ConcurrentDictionary<string, Type>();
        private List<object> objects =new List<object>(5);
        private Type OwnerType = null;
        /// <summary>
        /// 载入函数
        /// </summary>
        public virtual void OnLoad(){}
        
        /// <summary>
        /// 对象初始化函数，对象被创建时，这个函数将被调用
        /// </summary>
        /// <param name="item">扩展对象</param>
        /// <param name="args">参数</param>
        public virtual void OnDoCreate(ExtendObject item,params object[] args)
        {
            OwnerType = this.GetType();
            var plist = ExtendPropertysProvider.GetByType(OwnerType).ToList();
            if(plist.Count<=0)
                plist = ExtendPropertysProvider.GetByType(OwnerType.BaseType).ToList();

            var types = plist.Where(p=>childrenTypes.Values.Any(cp => cp == p.PropertyType)).ToDictionary(m=>m.PropertyName,e=>e.PropertyType);
            foreach (var children in types)
            {
                var info = OwnerType.GetProperty(children.Key);
                if (info != null)
                {
                    var childObj = info.GetValue(this, null) as ExtendObject;
                    if (childObj != null)
                    {
                        objects.Add(childObj);
                        childObj.ChildrenPropertyChanged -=
                            new EventHandler<ExtendPropertyValueChangedArgs>(exObject_ChildrenPropertyChanged);
                        childObj.ChildrenPropertyChanged +=
                            new EventHandler<ExtendPropertyValueChangedArgs>(exObject_ChildrenPropertyChanged);
                    }
                }
                var childObjPropertyInfoList = ExtendPropertysProvider.GetByType(children.Value);
                foreach (var extendProperty in childObjPropertyInfoList)
                {
                    extendProperty.ValueChanged -=
                       new EventHandler<ExtendPropertyValueChangedArgs>(exObject_ChildrenPropertyChanged);

                    extendProperty.ValueChanged +=
                      new EventHandler<ExtendPropertyValueChangedArgs>(exObject_ChildrenPropertyChanged);

                }
            }
        }


        public ExtendObject()
        {
            OwnerType = this.GetType();
        }

        void exObject_ChildrenPropertyChanged(object sender, ExtendPropertyValueChangedArgs e)
        {   
            if(sender!=null)
                OnChildrenPropertyChanged(e);
        }

        ~ExtendObject()
        {
           
            this.Dispose();
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public virtual object GetOwner()
        {
            return this;
        }

        protected  void AttachOwner(Type ownerType)
        {
            this.OwnerType = ownerType;
        }

        public bool IsExtendProperty(string propertyName)
        {
            return !OwnerType.GetProperties().Any(p => p.Name == propertyName); ;
        }


        protected  static ExtendProperty RegisterProperty<TType>(Expression<Func<TType, object>> propertyNameExpression, ObjectRelations relaion = ObjectRelations.Normal)
        {
            PropertyInfo property =null;
            var member = propertyNameExpression.Body as MemberExpression;
            if (member == null)
            {
                var m = propertyNameExpression.Body as UnaryExpression;
                member = m.Operand as MemberExpression;
            }
           

            property = member.Member as PropertyInfo;
           

            if (relaion == ObjectRelations.Children)
            {
                childrenTypes.TryAdd(property.Name + "," + property.PropertyType.Name, property.PropertyType);
            }
            object defvalue = null; 
            if(property.PropertyType.IsValueType)
                defvalue = Activator.CreateInstance(property.PropertyType);
            
            return ExtendProperty.RegisterProperty(property.Name, property.PropertyType, typeof(TType),defvalue,null);
        }

        protected  ExtendProperty GetProperty(string name)
        {
            int propertyKey = OwnerType.GetHashCode() ^ name.GetHashCode();
            var property = ExtendPropertysProvider.Get(propertyKey);
            return property;
        }

        public  object GetValue(ExtendProperty property)
        {
            int propertyHash = property.GetHashCode();
            int key = this.GetHashCode() ^ propertyHash;

            object result = null;
            if (!propertyValues.TryGetValue(key, out result))
            {
                result = property.GetDefaultValue(this.OwnerType);
                if (result == null)
                    result = property.DefaultValue;
            }
         
            return result;
        }

        public bool ClearValue(ExtendProperty property)
        {
            bool result = false;
            int propertyHash = property.GetHashCode();
            int key = this.GetHashCode() ^ propertyHash;

            if (propertyValues.Keys.Any(k => k == key))
            {
                object outObj = null;
                propertyValues.TryRemove(key,out outObj);
                result = true;
            }
            return result;
        }

        public virtual void SetValue(ExtendProperty property, object value)
        {
            var changingItemArgs = 
                        new ExtendPropertyValueChangingArgs() { 
                            Value = value, 
                            Item = GetOwner(), 
                            PropertyType = property.PropertyType, 
                            PropertyName = property.PropertyName , 
                            Cancel = false };

            property.OnValueChanging(changingItemArgs);

            if (!changingItemArgs.Cancel)
            {
                var changedItemArgs = new ExtendPropertyValueChangedArgs();

                int propertyHash = property.GetHashCode();
                int key = this.GetHashCode() ^ propertyHash;

                if (propertyValues.Keys.Any(k => k == key))
                {
                    changedItemArgs.OldValue = propertyValues[key];
                    propertyValues[key] = value;
                }
                else
                {
                    changedItemArgs.OldValue = null;
                    propertyValues.TryAdd(key, value);
                }

                changedItemArgs.Item = GetOwner();
                changedItemArgs.PropertyType = property.PropertyType;
                changedItemArgs.PropertyName = property.PropertyName;
                changedItemArgs.NewValue = value;
                changedItemArgs.PropertyInfo = property;

                property.OnValueChanged(changedItemArgs);
                OnPropertyChanged(property);
                //OnChildrenPropertyChanged(changedItemArgs);
            }
        }

        public bool ClearValue(string propertyName)
        {
            var property = this.GetProperty(propertyName);
            if (property != null)
                return this.ClearValue(property);

            return false;
        }

        public object GetValue(string propertyName)
        {
            var property = this.GetProperty(propertyName);
            if (property != null)
                return this.GetValue(property);

            return null;
        }

        public void SetValue(string propertyName, object value)
        {
            var property = this.GetProperty(propertyName);

            if (property != null)
            {
                this.SetValue(property, value);
            }
            else
            {
                var newProperty = ExtendProperty.RegisterProperty(propertyName, typeof(object), OwnerType);
                this.SetValue(newProperty, value);
            }
        }

        public ExtendDynamicObject AsDynamic()
        {
            return new ExtendDynamicObject(this);
        }

        #region Interface
        
        public void Dispose()
        {
            if (this.propertyValues!=null)
                this.propertyValues.Clear();
            this.propertyValues = null;
            foreach (var childrenType in childrenTypes)
            {
                var exPropertyInfoList = ExtendPropertysProvider.GetByType(childrenType.Value);
                foreach (var extendProperty in exPropertyInfoList)
                {
                    extendProperty.ValueChanged -= new EventHandler<ExtendPropertyValueChangedArgs>(exObject_ChildrenPropertyChanged);
                }
            }

            if(objects!=null)
            foreach (var o in objects)
            {
               var obj=o as ExtendObject;
               obj.ChildrenPropertyChanged-= new EventHandler<ExtendPropertyValueChangedArgs>(exObject_ChildrenPropertyChanged);
            }
        }

        protected virtual void OnPropertyChanged(ExtendProperty property)
        {
            RaisePropertyChanged(property.PropertyName);
        }

        protected virtual void OnChildrenPropertyChanged(ExtendPropertyValueChangedArgs args)
        {
            if (this.ChildrenPropertyChanged != null)
            {
                this.ChildrenPropertyChanged(this,args);
            }
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        
        }

        [field: NonSerialized]
        public virtual event PropertyChangedEventHandler PropertyChanged;
        [field: NonSerialized]
        public event EventHandler<ExtendPropertyValueChangedArgs> ChildrenPropertyChanged;
        #endregion



    }
}
