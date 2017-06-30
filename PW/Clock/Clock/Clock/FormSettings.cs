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
    //здесь все так запутанно потому что я сначала написал а потом вспомнил про декоратор!!! DONT WORK!!!!
    public partial class FormSettings : Form
    {
        public FormSettings(IClockBase clock)
        {
            InitializeComponent();
            this.clock = (Clock)clock;
            dateTimePicker.Value = this.clock.Time;
        }
        
        Clock clock;
        private void buttonOK_Click(object sender, EventArgs e)
        {

            Settings.Set(radioButtonClockFace.Checked,clock.Location, clock.DrawingSize, clock.ParentForm, c =>
                 {
                     c.Time = this.dateTimePicker.Value;
                     TimeSpan hh = TimeSpan.Parse(textBoxOffset.Text);
                     c.Offset = hh;
                     return c;
                 });           
            
            Close();
        }
    }
}
