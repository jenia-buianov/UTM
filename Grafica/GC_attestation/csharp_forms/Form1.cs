using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

using System.Math;
namespace csharp_forms
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
            Brush brush = new SolidBrush(Color.DeepSkyBlue);
            Pen bluePen = new Pen(brush, 10);
            Pen redPen = new Pen(Color.Red, 5);
            Pen whitePenRect = new Pen(Color.White, 10);
            Pen whitePenRhombus = new Pen(Color.White, 10);

            Point[] rect =
            {
                new Point(200, 200),
                new Point(300, 200),
                new Point(300, 300),
                new Point(200, 300)
            };

            Point[] rhombus =
            {
                new Point(250, 150), 
                new Point(350, 250), 
                new Point(250, 350), 
                new Point(150, 250) 
            };
            graphics.DrawPolygon(redPen, rect);
            int count = 0;
            myTimer.Interval = 500;
            myTimer.Tick += (myObject, eventArgs) =>
            {
                rotatePointsBy(ref rect, rect[0], gradToRad(10));
                graphics.DrawPolygon(redPen, rect);

            };
            myTimer.Start();
        }

        private double gradToRad(double grad)
        {
            return grad * PI / 180;
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
            tmp.X = Convert.ToInt32((point.X - center.X) * Cos(angle)
                                    - (point.Y - center.Y) * Sin(angle)
                                    + center.X);
            tmp.Y = Convert.ToInt32((point.X - center.X) * Sin(angle)
                                    + (point.Y - center.Y) * Cos(angle)
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
            for(int i=0; i<points.Length; i++)
            {
                movePointBy(ref points[i], offset);
            }
        }
    }
    
}
