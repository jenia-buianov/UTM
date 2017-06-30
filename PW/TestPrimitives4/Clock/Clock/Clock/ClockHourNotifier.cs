using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    /// <summary>
    /// наблюдатель
    /// </summary>
   public class ClockHourNotifier:IObserver<Clock>
    {
        DateTime lasthourstart = DateTime.Now;
        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
            throw error;
        }

        public void OnNext(Clock value)
        {
            if (lasthourstart.Minute == value.Time.Minute + 1)
            {
                MessageBox.Show("Minute passed " + lasthourstart.Hour);
                lasthourstart = value.Time;

            }
        }
    }
}
