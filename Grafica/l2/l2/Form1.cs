using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace l2
{
    public partial class Form1 : Form
    {
        private float scale = 2.2F;
        private int sizeX = 30;
        private int sizeY = 40;
        private int angle = 0;
        private bool rot = false;
        Timer timer;
        
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            Form myform = new Form();

            myform.Text = "Main Window";
            myform.Size = new Size(1284, 712);
            myform.FormBorderStyle = FormBorderStyle.FixedDialog;
            myform.StartPosition = FormStartPosition.CenterScreen;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            var loc = oval.Location;
            var size = oval.Size;
            if (rot && e.KeyCode != Keys.R)
            {
                return;
            }
            if (e.KeyCode == Keys.Up) loc.Y -= 10;
            if (e.KeyCode == Keys.Down) loc.Y += 10;
            if (e.KeyCode == Keys.Left) loc.X -= 10;
            if (e.KeyCode == Keys.Right) loc.X += 10;
            if (e.KeyCode == Keys.P)
            {
                size.Width = Convert.ToInt32(size.Width * scale);
                size.Height = Convert.ToInt32(size.Height * scale);
                
            }
            else if (e.KeyCode == Keys.L)
            {
                size.Width = Convert.ToInt32(size.Width / scale);
                size.Height = Convert.ToInt32(size.Height / scale);
            }
            if (e.KeyCode == Keys.R)
            {
                if (!rot)
                {
                    rot = true;
                    rotate(loc.X,loc.Y);
                    oval.Visible = false;
                }
                else
                {

                    this.Refresh();
                    oval.Visible = true;
                    rot = false;
                }
            }
            oval.Location = loc;
            oval.Size = size;
        }

        async Task rotate(int X,int Y)
        {
            Graphics g = this.CreateGraphics();
            if (angle < 360) angle += 30;
            else
            {
                oval.Visible = true;
                rot = false;
                angle = 0;
                this.Refresh();
                return;
            }
            this.Refresh();
            PointF rotatePoint = new PointF(0, 0);
            var size = oval.Size;

            // Create a matrix and rotate it 45 degrees.
            g.TranslateTransform(0 + X, 0 + Y);
            g.RotateTransform(angle);
            g.DrawEllipse(Pens.Red, new Rectangle(0, 0, size.Width, size.Height));
            SolidBrush redColor = new SolidBrush(Color.Red);
            g.FillEllipse(redColor, new Rectangle(0, 0, size.Width, size.Height));

            var loc = oval.Location;
            loc.X = X;
            loc.Y = Y;
            oval.Location = loc;
            
            await Task.Delay(1000);
            rotate(X,Y); 
        }

        private void rect_Click(object sender, EventArgs e)
        {

        }

        private void lineShape2_Click(object sender, EventArgs e)
        {

        }


    }
}
