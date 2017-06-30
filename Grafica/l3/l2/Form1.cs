using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace l2
{
    public partial class Form1 : Form
    {
        private float scale = 2.2F;
        private int sizeX = 30;
        private int sizeY = 40;
        private int angle = 0;
        private bool rot = false;
        Timer timer;
        
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
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.R)
            {
                rotate();
            }
        }

        async Task rotate()
        {

            var loc = re.Location;
            var size = re.Size;
            var oval = ov.Location;



            await Task.Delay(1000);
            rotate(); 
        }

        private void rect_Click(object sender, EventArgs e)
        {

        }

        private void lineShape2_Click(object sender, EventArgs e)
        {

        }


    }
}
