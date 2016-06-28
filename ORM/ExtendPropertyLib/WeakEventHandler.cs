using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtendPropertyLib
{
    /*  Demo
     * 
     *  private WeakEventHandler<EventArgs> _event = new WeakEventHandler<EventArgs>();

        public event EventHandler<EventArgs> Event
        {
            add { _event.Target += value; }
            remove { _event.Target -= value; }
        }

        public void FireEvent()
        {
            if (_event.Target != null)
            {
                _event.Target(this, EventArgs.Empty);
            }
        }
     * 
     */


    public class WeakEventHandler<T> : WeakReference where T : EventArgs
    {
        public WeakEventHandler() : base(null) { }

        public WeakEventHandler(EventHandler<T> handler) : base(handler) { }

        public WeakEventHandler(EventHandler<T> target, bool trackResurrection) : base(target, trackResurrection) { }

        public new EventHandler<T> Target
        {
            get
            {
                return (EventHandler<T>)base.Target;
            }
            set
            {
               if(value!=null)
                    base.Target = value;
            
            }
        }

        public static explicit operator EventHandler<T>(WeakEventHandler<T> weakEventHandler)
        {
            return weakEventHandler.Target;
        }
    }
}
