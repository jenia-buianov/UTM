using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace an              //5 9 6 4 8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            this.Paint += new PaintEventHandler(Form1_Paint);
        }
        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {





             e.Graphics.DrawRectangle(Pens.Black, new Rectangle(0, 0, 300, 300));
             e.Graphics.DrawRectangle(Pens.Black, 0, 0, 100, 100);
             e.Graphics.DrawRectangle(Pens.Black, 100, 100, 100, 100);
             e.Graphics.DrawRectangle(Pens.Black, 200, 200, 100, 100);
             e.Graphics.DrawRectangle(Pens.Black, 100, 0, 100, 100);
             e.Graphics.DrawRectangle(Pens.Black, 0, 100, 100, 100);
             e.Graphics.DrawRectangle(Pens.Black, 200, 0, 100, 100);
             e.Graphics.DrawRectangle(Pens.Black, 0, 200, 100, 100);


             e.Graphics.DrawRectangle(Pens.Black, 20, 110, 60, 80);
             e.Graphics.FillRectangle(Brushes.LightSeaGreen, 21, 111, 60, 80);

             Point[] tria = {                       //Triangle
                new Point(50, 20),
                new Point(20, 80),
                new Point(80, 80)
            };
             e.Graphics.DrawPolygon(Pens.Black, tria);
             e.Graphics.FillPolygon(Brushes.Indigo, tria);
             Point[] paral = {                       //Parallelipiped
                new Point(110, 40),
                new Point(170, 40),
                new Point(170, 80),
                new Point(110, 80),
                new Point(110, 40),
                new Point(130, 20),
                new Point(190, 20),
                new Point(190, 60),
                new Point(170, 80),
                new Point(170, 40),
                new Point(190, 20),
                new Point(170, 40),
                
            };
             e.Graphics.DrawPolygon(Pens.Aqua, paral);
             e.Graphics.FillPolygon(Brushes.Green, paral);
             e.Graphics.DrawPolygon(Pens.Black, paral);
             SolidBrush solidBrush = new SolidBrush(Color.FromArgb(81, 124, 255, 0));
             Point[] pts = {                // Polygon
                new Point( 250,  20),
                new Point(291,  40),
                new Point(291, 65),
                new Point(250, 85),
                new Point(209, 65),
                new Point(209, 40),
       
            };

            e.Graphics.DrawPolygon(Pens.Black, pts);
            

            e.Graphics.DrawEllipse(Pens.Black, new Rectangle(105, 115, 90, 70)); // Part of Ellipse
            e.Graphics.DrawLine(Pens.Black, 150, 150, 145, 115);
            e.Graphics.DrawLine(Pens.Black, 150, 150, 190, 135);
            e.Graphics.FillPie(Brushes.Red, new Rectangle(105, 115, 90, 70), 260, 79);

            e.Graphics.DrawEllipse(Pens.Black, new Rectangle(205, 115, 90, 70)); //Ellipse

            e.Graphics.DrawEllipse(Pens.Black, new Rectangle(5, 205, 90, 90)); // Circle



            e.Graphics.DrawEllipse(Pens.Black, new Rectangle(105, 205, 90, 90));  // Part of Circle
            e.Graphics.FillPie(Brushes.White, new Rectangle(105, 205, 90, 90), 260, 130);

            e.Graphics.DrawLine(Pens.Orange, 205, 210, 285, 285); //Line
        }
      
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
