namespace cg_lab2_0002
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttobtnBezierCurven1 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(39, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 500);
            this.panel1.TabIndex = 0;
            // 
            // buttobtnBezierCurven1
            // 
            this.buttobtnBezierCurven1.Location = new System.Drawing.Point(762, 67);
            this.buttobtnBezierCurven1.Name = "buttobtnBezierCurven1";
            this.buttobtnBezierCurven1.Size = new System.Drawing.Size(107, 40);
            this.buttobtnBezierCurven1.TabIndex = 1;
            this.buttobtnBezierCurven1.Text = "button1";
            this.buttobtnBezierCurven1.UseVisualStyleBackColor = true;
            this.buttobtnBezierCurven1.Click += new System.EventHandler(this.buttobtnBezierCurven1_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(745, 156);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 49);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 681);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttobtnBezierCurven1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.Button buttobtnBezierCurven1;

        private System.Windows.Forms.Panel panel1;

        #endregion
    }
}
