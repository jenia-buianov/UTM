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
            Brush brush = new SolidBrush(Color.Green);
            Pen bluePen = new Pen(brush, 10);
            Pen redPen = new Pen(Color.Black, 5);
            Pen greenPen = new Pen(Color.Green, 5);
            
            Pen whitePenRect = new Pen(Color.White, 10);
            Pen whitePenRhombus = new Pen(Color.White, 10);

            Point[] rect =
            {
                new Point(200, 300),
                new Point(250, 300),
                new Point(250, 400),
                new Point(200, 400)
            };

            graphics.DrawPolygon(redPen, rect);
            graphics.DrawEllipse(greenPen, 175,50,100,250);
            graphics.FillEllipse(brush, 175, 50, 100, 250);

            //int count = 0;
            myTimer.Interval = 500;
            myTimer.Tick += (myObject, eventArgs) =>
            {
                this.Refresh();
                graphics.DrawEllipse(greenPen, 175, 50, 100, 250);
                graphics.FillEllipse(brush, 175, 50, 100, 250);
                //movePointsBy(ref rect, new Point(-10, -15));
                //nonlinear_scalePointsBy(ref rect, new Point(225,250), 1.2, 2);
                rotatePointsBy(ref rect, rect[0], gradToRad(10));
                graphics.DrawPolygon(redPen, rect);

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
