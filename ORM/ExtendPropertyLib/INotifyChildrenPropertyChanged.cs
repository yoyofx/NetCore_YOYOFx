using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtendPropertyLib
{
    public interface INotifyChildrenPropertyChanged
    {
        event EventHandler<ExtendPropertyValueChangedArgs> ChildrenPropertyChanged;
    }
}
