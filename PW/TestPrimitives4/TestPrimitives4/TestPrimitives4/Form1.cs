using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TestPrimitives4
{
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();
        }

        private void ALL(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Red, 5);

            e.Graphics.DrawEllipse(pen, 200, 130, 10, 10);

            e.Graphics.DrawEllipse(pen, 180, 110, 50, 50);

            e.Graphics.DrawEllipse(pen, 470, 130, 50, 50);

            e.Graphics.DrawEllipse(pen, 460, 120, 70, 70);

            e.Graphics.DrawEllipse(pen, 450, 110, 90, 90);

            e.Graphics.DrawEllipse(pen, 440, 100, 110, 110);



            //lines
            //e.Graphics.DrawLine(pen, 50, 22, 400, 400);

            //e.Graphics.DrawLine(pen, 80, 20, 20, 30);

            pen.Dispose();

            //ex

           

            // Create pen.
            Pen blackPen = new Pen(Color.Gold, 15);
            /*
            Graphics g = this.CreateGraphics();
            SolidBrush myBrush = new SolidBrush(Color.Green);
            g.FillEllipse(myBrush, ClientRectangle);
            */



            // Create points that define polygon.
            Point point1 = new Point(60, 50);
            Point point2 = new Point(100, 25);
            Point point3 = new Point(200, 5);
            Point point4 = new Point(250, 50);
            Point point5 = new Point(280, 100);
            Point point6 = new Point(350, 200);
            Point point7 = new Point(250, 250);
            Point point8 = new Point(250, 350);
            Point[] curvePoints =
                     {
                 point1,
                 point2,
                 point3,
                 point4,
                 point5,
                 point6,
                 point7,
                 point8
             };

            // Draw polygon to screen.
            e.Graphics.DrawPolygon(blackPen, curvePoints);

           


            // Create pen.
             Pen Pen = new Pen(Color.Black, 3);

            // Create rectangle.
            Rectangle rect = new Rectangle(400, 50, 200, 200);
            Rectangle rect1 = new Rectangle(400, 50, 100, 100);

            // Draw rectangle to screen.
            e.Graphics.DrawRectangle(Pen, rect);
            e.Graphics.DrawRectangle(Pen, rect1);

            Graphics g = this.CreateGraphics();
            SolidBrush Brush = new SolidBrush (Color.Green);
           // g.Fill (Brush, ClientRectangle);



            // Create string to draw.
            String drawString = "===UTM===Chisinau";
            

            // Create font and brush.
            Font drawFont = new Font("Arial", 25);
            SolidBrush drawBrush = new SolidBrush(Color.Blue);

            // Create rectangle for drawing.
            float x = 100.0F;
            float y = 50.0F;
            float width = 350.0F;
            float height = 50.0F;
            RectangleF drawRect = new RectangleF(x, y, width, height);

            // Draw rectangle to screen.
            blackPen = new Pen(Color.Black);
            e.Graphics.DrawRectangle(blackPen, x, y, width, height);

            // Draw string to screen.
            e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect);






        }
        //bezier
        private void Bezier(object sender, PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);

            // Create points for curve.
            Point start = new Point(100, 100);
            Point control1 = new Point(400, 50);
            Point control2 = new Point(550, 10);
            Point end = new Point(500, 100);

            // Draw arc to screen.
            e.Graphics.DrawBezier(blackPen, start, control1, control2, end);
        }
    }

}
