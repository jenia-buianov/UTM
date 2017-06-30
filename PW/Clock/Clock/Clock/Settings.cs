using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public class Settings
    {
        static IClockBase objectstate = null;

        public static IClockBase ObjectState
        {
            get
            {
                return objectstate;
            }

            set
            {
                objectstate = value;
            }
        }
        public static bool IsClockFace { get; set; }
        public static void Set(bool isClockFace,Point location, Size size, Form form, Func<Clock,Clock> func)
        {
            IsClockFace = isClockFace;
            Clock basestate = new Clock(location, size, form);
            objectstate = func(basestate);

        }
    }
}
