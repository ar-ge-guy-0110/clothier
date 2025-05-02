namespace ClothierProject
{
    partial class form_user_register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_user_register));
            this.passtextBox = new System.Windows.Forms.TextBox();
            this.usernametextBox = new System.Windows.Forms.TextBox();
            this.userline = new System.Windows.Forms.Panel();
            this.passline = new System.Windows.Forms.Panel();
            this.registerbutton = new System.Windows.Forms.Button();
            this.formtoaltlabel = new System.Windows.Forms.Label();
            this.formtoexitlabel = new System.Windows.Forms.Label();
            this.programicon = new System.Windows.Forms.PictureBox();
            this.controllabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.programicon)).BeginInit();
            this.SuspendLayout();
            // 
            // passtextBox
            // 
            this.passtextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.passtextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passtextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.passtextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(56)))), ((int)(((byte)(255)))));
            this.passtextBox.HideSelection = false;
            this.passtextBox.Location = new System.Drawing.Point(100, 140);
            this.passtextBox.Name = "passtextBox";
            this.passtextBox.Size = new System.Drawing.Size(200, 19);
            this.passtextBox.TabIndex = 5;
            this.passtextBox.Text = "Password";
            this.passtextBox.Click += new System.EventHandler(this.passtextBox_Click);
            this.passtextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.passtextBox_MouseClick);
            this.passtextBox.TextChanged += new System.EventHandler(this.passtextBox_TextChanged);
            // 
            // usernametextBox
            // 
            this.usernametextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.usernametextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernametextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.usernametextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(56)))), ((int)(((byte)(255)))));
            this.usernametextBox.HideSelection = false;
            this.usernametextBox.Location = new System.Drawing.Point(100, 98);
            this.usernametextBox.Name = "usernametextBox";
            this.usernametextBox.Size = new System.Drawing.Size(200, 19);
            this.usernametextBox.TabIndex = 4;
            this.usernametextBox.Text = "Username";
            this.usernametextBox.Click += new System.EventHandler(this.usernametextBox_Click);
            this.usernametextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.usernametextBox_MouseClick);
            this.usernametextBox.TextChanged += new System.EventHandler(this.usernametextBox_TextChanged);
            // 
            // userline
            // 
            this.userline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(56)))), ((int)(((byte)(255)))));
            this.userline.Location = new System.Drawing.Point(100, 123);
            this.userline.Name = "userline";
            this.userline.Size = new System.Drawing.Size(200, 1);
            this.userline.TabIndex = 6;
            // 
            // passline
            // 
            this.passline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(56)))), ((int)(((byte)(255)))));
            this.passline.Location = new System.Drawing.Point(100, 165);
            this.passline.Name = "passline";
            this.passline.Size = new System.Drawing.Size(200, 1);
            this.passline.TabIndex = 7;
            // 
            // registerbutton
            // 
            this.registerbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(56)))), ((int)(((byte)(255)))));
            this.registerbutton.FlatAppearance.BorderSize = 0;
            this.registerbutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(56)))), ((int)(((byte)(255)))));
            this.registerbutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(56)))), ((int)(((byte)(255)))));
            this.registerbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registerbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.registerbutton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.registerbutton.Location = new System.Drawing.Point(100, 192);
            this.registerbutton.Name = "registerbutton";
            this.registerbutton.Size = new System.Drawing.Size(200, 30);
            this.registerbutton.TabIndex = 8;
            this.registerbutton.Text = "Register";
            this.registerbutton.UseVisualStyleBackColor = false;
            this.registerbutton.Click += new System.EventHandler(this.registerbutton_Click);
            // 
            // formtoaltlabel
            // 
            this.formtoaltlabel.AutoSize = true;
            this.formtoaltlabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.formtoaltlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(56)))), ((int)(((byte)(255)))));
            this.formtoaltlabel.Location = new System.Drawing.Point(346, 5);
            this.formtoaltlabel.Name = "formtoaltlabel";
            this.formtoaltlabel.Size = new System.Drawing.Size(17, 18);
            this.formtoaltlabel.TabIndex = 1;
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
            this.formtoexitlabel.Location = new System.Drawing.Point(369, 9);
            this.formtoexitlabel.Name = "formtoexitlabel";
            this.formtoexitlabel.Size = new System.Drawing.Size(19, 18);
            this.formtoexitlabel.TabIndex = 0;
            this.formtoexitlabel.Text = "X";
            this.formtoexitlabel.Click += new System.EventHandler(this.formtoexitlabel_Click);
            this.formtoexitlabel.MouseLeave += new System.EventHandler(this.formtoexitlabel_MouseLeave);
            this.formtoexitlabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.formtoexitlabel_MouseMove);
            // 
            // programicon
            // 
            this.programicon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.programicon.Image = global::ClothierProject.images.dress;
            this.programicon.Location = new System.Drawing.Point(12, 12);
            this.programicon.Name = "programicon";
            this.programicon.Size = new System.Drawing.Size(19, 18);
            this.programicon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.programicon.TabIndex = 2;
            this.programicon.TabStop = false;
            // 
            // controllabel
            // 
            this.controllabel.AutoSize = true;
            this.controllabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.controllabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(56)))), ((int)(((byte)(255)))));
            this.controllabel.Location = new System.Drawing.Point(97, 235);
            this.controllabel.Name = "controllabel";
            this.controllabel.Size = new System.Drawing.Size(0, 15);
            this.controllabel.TabIndex = 9;
            // 
            // form_user_register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(400, 375);
            this.Controls.Add(this.controllabel);
            this.Controls.Add(this.programicon);
            this.Controls.Add(this.formtoexitlabel);
            this.Controls.Add(this.formtoaltlabel);
            this.Controls.Add(this.registerbutton);
            this.Controls.Add(this.passline);
            this.Controls.Add(this.userline);
            this.Controls.Add(this.passtextBox);
            this.Controls.Add(this.usernametextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "form_user_register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "form_user_register";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_user_register_FormClosed);
            this.Load += new System.EventHandler(this.form_user_register_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form_user_register_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.programicon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox passtextBox;
        private System.Windows.Forms.TextBox usernametextBox;
        private System.Windows.Forms.Panel userline;
        private System.Windows.Forms.Panel passline;
        private System.Windows.Forms.Button registerbutton;
        private System.Windows.Forms.PictureBox programicon;
        private System.Windows.Forms.Label formtoaltlabel;
        private System.Windows.Forms.Label formtoexitlabel;
        private System.Windows.Forms.Label controllabel;
    }
}