using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    /// <summary>
    ////Поставщик
    /// </summary>
    public class ClockEvent : IObservable<Clock>
    {
        List<IObserver<Clock>> observers = new List<IObserver<Clock>>();
        public IDisposable Subscribe(IObserver<Clock> observer)
        {
            observers.Add(observer);
            return null;
        }
        public void Action(Clock value)
        {
            foreach (IObserver<Clock> observer in observers)
                observer.OnNext(value);
        }
    }
}
