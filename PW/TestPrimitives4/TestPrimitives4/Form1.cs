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
            Pen blackPen = new Pen(Color.Black, 3);
            
            // Create points that define polygon.
            Point point1 = new Point(10, 50);
            Point point2 = new Point(120, 25);
            Point point3 = new Point(150, 35);
            Point point4 = new Point(300, 5);
            Point[] curvePoints =
                     {
                 point1,
                 point2,
                 point3,
                 point4
            };

            // Draw polygon to screen.
            e.Graphics.DrawPolygon(blackPen, curvePoints);
          

        }
        
    }

}
