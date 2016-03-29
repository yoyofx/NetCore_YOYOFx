using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Reflection;
using ExtendPropertyLib;
using System.Collections.Concurrent;
namespace ExtendPropertyLib
{
    public class ExtendPropertyValueChangedArgs : EventArgs
    {
        public Type PropertyType { set; get; }
        public object Item { set; get; }
        public string PropertyName { set; get; }
        public object NewValue { set; get; }
        public object OldValue { set; get; }
        public ExtendProperty PropertyInfo { set; get; }
    }

    public class ExtendPropertyValueChangingArgs : EventArgs
    {
        public Type PropertyType { set; get; }
        public object Item { set; get; }
        public string PropertyName { set; get; }
        public object Value { set; get; }
        public bool Cancel { set; get; }
    }


    
    public class ExtendProperty 
    {
        internal ExtendProperty(string propertyName, Type propertyType, Type ownerType) 
        {
            this.PropertyName = propertyName;
            this.PropertyType = propertyType;
            this.OwnerType = ownerType;
        }

        #region Propertys
        public Type OwnerType { private set; get; }

        public string PropertyName { private set; get; }

        public Type PropertyType { private set; get; }

        public MetaData MetaData { set; get; }


        public override int GetHashCode()
        {
            return this.OwnerType.GetHashCode() ^ this.PropertyName.GetHashCode();
        }

        public object DefaultValue { 
            get 
            {
                return GetDefaultValue(this.OwnerType);
            } 
        }

        private ConcurrentDictionary<Type, object> defaultValues = new ConcurrentDictionary<Type, object>();
        [field: NonSerialized]
        public event EventHandler<ExtendPropertyValueChangedArgs> ValueChanged;
        [field: NonSerialized]
        public event EventHandler<ExtendPropertyValueChangingArgs> ValueChanging;

        public void OnValueChanged(ExtendPropertyValueChangedArgs args)
        {
            if (ValueChanged != null)
                ValueChanged(this, args);
        }

        public void OnValueChanging(ExtendPropertyValueChangingArgs args)
        {
            if (ValueChanging != null)
                ValueChanging(this, args);
        }


        public void OverrideDefaultValue(Type ownerType, object defaultValue)
        {
            this.defaultValues.TryAdd(ownerType, defaultValue);
        }

        public object GetDefaultValue(Type ownerType)
        {
            object result = null;
            this.defaultValues.TryGetValue(ownerType, out result);
            return result;
        }

        #endregion

        public static ExtendProperty RegisterProperty(string propertyName, Type propertyType, Type ownerType,object defaultValue,MetaData metaData)
        {
            var property = new ExtendProperty(propertyName, propertyType, ownerType);
            property.OverrideDefaultValue(ownerType, defaultValue);
            property.MetaData = metaData;
            ExtendPropertysProvider.Set(property.GetHashCode(), property);

            return property;
        }

        public static ExtendProperty GetProperty(Type ownerType, string propertyName)
        {
            int propertyKey = ownerType.GetHashCode() ^ propertyName.GetHashCode();
            var property = ExtendPropertysProvider.Get(propertyKey);
            property.OwnerType = ownerType;
            return property;
        }

        public static ExtendProperty[] GetPropertys(Type ownerType)
        {

            return ExtendPropertysProvider.GetByType(ownerType);
            //return ownerType.GetFields
            //    (BindingFlags.Static | BindingFlags.Public)
            //    .Where(f => f.FieldType == typeof(ExtendProperty))
            //    .Select(f => (ExtendProperty)f.GetValue(null)).ToArray();
        }



        public static ExtendProperty RegisterProperty(string propertyName, Type ownerType, object defaultValue)
        {
            return RegisterProperty(propertyName, typeof(object), ownerType, defaultValue,null);
        }

        public static ExtendProperty RegisterProperty(string propertyName, Type propertyType, Type ownerType)
        {
            return RegisterProperty(propertyName, propertyType, ownerType, null,null);
        }

        public static ExtendProperty RegisterProperty(string propertyName, Type propertyType, Type ownerType,MetaData metaData)
        {
            return RegisterProperty(propertyName, propertyType, ownerType, null, metaData);
        }

        public ExtendProperty AddOwner(Type ownerType,object defaultValue)
        {
            int newOwnerHash = ownerType.GetHashCode() ^ this.PropertyName.GetHashCode();
            if(defaultValue!=null)
                this.OverrideDefaultValue(ownerType, defaultValue);
            ExtendPropertysProvider.Set(newOwnerHash, this);
            return this;
        }



        public ExtendProperty AddOwner(Type ownerType)
        {
            return this.AddOwner(ownerType, null);
        }


    }


 

   

  

   

}
