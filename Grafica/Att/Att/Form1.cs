using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Att
{
    public partial class Form1 : Form
    {
        private int X = 150;
        private int Y = 250;
        private int angle = 0;
        private bool rot = false;
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TEXT");
            if (!rot)
            {
                rot = true;
                rotate();
            }
        }

     

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(Pens.White, new Rectangle(200, 150, 150, 250));
            e.Graphics.DrawLine(Pens.Black, new Point(230, 185), new Point(290, 185));

            e.Graphics.DrawLine(Pens.Black, new Point(230, 185), new Point(265, 285));

            e.Graphics.DrawLine(Pens.Black, new Point(290, 185), new Point(320, 285));
            e.Graphics.DrawLine(Pens.Black, new Point(265, 285), new Point(320, 285));
        }

        async Task rotate()
        {
            Graphics g = this.CreateGraphics();
            if (angle < 360) angle += 30;
            else
            {
                angle = 0;
                this.Refresh();
                rot = false;
                return;
            }
            this.Refresh();
            PointF rotatePoint = new PointF(0, 0);
            //g.TranslateTransform(X,Y);
            g.RotateTransform(angle);
            g.DrawEllipse(Pens.White, new Rectangle(200, 150, 150, 250));

            //this.Invalidate();
            await Task.Delay(500);
            rotate();
        }

    }
}
