using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
     public partial class Form1 : Form
     {
          private double memory = 0;
          private string actionForResult = "";
          private double number = 0;
          private Boolean operation = false;

          public Form1()
          {
               InitializeComponent();
               this.KeyPreview = true;
          }


          private void button_click(object sender, EventArgs e)
          {
               Button b = (Button)sender;
               if (result.Text == "0")
                    result.Clear();
               result.Text += b.Text;
                
          }


          private void button_clear_Click(object sender, EventArgs e)
          {
               result.Text = "0";
          }


          private void button_equal_Click(object sender, EventArgs e)
          {
               if(this.operation) this.number = Convert.ToDouble(result.Text);     
               if (this.actionForResult.Equals("+")) this.memory += this.number;
               if (this.actionForResult.Equals("-")) this.memory -= this.number;
               if (this.actionForResult.Equals("*")) this.memory *= this.number;
               if (this.actionForResult.Equals("/") && this.number!=0) this.memory /= this.number;
               if (this.actionForResult.Equals("/") && this.number == 0) result.Text = "Не делится";
               
               
               this.operation = false;
               result.Text = Convert.ToString(this.memory);
          }

          private void clearAll(object sender, EventArgs e)
          {
               this.number = 0;
               this.actionForResult = "";
               this.memory = 0;
               result.Text = "0";
          }

          private void get_operation(object sender, EventArgs e, String text)
          {
               this.number = Convert.ToDouble(result.Text);
               this.memory = this.number;
               this.actionForResult = text;
               this.button_clear_Click(sender, e);
               this.operation = true;
          }

          private void operation_click(object sender, EventArgs e)
          {
               Button b = (Button)sender;
               get_operation(sender, e, b.Text);
          }

          private void invert(object sender, EventArgs e)
          {
               result.Text = Convert.ToString(-1*Convert.ToDouble(result.Text));
          }

          private void pressing(object sender, KeyPressEventArgs e)
          {
               
               if (e.KeyChar == 42 || e.KeyChar == 43 || e.KeyChar == 45 || e.KeyChar == 47)
               {
                    get_operation(sender, e, e.KeyChar.ToString());
                    return;
               }
               if (e.KeyChar == 46)
               {
                    get_operation(sender, e, ",");
                    return;
               }
               if ((e.KeyChar >= 48 && e.KeyChar <= 57)||e.KeyChar==44)
               {
                    if (result.Text == "0")
                         result.Clear();
                    result.Text += e.KeyChar.ToString();
               }
          }

          private void Form1_Load(object sender, EventArgs e)
          {

          }

     }
}
