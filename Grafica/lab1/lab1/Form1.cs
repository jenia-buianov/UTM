using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
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

               e.Graphics.DrawRectangle(Pens.Black, 220, 10, 60, 80); //Rectangle

               e.Graphics.DrawLine(Pens.Black, 10, 150, 90, 150); // Line

               Point[] pts = {                // Polygon
                new Point( 250,  110),
                new Point(291,  139),
                new Point(291, 165),
                new Point(250, 194),
                new Point(209, 165),
                new Point(209, 139),
       
            };

               e.Graphics.DrawPolygon(Pens.Black, pts);
               e.Graphics.FillPolygon(Brushes.Green, pts);

               e.Graphics.DrawEllipse(Pens.Black, new Rectangle(105, 105, 90, 90)); // Circle

               e.Graphics.DrawEllipse(Pens.Black, new Rectangle(205, 215, 90, 70));    //Ellipse

               e.Graphics.DrawEllipse(Pens.Black, new Rectangle(5, 205, 90, 90));  // Part of Circle
               e.Graphics.DrawLine(Pens.Black, 45, 205, 50, 250);
               e.Graphics.DrawLine(Pens.Black, 50, 250, 91, 270);
               e.Graphics.FillPie(Brushes.Yellow, new Rectangle(5, 205, 90, 90), 260, 130);

               e.Graphics.DrawEllipse(Pens.Black, new Rectangle(105, 15, 90, 70)); // Part of Ellipse
               e.Graphics.DrawLine(Pens.Black, 150, 50, 145, 15);
               e.Graphics.DrawLine(Pens.Black, 150, 50, 190, 35);
               e.Graphics.FillPie(Brushes.Blue, new Rectangle(105, 15, 90, 70), 260, 79);

               Point[] tria = {                       //Triangle
                new Point(150, 215),
                new Point(120, 285),
                new Point(180, 285)
            };
               e.Graphics.DrawPolygon(Pens.Black, tria);

               Point[] paral = {                       //Parallelipiped
                new Point(10, 40),
                new Point(70, 40),
                new Point(70, 80),
                new Point(10, 80),
                new Point(10, 40),
                new Point(30, 20),
                new Point(90, 20),
                new Point(90, 60),
                new Point(70, 80),
                new Point(70, 40),
                new Point(90, 20),
                new Point(70, 40),
                
            };
               e.Graphics.DrawPolygon(Pens.Azure, paral);
               e.Graphics.FillPolygon(Brushes.Coral, paral);
               //e.Graphics.DrawLine(Pens.Brown, 10, 40, 70, 40);
               //e.Graphics.DrawLine(Pens.Brown, 70, 40, 70, 80);
               //e.Graphics.DrawLine(Pens.Brown, 70, 40, 90, 20);
               Point[] parall = {                       //Parallelipiped
                new Point(10, 40),
                new Point(70, 40),
                new Point(70, 80),
                new Point(10, 80),
                new Point(10, 40),
                new Point(30, 20),
                new Point(90, 20),
                new Point(90, 60),
                new Point(70, 80),
                new Point(70, 40),
                new Point(90, 20),
                new Point(70, 40),
                
            };
               e.Graphics.DrawPolygon(Pens.Black, parall);
               SolidBrush solidBrush = new SolidBrush(Color.FromArgb(255, 255, 0, 0));
               e.Graphics.FillEllipse(solidBrush, 105, 105, 90, 90);





          }

          private void timer1_Tick(object sender, EventArgs e)
          {
               this.Refresh();
          }
     }
}
