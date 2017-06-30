namespace Clock
{
    partial class FormSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.panel = new System.Windows.Forms.Panel();
            this.radioButtonElectro = new System.Windows.Forms.RadioButton();
            this.radioButtonClockFace = new System.Windows.Forms.RadioButton();
            this.labelUTC = new System.Windows.Forms.Label();
            this.textBoxOffset = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker.Location = new System.Drawing.Point(12, 12);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.ShowUpDown = true;
            this.dateTimePicker.Size = new System.Drawing.Size(68, 20);
            this.dateTimePicker.TabIndex = 0;
            // 
            // panel
            // 
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel.Controls.Add(this.radioButtonClockFace);
            this.panel.Controls.Add(this.radioButtonElectro);
            this.panel.Location = new System.Drawing.Point(12, 38);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(132, 51);
            this.panel.TabIndex = 3;
            // 
            // radioButtonElectro
            // 
            this.radioButtonElectro.AutoSize = true;
            this.radioButtonElectro.Checked = true;
            this.radioButtonElectro.Location = new System.Drawing.Point(3, 3);
            this.radioButtonElectro.Name = "radioButtonElectro";
            this.radioButtonElectro.Size = new System.Drawing.Size(121, 17);
            this.radioButtonElectro.TabIndex = 3;
            this.radioButtonElectro.TabStop = true;
            this.radioButtonElectro.Text = "Электронные часы";
            this.radioButtonElectro.UseVisualStyleBackColor = true;
            // 
            // radioButtonClockFace
            // 
            this.radioButtonClockFace.AutoSize = true;
            this.radioButtonClockFace.Location = new System.Drawing.Point(3, 26);
            this.radioButtonClockFace.Name = "radioButtonClockFace";
            this.radioButtonClockFace.Size = new System.Drawing.Size(104, 17);
            this.radioButtonClockFace.TabIndex = 4;
            this.radioButtonClockFace.Text = "С циферблатом";
            this.radioButtonClockFace.UseVisualStyleBackColor = true;
            // 
            // labelUTC
            // 
            this.labelUTC.AutoSize = true;
            this.labelUTC.Location = new System.Drawing.Point(150, 15);
            this.labelUTC.Name = "labelUTC";
            this.labelUTC.Size = new System.Drawing.Size(32, 13);
            this.labelUTC.TabIndex = 4;
            this.labelUTC.Text = "UTC:";
            // 
            // textBoxOffset
            // 
            this.textBoxOffset.Location = new System.Drawing.Point(188, 12);
            this.textBoxOffset.Name = "textBoxOffset";
            this.textBoxOffset.Size = new System.Drawing.Size(49, 20);
            this.textBoxOffset.TabIndex = 5;
            this.textBoxOffset.Text = "0";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(162, 66);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 105);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxOffset);
            this.Controls.Add(this.labelUTC);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.dateTimePicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormSettings";
            this.Text = "Settings";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.RadioButton radioButtonClockFace;
        private System.Windows.Forms.RadioButton radioButtonElectro;
        private System.Windows.Forms.Label labelUTC;
        private System.Windows.Forms.TextBox textBoxOffset;
        private System.Windows.Forms.Button buttonOK;
    }
}