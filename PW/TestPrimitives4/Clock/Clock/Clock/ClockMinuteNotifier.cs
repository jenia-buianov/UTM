using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{

   public class ClockMinuteNotifier : IObserver<Clock>
    {
        DateTime lastminstart = DateTime.Now;
        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
            throw error;
        }

        public void OnNext(Clock value)
        {
            if(lastminstart.Second == value.Time.Second+1)
            {
                MessageBox.Show("Minute passed " + lastminstart.Minute);
                lastminstart = value.Time;

            }
        }
    }
}
