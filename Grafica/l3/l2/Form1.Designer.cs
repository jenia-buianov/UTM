namespace l2
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.re = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.ov = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.SuspendLayout();
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.ov,
            this.re});
            this.shapeContainer1.Size = new System.Drawing.Size(984, 687);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // re
            // 
            this.re.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.re.FillColor = System.Drawing.Color.White;
            this.re.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.re.Location = new System.Drawing.Point(389, 356);
            this.re.Name = "re";
            this.re.Size = new System.Drawing.Size(76, 210);
            // 
            // ov
            // 
            this.ov.BorderColor = System.Drawing.Color.White;
            this.ov.FillColor = System.Drawing.Color.Lime;
            this.ov.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.ov.Location = new System.Drawing.Point(340, 85);
            this.ov.Name = "ov";
            this.ov.Size = new System.Drawing.Size(175, 309);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(984, 687);
            this.Controls.Add(this.shapeContainer1);
            this.MinimumSize = new System.Drawing.Size(1000, 39);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.OvalShape ov;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape re;

    }
}

