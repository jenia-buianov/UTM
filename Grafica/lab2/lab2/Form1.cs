using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
     public partial class Form1 : Form
     {

          private int x = 30, y = 40;
          private int angle = 100;
          private float scale = 2.2F;
          private int startPointX = 380;
          private int startPointY = 230;
          private bool rotation = false;

          Rectangle rect = new Rectangle();
          

          private double DegreeToRadian(double angle)
          {
               return Math.PI * angle / 180.0;
          }

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
               Graphics g = myform.CreateGraphics();
               Pen selPen = new Pen(Color.White);
          }

          private void timer1_Tick(object sender, EventArgs e)
          {
               this.Refresh();
          }

          
                 

          private void Form1_KeyUp(object sender, KeyEventArgs e)
          {
               var loc = this.rect.Location;
               var size = this.rect.Size;
               if (e.KeyCode == Keys.Up)
               {
                    loc.Y -= 10;
               }
               else if (e.KeyCode == Keys.Down)
               {
                    loc.Y += 10;
               }else
               if (e.KeyCode == Keys.Left)
               {
                    loc.X -= 10;
               }
               else if (e.KeyCode == Keys.Right)
               {
                    loc.X += 10;
               }
               else if (e.KeyCode == Keys.P)
               {
                    size.Width = Convert.ToInt32(size.Width*scale);
                    size.Height = Convert.ToInt32(size.Height*scale);
               }
               else if (e.KeyCode == Keys.L)
               {
                    size.Width = Convert.ToInt32(size.Width/scale);
                    size.Height = Convert.ToInt32(size.Height/scale);
               }
               else if (e.KeyCode == Keys.R)
               {

               }

               this.rect.Location = loc;
               this.rect.Size = size;

          }

          private void rectangleShape1_Click(object sender, EventArgs e)
          {

          }
          
          


         
          
     }
}
