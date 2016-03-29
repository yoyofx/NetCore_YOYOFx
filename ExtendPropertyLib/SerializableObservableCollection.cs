/******************************************************************************
 *  作者：       Maxzhang1985
 *  创建时间：   2012/4/6 16:00:28
 *
 *
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Specialized;

namespace ExtendPropertyLib
{
    [Serializable]
    public class SerializableObservableCollection<T> : ObservableCollection<T>, INotifyPropertyChanged
    {
        [field: NonSerialized]
        public override event NotifyCollectionChangedEventHandler CollectionChanged;

        [field: NonSerialized]
        private PropertyChangedEventHandler _propertyChangedEventHandler;

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                _propertyChangedEventHandler = Delegate.Combine(_propertyChangedEventHandler, value) as PropertyChangedEventHandler;
            }
            remove
            {
                _propertyChangedEventHandler = Delegate.Remove(_propertyChangedEventHandler, value) as PropertyChangedEventHandler;
            }
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            NotifyCollectionChangedEventHandler handler = CollectionChanged;

            if (handler != null)
            {
                handler(this, e);
            }
        }


        public void OnChanged(NotifyCollectionChangedEventArgs e)
        {
            OnCollectionChanged(e);
        }


        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = _propertyChangedEventHandler;

            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
