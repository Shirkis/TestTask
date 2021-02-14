namespace TestTask
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.ErrLabel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.f1X = new System.Windows.Forms.TextBox();
            this.f1Y = new System.Windows.Forms.TextBox();
            this.f2Y = new System.Windows.Forms.TextBox();
            this.f2X = new System.Windows.Forms.TextBox();
            this.f3Y = new System.Windows.Forms.TextBox();
            this.f3X = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(675, 621);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Сохранить";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(700, 500);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // ErrLabel
            // 
            this.ErrLabel.AutoSize = true;
            this.ErrLabel.Location = new System.Drawing.Point(843, 473);
            this.ErrLabel.Name = "ErrLabel";
            this.ErrLabel.Size = new System.Drawing.Size(38, 15);
            this.ErrLabel.TabIndex = 2;
            this.ErrLabel.Text = "label1";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox2.Location = new System.Drawing.Point(718, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(700, 500);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseMove);
            this.pictureBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseUp);
            // 
            // f1X
            // 
            this.f1X.Location = new System.Drawing.Point(612, 534);
            this.f1X.Name = "f1X";
            this.f1X.Size = new System.Drawing.Size(100, 23);
            this.f1X.TabIndex = 5;
            // 
            // f1Y
            // 
            this.f1Y.Location = new System.Drawing.Point(718, 534);
            this.f1Y.Name = "f1Y";
            this.f1Y.Size = new System.Drawing.Size(100, 23);
            this.f1Y.TabIndex = 5;
            // 
            // f2Y
            // 
            this.f2Y.Location = new System.Drawing.Point(718, 563);
            this.f2Y.Name = "f2Y";
            this.f2Y.Size = new System.Drawing.Size(100, 23);
            this.f2Y.TabIndex = 5;
            // 
            // f2X
            // 
            this.f2X.Location = new System.Drawing.Point(612, 563);
            this.f2X.Name = "f2X";
            this.f2X.Size = new System.Drawing.Size(100, 23);
            this.f2X.TabIndex = 5;
            // 
            // f3Y
            // 
            this.f3Y.Location = new System.Drawing.Point(718, 592);
            this.f3Y.Name = "f3Y";
            this.f3Y.Size = new System.Drawing.Size(100, 23);
            this.f3Y.TabIndex = 5;
            // 
            // f3X
            // 
            this.f3X.Location = new System.Drawing.Point(612, 592);
            this.f3X.Name = "f3X";
            this.f3X.Size = new System.Drawing.Size(100, 23);
            this.f3X.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(654, 515);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(759, 515);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(515, 537);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Приемник 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(515, 566);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Приемник 2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(515, 595);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Приемник 3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(165, 519);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Задание 1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1033, 519);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "Задание 2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1427, 646);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.f3X);
            this.Controls.Add(this.f3Y);
            this.Controls.Add(this.f2X);
            this.Controls.Add(this.f2Y);
            this.Controls.Add(this.f1Y);
            this.Controls.Add(this.f1X);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.ErrLabel);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.startButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label ErrLabel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox f1X;
        private System.Windows.Forms.TextBox f1Y;
        private System.Windows.Forms.TextBox f2Y;
        private System.Windows.Forms.TextBox f2X;
        private System.Windows.Forms.TextBox f3Y;
        private System.Windows.Forms.TextBox f3X;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

