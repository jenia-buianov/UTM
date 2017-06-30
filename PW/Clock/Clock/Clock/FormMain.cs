using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            timer.Interval = 100;
        }
        IClockBase clock;

        private void FormMain_Load(object sender, EventArgs e)
        {
            clock = new Clock(new Point(0, 0), Size, this);
            ((Clock)clock).TimeChanged.Subscribe(new ClockMinuteNotifier());
            ((Clock)clock).TimeChanged.Subscribe(new ClockHourNotifier());
            clock.Show();
            timer.Start();
        }

        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            clock.Show();
        }
        private void buttonSettings_Click(object sender, EventArgs e)
        {

            FormSettings set = new FormSettings(clock.Clone);
            set.FormClosed += new FormClosedEventHandler(SetClocks);
            set.Show();

        }
        private void SetClocks(object sender,EventArgs e)
        {
            if(Settings.IsClockFace)
            {
                clock = new ClockWithArrows(Settings.ObjectState);
            }
            else
            {
                clock = Settings.ObjectState;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            clock.Update();
            clock.Show();
            //Invalidate();
        }
    }
}
