namespace ClothierProject
{
    partial class form_onetime_defClothingStyle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_onetime_defClothingStyle));
            this.bigline = new System.Windows.Forms.Panel();
            this.programicon = new System.Windows.Forms.PictureBox();
            this.registerlabel = new System.Windows.Forms.Label();
            this.clothingstyleflowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.programicon)).BeginInit();
            this.SuspendLayout();
            // 
            // bigline
            // 
            this.bigline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(56)))), ((int)(((byte)(255)))));
            this.bigline.Location = new System.Drawing.Point(12, 36);
            this.bigline.Name = "bigline";
            this.bigline.Size = new System.Drawing.Size(1075, 1);
            this.bigline.TabIndex = 7;
            // 
            // programicon
            // 
            this.programicon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.programicon.Image = global::ClothierProject.images.dress;
            this.programicon.Location = new System.Drawing.Point(12, 12);
            this.programicon.Name = "programicon";
            this.programicon.Size = new System.Drawing.Size(19, 18);
            this.programicon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.programicon.TabIndex = 6;
            this.programicon.TabStop = false;
            // 
            // registerlabel
            // 
            this.registerlabel.AutoSize = true;
            this.registerlabel.Font = new System.Drawing.Font("Arial", 12F);
            this.registerlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(56)))), ((int)(((byte)(255)))));
            this.registerlabel.Location = new System.Drawing.Point(37, 12);
            this.registerlabel.Name = "registerlabel";
            this.registerlabel.Size = new System.Drawing.Size(185, 18);
            this.registerlabel.TabIndex = 8;
            this.registerlabel.Text = "Select Your Clothing Style";
            // 
            // clothingstyleflowLayoutPanel1
            // 
            this.clothingstyleflowLayoutPanel1.AutoScroll = true;
            this.clothingstyleflowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.clothingstyleflowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.clothingstyleflowLayoutPanel1.Font = new System.Drawing.Font("Arial", 12F);
            this.clothingstyleflowLayoutPanel1.Location = new System.Drawing.Point(12, 52);
            this.clothingstyleflowLayoutPanel1.Name = "clothingstyleflowLayoutPanel1";
            this.clothingstyleflowLayoutPanel1.Size = new System.Drawing.Size(1075, 496);
            this.clothingstyleflowLayoutPanel1.TabIndex = 9;
            // 
            // form_onetime_defClothingStyle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(1100, 570);
            this.Controls.Add(this.clothingstyleflowLayoutPanel1);
            this.Controls.Add(this.registerlabel);
            this.Controls.Add(this.bigline);
            this.Controls.Add(this.programicon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "form_onetime_defClothingStyle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.form_onetime_defClothingStyle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.programicon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel bigline;
        private System.Windows.Forms.PictureBox programicon;
        private System.Windows.Forms.Label registerlabel;
        private System.Windows.Forms.FlowLayoutPanel clothingstyleflowLayoutPanel1;
    }
}