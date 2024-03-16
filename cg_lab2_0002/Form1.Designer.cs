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
            System.Windows.Forms.Label Step;
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttobtnBezierCurven1 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.tothePoint = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.MatrixLabel = new System.Windows.Forms.Label();
            this.RarametricLabel = new System.Windows.Forms.Label();
            Step = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Step
            // 
            Step.Location = new System.Drawing.Point(31, 650);
            Step.Name = "Step";
            Step.Size = new System.Drawing.Size(57, 20);
            Step.TabIndex = 17;
            Step.Text = "Step";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.CausesValidation = false;
            this.panel1.Location = new System.Drawing.Point(39, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 500);
            this.panel1.TabIndex = 0;
            // 
            // buttobtnBezierCurven1
            // 
            this.buttobtnBezierCurven1.Location = new System.Drawing.Point(729, 19);
            this.buttobtnBezierCurven1.Name = "buttobtnBezierCurven1";
            this.buttobtnBezierCurven1.Size = new System.Drawing.Size(107, 40);
            this.buttobtnBezierCurven1.TabIndex = 1;
            this.buttobtnBezierCurven1.Text = "CLEAR";
            this.buttobtnBezierCurven1.UseVisualStyleBackColor = true;
            this.buttobtnBezierCurven1.Click += new System.EventHandler(this.buttobtnBezierCurven1_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(690, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 49);
            this.button1.TabIndex = 2;
            this.button1.Text = "Delete Mode";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(691, 120);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 48);
            this.button2.TabIndex = 3;
            this.button2.Text = "Edit X and Y mode";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(738, 206);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(738, 260);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(738, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "X point";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(738, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Y point";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(739, 290);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 28);
            this.button3.TabIndex = 8;
            this.button3.Text = "Edit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(544, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Edit button mod\r\n";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(31, 622);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(97, 22);
            this.textBox3.TabIndex = 10;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(171, 622);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(98, 22);
            this.textBox4.TabIndex = 11;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(171, 673);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(98, 22);
            this.button4.TabIndex = 12;
            this.button4.Text = "Find point";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // tothePoint
            // 
            this.tothePoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tothePoint.Location = new System.Drawing.Point(134, 610);
            this.tothePoint.Name = "tothePoint";
            this.tothePoint.Size = new System.Drawing.Size(35, 21);
            this.tothePoint.TabIndex = 13;
            this.tothePoint.Text = "_____";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(31, 673);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(97, 22);
            this.textBox5.TabIndex = 14;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(31, 599);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Start";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(171, 599);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "End";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(303, 610);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(92, 84);
            this.button5.TabIndex = 18;
            this.button5.Text = "Log History";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.IndianRed;
            this.label6.Location = new System.Drawing.Point(544, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 23);
            this.label6.TabIndex = 19;
            this.label6.Text = "Delete Mode";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(694, 592);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(144, 52);
            this.button6.TabIndex = 20;
            this.button6.Text = "Parametryc";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(694, 664);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(144, 49);
            this.button7.TabIndex = 21;
            this.button7.Text = "Matrix";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // MatrixLabel
            // 
            this.MatrixLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.MatrixLabel.Location = new System.Drawing.Point(544, 45);
            this.MatrixLabel.Name = "MatrixLabel";
            this.MatrixLabel.Size = new System.Drawing.Size(123, 23);
            this.MatrixLabel.TabIndex = 22;
            this.MatrixLabel.Text = "Matrix Mode";
            // 
            // RarametricLabel
            // 
            this.RarametricLabel.BackColor = System.Drawing.Color.BlueViolet;
            this.RarametricLabel.Location = new System.Drawing.Point(544, 45);
            this.RarametricLabel.Name = "RarametricLabel";
            this.RarametricLabel.Size = new System.Drawing.Size(123, 23);
            this.RarametricLabel.TabIndex = 23;
            this.RarametricLabel.Text = "Parametryc mode";
            this.RarametricLabel.Click += new System.EventHandler(this.RarametricLabel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(868, 727);
            this.Controls.Add(this.RarametricLabel);
            this.Controls.Add(this.MatrixLabel);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button5);
            this.Controls.Add(Step);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.tothePoint);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttobtnBezierCurven1);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label MatrixLabel;
        private System.Windows.Forms.Label RarametricLabel;

        private System.Windows.Forms.Button button7;

        private System.Windows.Forms.Button button6;

        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.Button button5;

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.TextBox textBox5;

        private System.Windows.Forms.Label tothePoint;

        private System.Windows.Forms.Button button4;

        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Button button3;

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.Button buttobtnBezierCurven1;

        private System.Windows.Forms.Panel panel1;

        #endregion
    }
}
