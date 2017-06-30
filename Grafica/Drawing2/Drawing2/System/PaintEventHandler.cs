using System.Windows.Forms;

namespace System
{
    internal class PaintEventHandler
    {
        private Action<object, PaintEventArgs> form1_Paint;

        public PaintEventHandler(Action<object, PaintEventArgs> form1_Paint)
        {
            this.form1_Paint = form1_Paint;
        }
    }
}