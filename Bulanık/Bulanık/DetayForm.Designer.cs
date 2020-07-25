namespace WindowsFormsApplication1
{
    partial class DetayForm
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
            this.lblLegend1 = new System.Windows.Forms.Label();
            this.lblLegend2 = new System.Windows.Forms.Label();
            this.lblLegend3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.pbRenk3 = new System.Windows.Forms.PictureBox();
            this.pbRenk2 = new System.Windows.Forms.PictureBox();
            this.pbRenk1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbRenk3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRenk2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRenk1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLegend1
            // 
            this.lblLegend1.AutoSize = true;
            this.lblLegend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblLegend1.Location = new System.Drawing.Point(51, 13);
            this.lblLegend1.Name = "lblLegend1";
            this.lblLegend1.Size = new System.Drawing.Size(61, 17);
            this.lblLegend1.TabIndex = 3;
            this.lblLegend1.Text = "YAMUK";
            // 
            // lblLegend2
            // 
            this.lblLegend2.AutoSize = true;
            this.lblLegend2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblLegend2.Location = new System.Drawing.Point(51, 46);
            this.lblLegend2.Name = "lblLegend2";
            this.lblLegend2.Size = new System.Drawing.Size(62, 17);
            this.lblLegend2.TabIndex = 3;
            this.lblLegend2.Text = "ÜÇGEN";
            // 
            // lblLegend3
            // 
            this.lblLegend3.AutoSize = true;
            this.lblLegend3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblLegend3.Location = new System.Drawing.Point(51, 74);
            this.lblLegend3.Name = "lblLegend3";
            this.lblLegend3.Size = new System.Drawing.Size(61, 17);
            this.lblLegend3.TabIndex = 3;
            this.lblLegend3.Text = "YAMUK";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(130, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(246, 22);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(130, 41);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(246, 22);
            this.textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(130, 69);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(246, 22);
            this.textBox3.TabIndex = 4;
            // 
            // pbRenk3
            // 
            this.pbRenk3.BackColor = System.Drawing.Color.Red;
            this.pbRenk3.Location = new System.Drawing.Point(13, 69);
            this.pbRenk3.Name = "pbRenk3";
            this.pbRenk3.Size = new System.Drawing.Size(31, 22);
            this.pbRenk3.TabIndex = 2;
            this.pbRenk3.TabStop = false;
            // 
            // pbRenk2
            // 
            this.pbRenk2.BackColor = System.Drawing.Color.Lime;
            this.pbRenk2.Location = new System.Drawing.Point(13, 41);
            this.pbRenk2.Name = "pbRenk2";
            this.pbRenk2.Size = new System.Drawing.Size(31, 22);
            this.pbRenk2.TabIndex = 1;
            this.pbRenk2.TabStop = false;
            // 
            // pbRenk1
            // 
            this.pbRenk1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pbRenk1.Location = new System.Drawing.Point(13, 13);
            this.pbRenk1.Name = "pbRenk1";
            this.pbRenk1.Size = new System.Drawing.Size(31, 22);
            this.pbRenk1.TabIndex = 0;
            this.pbRenk1.TabStop = false;
            // 
            // DetayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(378, 101);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblLegend3);
            this.Controls.Add(this.lblLegend2);
            this.Controls.Add(this.lblLegend1);
            this.Controls.Add(this.pbRenk3);
            this.Controls.Add(this.pbRenk2);
            this.Controls.Add(this.pbRenk1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximumSize = new System.Drawing.Size(396, 148);
            this.Name = "DetayForm";
            this.Text = "DetayForm";
            this.Load += new System.EventHandler(this.DetayForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbRenk3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRenk2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRenk1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbRenk1;
        private System.Windows.Forms.PictureBox pbRenk2;
        private System.Windows.Forms.PictureBox pbRenk3;
        private System.Windows.Forms.Label lblLegend1;
        private System.Windows.Forms.Label lblLegend2;
        private System.Windows.Forms.Label lblLegend3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
    }
}