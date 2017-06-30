using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BezierApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Bitmap DrawArea = new Bitmap(picBox.Size.Width, picBox.Size.Height);
            Graphics g = Graphics.FromImage(DrawArea);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;


            Pen b1 = new Pen(System.Drawing.Color.Black);
            Pen red = new Pen(System.Drawing.Color.Green);

            System.Drawing.Point p1 = new System.Drawing.Point(25, 25);
            System.Drawing.Point p2 = new System.Drawing.Point(300, 25);
            System.Drawing.Point p3 = new System.Drawing.Point(25, 300);
            System.Drawing.Point p4 = new System.Drawing.Point(900, 900);

            List<System.Drawing.Point> p = new List<System.Drawing.Point> { p1, p2, p3, p4 };
            g.DrawBezier(red, p1, p2, p3, p4);
            foreach (System.Drawing.Point point in p)
                g.DrawRectangle(b1, point.X - 1, point.Y - 1, 2, 2);
            picBox.Image = DrawArea;
        }
    }
}
