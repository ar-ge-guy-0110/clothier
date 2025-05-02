namespace ClothierProject
{
    partial class form_user_data
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_user_data));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.programicon = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.formtoaltlabel = new System.Windows.Forms.Label();
            this.formtoexitlabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.programicon)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "body mass index";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Body Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Clothing Style";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 305);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Season";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(56, 355);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "Place";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
            this.panel1.Controls.Add(this.programicon);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(39, 410);
            this.panel1.TabIndex = 6;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // programicon
            // 
            this.programicon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
            this.programicon.Image = global::ClothierProject.images.dress;
            this.programicon.Location = new System.Drawing.Point(12, 9);
            this.programicon.Name = "programicon";
            this.programicon.Size = new System.Drawing.Size(19, 18);
            this.programicon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.programicon.TabIndex = 4;
            this.programicon.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
            this.panel2.Controls.Add(this.formtoaltlabel);
            this.panel2.Controls.Add(this.formtoexitlabel);
            this.panel2.Location = new System.Drawing.Point(39, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(347, 32);
            this.panel2.TabIndex = 7;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // formtoaltlabel
            // 
            this.formtoaltlabel.AutoSize = true;
            this.formtoaltlabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.formtoaltlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(56)))), ((int)(((byte)(255)))));
            this.formtoaltlabel.Location = new System.Drawing.Point(291, 5);
            this.formtoaltlabel.Name = "formtoaltlabel";
            this.formtoaltlabel.Size = new System.Drawing.Size(17, 18);
            this.formtoaltlabel.TabIndex = 14;
            this.formtoaltlabel.Text = "_";
            this.formtoaltlabel.Click += new System.EventHandler(this.formtoaltlabel_Click);
            this.formtoaltlabel.MouseLeave += new System.EventHandler(this.formtoaltlabel_MouseLeave);
            this.formtoaltlabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.formtoaltlabel_MouseMove);
            // 
            // formtoexitlabel
            // 
            this.formtoexitlabel.AutoSize = true;
            this.formtoexitlabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.formtoexitlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(56)))), ((int)(((byte)(255)))));
            this.formtoexitlabel.Location = new System.Drawing.Point(314, 9);
            this.formtoexitlabel.Name = "formtoexitlabel";
            this.formtoexitlabel.Size = new System.Drawing.Size(19, 18);
            this.formtoexitlabel.TabIndex = 13;
            this.formtoexitlabel.Text = "X";
            this.formtoexitlabel.Click += new System.EventHandler(this.formtoexitlabel_Click);
            this.formtoexitlabel.MouseLeave += new System.EventHandler(this.formtoexitlabel_MouseLeave);
            this.formtoexitlabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.formtoexitlabel_MouseMove);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(56, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 18);
            this.label7.TabIndex = 8;
            this.label7.Text = "Body_State";
            // 
            // form_user_data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(384, 407);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 12F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(56)))), ((int)(((byte)(255)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "form_user_data";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.form_user_data_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form_user_data_MouseDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.programicon)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label formtoaltlabel;
        private System.Windows.Forms.Label formtoexitlabel;
        private System.Windows.Forms.PictureBox programicon;
        private System.Windows.Forms.Label label7;
    }
}