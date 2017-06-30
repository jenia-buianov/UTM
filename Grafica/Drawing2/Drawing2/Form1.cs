using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawing2
{
    public partial class Form1 : Form
    {
        enum Position
        {
            Left, Right, Up, Down, Stop, scaleUP, scaleDown, rotatleLeft, rotateRight
        }

        private int _x;
        private int _y;

        private float _ang;
        private float _scl1, _scl2;

        private Position _objPosition;

        public Form1()
        {
            InitializeComponent();
            _x = 500;
            _y = 200;
            _objPosition = Position.Stop;
            _ang = 0.0F;
            _scl1 = 1.1F;
            _scl2 = 1.1F;
        }

       

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.TranslateTransform(100.0F, 50.0F);
            e.Graphics.ScaleTransform(_scl1, _scl2);
            e.Graphics.RotateTransform(_ang);
           
            e.Graphics.DrawLine(Pens.Green, new Point(_x + 35,_y + 35), new Point(_x + 10, _y + 155));
            e.Graphics.DrawLine(Pens.Green, new Point(_x + 10, _y + 155), new Point(_x + 95, _y + 75));
            e.Graphics.DrawLine(Pens.Green, new Point(_x + 95,_y + 75), new Point(_x - 20, _y + 75));
            e.Graphics.DrawLine(Pens.Green, new Point(_x - 20, _y + 75), new Point(_x + 75, _y + 155));
            e.Graphics.DrawLine(Pens.Green, new Point(_x + 75, _y + 155), new Point(_x + 35, _y + 35));

        }

        private void tmrMoving_Tick(object sender, EventArgs e)
        {
            if (_objPosition == Position.Right)
            {
                _x += 10;
            }
            else if (_objPosition == Position.Left)
            {
                _x -= 10;
            }
            else if (_objPosition == Position.Up)
            {
                _y -= 10;
            }
            else if (_objPosition == Position.Down)
            {
                _y += 10;
            }

            else if (_objPosition == Position.rotateRight)
            {
                _ang += 8.0F;
            }
            else if (_objPosition == Position.rotatleLeft)
            {
                _ang -= 8.0f;
            }
            else if (_objPosition == Position.scaleDown)
            {
                _scl1 -= 0.05F; _scl2 -= 0.05F;
            }
            else if (_objPosition == Position.scaleUP)
            {
                _scl1 += 0.05F; _scl2 += 0.05F;
            }

            Invalidate();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                _objPosition = Position.Left;
            }
            else if (e.KeyCode == Keys.Right)
            {
                _objPosition = Position.Right;
            }
            else if (e.KeyCode == Keys.Up)
            {
                _objPosition = Position.Up;
            }
            else if (e.KeyCode == Keys.Down)
            {
                _objPosition = Position.Down;
            }

            else if (e.KeyCode == Keys.D)
            {
                _objPosition = Position.rotatleLeft;
            }
            else if (e.KeyCode == Keys.W)
            {
                _objPosition = Position.rotateRight;
            }
            else if (e.KeyCode == Keys.A)
            {
                _objPosition = Position.scaleDown;
            }
            else if (e.KeyCode == Keys.S)
            {
                _objPosition = Position.scaleUP;
            }



        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            _objPosition = Position.Stop;
        }
    }
}
