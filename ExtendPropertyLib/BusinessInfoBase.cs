using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using System.Collections.Specialized;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
namespace ExtendPropertyLib
{
    /// <summary>
    /// 业务对象基类
    /// 用于业务数据的绑定与验证功能
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class BusinessInfoBase<T> : ExtendObject, IBusinessObject,
                        IDataErrorInfo, IEditableObject, IUndoObject ,IDisposable where T : ExtendObject
    {
        public BusinessInfoBase():base()
        {
            this.AddValidationRules();
        }

        ~BusinessInfoBase()
        {
            Clear();
        }

        protected static ExtendProperty RegisterProperty(Expression<Func<T, object>> propertyNameExpression,ObjectRelations relaion = ObjectRelations.Normal)
        {
            return RegisterProperty<T>(propertyNameExpression, relaion);
        }
     
      
     

        #region IDataErrorInfo 接口实现

        [XmlIgnore]
        public virtual string Error {private set; get; }
        [XmlIgnore]
        public virtual string this[string propertyName]
        {
            get
            {
                string result = null;
                var func = ValiationRules.Get(propertyName);
              
                if (func != null)
                {
                    result = func();
                
                    Error = result;
                   

                }
             
                return result;
            }
        }
        #endregion



        #region IEditableObject 成员

        [NonSerialized]
        private bool _inTx;

        public void BeginEdit()
        {
            if (!_inTx)
            {
                Backup();
                _inTx = true;
            }
        }

        public void CancelEdit()
        {
            if (_inTx)
            {
                Restore();
                _inTx = false;
            }
        }

        public void EndEdit()
        {
            if (_inTx)
            {
                if (____backup != null)
                {
                    ____backup.Clear();
                    ____backup = null;
                }
                _inTx = false;
            }
        }


        #region Backup and Restore Data

        Stack<byte[]> ____backup;
        protected virtual void Backup()
        {
            if (____backup == null)
            {
                ____backup = new Stack<byte[]>();
            }
            Type sourceType = this.GetType();
            HybridDictionary state = new HybridDictionary();
              
            ExtendProperty[] propertys;
            
            // 获取所有字段信息。
            propertys = ExtendPropertysProvider.GetByType(this.GetType());

            foreach (ExtendProperty property in propertys)
            {


                object value = this.GetValue(property);
                if (typeof(IBusinessObject).IsAssignableFrom(property.PropertyType))
                {
                    if (value == null)
                    {
                        //值为空，我们也要保存。
                        state.Add(property.GetHashCode(), null);
                    }
                    else
                    {
                        // 不为空，而且是同一类型，则同时调用Backup方法。
                        ((IUndoObject)value).Accept();
                    }
                }
                //检查字段类型是否为ICollection，以便为集合中的项进行备份。
                else if (typeof(ICollection).IsAssignableFrom(property.PropertyType) && value != null && ((ICollection)value).Count > 0)
                {
                    var col = (ICollection)value;
                    foreach (var item in col)
                    {
                        if (item is IUndoObject)
                            ((IUndoObject)item).Accept();
                    }
                     
                    state.Add(property.GetHashCode(), value);
                }
                else
                {
                    //普通字段，加入字典。
                    state.Add(property.GetHashCode(), value);
                }
 
            }
             
 
            //序列化，推上栈。
            using (MemoryStream buffer = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
            
                formatter.Serialize(buffer, state);
                ____backup.Push(buffer.ToArray());
            }
 
            
        }

        protected virtual void Restore()
        {
            // 如果没有备份数据，则忽略此调用。
            if (____backup != null && ____backup.Count > 0)
            {
                //反序列化得到字典。
                HybridDictionary state;
                using (MemoryStream buffer = new MemoryStream(____backup.Pop()))
                {
                    buffer.Position = 0;
                    BinaryFormatter formatter = new BinaryFormatter();
                    try
                    {
                        state = (HybridDictionary)formatter.Deserialize(buffer);
                    }
                    catch
                    {
                        return;
                    }
                }

                object source = this;
                Type sourceType = source.GetType();
                ExtendProperty[] propertys;

                // 获取所有字段信息。
                propertys = ExtendPropertysProvider.GetByType(this.GetType());


                foreach (ExtendProperty property in propertys)
                {
            
                        //获取新值。
                    object value = this.GetValue(property);

                    if (typeof(IBusinessObject).IsAssignableFrom(property.PropertyType))
                    {
                        //这是个子对象，检查只是否为空。
                        if (state.Contains(property.GetHashCode()))
                        {
                            //原来为空，设置为空。
                            this.SetValue(property, null);
                        }
                        else
                        {
                            if (value != null)
                            {
                                // 子对象调用Restore方法。
                                ((IUndoObject)value).Undo();
                            }
                        }
                    }
                    //如果字典包含该字段，则还原。
                    else if (state.Contains(property.GetHashCode()))
                    {
                        this.SetValue(property, state[property.GetHashCode()]);
                    }

                        //检查值是否为集合，如果是，就对每项调用Restore方法。
                    var oldValue = state[property.GetHashCode()];
                    if (oldValue != null && oldValue is ICollection)
                    {
                        var col = (ICollection)oldValue;
                        foreach (var item in col)
                        {
                            if (item is IUndoObject)
                                ((IUndoObject)item).Undo();
                        }
                    }

                    
                }
            

                
            }
        }

        #endregion


        #endregion


        #region 多级撤销接口

        /// <summary>
        /// 撤消对象状态
        /// </summary>
        public void Undo()
        {
            Restore();
        }

        /// <summary>
        /// 接受对象当前状态
        /// </summary>
        public void Accept()
        {
            Backup();
        }

        /// <summary>
        /// 撤消层级
        /// </summary>
        public int UndoLevel
        {
            get { return ____backup == null ? 0 : ____backup.Count; }
        }

        /// <summary>
        /// 清除所有可撤销状态
        /// </summary>
        public void Clear()
        {
            if (____backup != null)
            {
                ____backup.Clear();
                ____backup = null;
            }
        }


        #endregion

        #region 验证接口
        /// <summary>
        /// 验证规则对象
        /// </summary>
        protected ValiationRules ValiationRules = new ValiationRules();

        /// <summary>
        /// 验证对象是否有效
        /// </summary>
        [XmlIgnore]
        public virtual bool IsValid
        {
            get
            {
                return ValiationRules.isVailate;
            }
        }

        /// <summary>
        /// 添加验证规则入口，通过ValiationRules对象。
        /// </summary>
        protected virtual void AddValidationRules()
        {

        }
        #endregion




     
    }
}
