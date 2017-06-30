using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Math;

namespace Attestation1
{
    public partial class Form1 : Form
    {
        Timer myTimer = new Timer();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            var graphics = pictureBox.CreateGraphics();
            Brush yellowBrush = new SolidBrush(Color.Yellow);
            Pen yellowPen = new Pen(Color.Yellow,5);

            Brush grayBrush = new SolidBrush(Color.Gray);
            Pen grayPen = new Pen(Color.Gray, 5);


            Pen whitePenRect = new Pen(Color.White, 10);
            Pen whitePenRhombus = new Pen(Color.White, 10);
            Brush whiteBrush = new SolidBrush(Color.White);

            Point sun_ = new Point(10,30);

            Point[] houseP = {
                 new Point(100,200),
                 new Point(500,200),
                 new Point(500,400),
                 new Point(100,400)
                              };
            Point[] doorP = {
                 new Point(300,300),
                 new Point(350,300),
                 new Point(350,400),
                 new Point(300,400)
                              };
            Size sunSize = new Size(50, 50);
            Rectangle house = new Rectangle(new Point(100,200),new Size(400,200));
            Rectangle door = new Rectangle(new Point(300, 300), new Size(50, 100));

            graphics.DrawPolygon(grayPen,houseP);
            graphics.FillPolygon(grayBrush,houseP);

            graphics.DrawPolygon(whitePenRect, doorP);
            graphics.FillPolygon(whiteBrush, doorP);


            graphics.DrawEllipse(yellowPen, new Rectangle(sun_, sunSize));
            graphics.FillEllipse(yellowBrush, new Rectangle(sun_, sunSize));
            
            
            int count = 1;
            myTimer.Interval = 1000;
            myTimer.Tick += (myObject, eventArgs) =>
            {
                if (count > 4) myTimer.Stop();
                this.Refresh();

                movePointBy(ref sun_, new Point(30, -3));
                graphics.DrawEllipse(yellowPen, new Rectangle(sun_, sunSize));
                graphics.FillEllipse(yellowBrush, new Rectangle(sun_, sunSize));
				
				graphics.DrawPolygon(grayPen,houseP);
				graphics.FillPolygon(grayBrush,houseP);

                if (count>2) rotatePointsBy(ref doorP,new Point(325,350), gradToRad(60));
                graphics.DrawPolygon(whitePenRect, doorP);
				graphics.FillPolygon(whiteBrush, doorP);
                count++;

            };
            myTimer.Start();
            
        }

        private double gradToRad(double grad)
        {
            return grad * System.Math.PI / 180;
        }

        private void nonlinear_ScalePointBy(ref Point point, Point center, double multiplierX, double multiplierY)
        {
            Point tmp = new Point();

            tmp.X = Convert.ToInt32((point.X - center.X) * multiplierX + center.X);
            tmp.Y = Convert.ToInt32((point.Y - center.Y) * multiplierY + center.Y);

            point = tmp;
        }

        private void nonlinear_scalePointsBy(ref Point[] points, Point center, double multiplierX, double multiplierY)
        {
            for (int i = 0; i < points.Length; i++)
            {
                nonlinear_ScalePointBy(ref points[i], center, multiplierX, multiplierY);
            }
        }

        private void rotatePointBy(ref Point point, Point center, double angle)
        {
            Point tmp = new Point();
            tmp.X = Convert.ToInt32((point.X - center.X) * System.Math.Cos(angle)
                                    - (point.Y - center.Y) * System.Math.Sin(angle)
                                    + center.X);
            tmp.Y = Convert.ToInt32((point.X - center.X) * System.Math.Sin(angle)
                                    + (point.Y - center.Y) * System.Math.Cos(angle)
                                    + center.Y);
            point = tmp;
        }

        private void rotatePointsBy(ref Point[] points, Point center, double angle)
        {
            for (int i = 0; i < points.Length; i++)
            {
                rotatePointBy(ref points[i], center, angle);
            }
        }

        private void movePointBy(ref Point point, Point offset)
        {
            point.X += offset.X;
            point.Y += offset.Y;
        }

        private void movePointsBy(ref Point[] points, Point offset)
        {
            for (int i = 0; i < points.Length; i++)
            {
                movePointBy(ref points[i], offset);
            }
        }
    }
}
