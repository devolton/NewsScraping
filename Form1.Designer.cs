namespace NewsScraping
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
            runButton = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // runButton
            // 
            runButton.BackColor = Color.Aquamarine;
            runButton.FlatAppearance.BorderSize = 0;
            runButton.FlatStyle = FlatStyle.Flat;
            runButton.Font = new Font("Hotel De Paris", 12F, FontStyle.Regular, GraphicsUnit.Point);
            runButton.Location = new Point(141, 131);
            runButton.Name = "runButton";
            runButton.Size = new Size(170, 49);
            runButton.TabIndex = 0;
            runButton.Text = "Go Scraping News";
            runButton.UseVisualStyleBackColor = false;
            runButton.Click += runButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(110, 91);
            label1.Name = "label1";
            label1.Size = new Size(246, 37);
            label1.TabIndex = 1;
            label1.Text = "News Scraping";
            label1.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(169, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(111, 86);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleTurquoise;
            ClientSize = new Size(435, 227);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(runButton);
            Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "News Scraping";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button runButton;
        private Label label1;
        private PictureBox pictureBox1;
    }
}