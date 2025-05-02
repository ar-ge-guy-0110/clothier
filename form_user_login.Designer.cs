namespace ClothierProject
{
    partial class form_user_login
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_user_login));
            this.formtoaltlabel = new System.Windows.Forms.Label();
            this.formtoexitlabel = new System.Windows.Forms.Label();
            this.usernametextBox = new System.Windows.Forms.TextBox();
            this.usernameline = new System.Windows.Forms.Panel();
            this.passline = new System.Windows.Forms.Panel();
            this.passtextBox = new System.Windows.Forms.TextBox();
            this.loginbutton = new System.Windows.Forms.Button();
            this.versionlabel = new System.Windows.Forms.Label();
            this.registerlabel = new System.Windows.Forms.Label();
            this.registerslidetimer = new System.Windows.Forms.Timer(this.components);
            this.userlogincontrollabel = new System.Windows.Forms.Label();
            this.programicon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.programicon)).BeginInit();
            this.SuspendLayout();
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
            // usernametextBox
            // 
            this.usernametextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.usernametextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernametextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.usernametextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(56)))), ((int)(((byte)(255)))));
            this.usernametextBox.HideSelection = false;
            this.usernametextBox.Location = new System.Drawing.Point(100, 98);
            this.usernametextBox.MaxLength = 20;
            this.usernametextBox.Name = "usernametextBox";
            this.usernametextBox.Size = new System.Drawing.Size(200, 19);
            this.usernametextBox.TabIndex = 1;
            this.usernametextBox.Text = "Username";
            this.usernametextBox.Click += new System.EventHandler(this.usernametextBox_Click);
            this.usernametextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.usernametextBox_MouseClick);
            this.usernametextBox.TextChanged += new System.EventHandler(this.usernametextBox_TextChanged);
            // 
            // usernameline
            // 
            this.usernameline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(56)))), ((int)(((byte)(255)))));
            this.usernameline.Location = new System.Drawing.Point(100, 123);
            this.usernameline.Name = "usernameline";
            this.usernameline.Size = new System.Drawing.Size(200, 1);
            this.usernameline.TabIndex = 2;
            // 
            // passline
            // 
            this.passline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(56)))), ((int)(((byte)(255)))));
            this.passline.Location = new System.Drawing.Point(100, 165);
            this.passline.Name = "passline";
            this.passline.Size = new System.Drawing.Size(200, 1);
            this.passline.TabIndex = 4;
            // 
            // passtextBox
            // 
            this.passtextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.passtextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passtextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.passtextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(56)))), ((int)(((byte)(255)))));
            this.passtextBox.HideSelection = false;
            this.passtextBox.Location = new System.Drawing.Point(100, 140);
            this.passtextBox.MaxLength = 50;
            this.passtextBox.Name = "passtextBox";
            this.passtextBox.Size = new System.Drawing.Size(200, 19);
            this.passtextBox.TabIndex = 3;
            this.passtextBox.Text = "Password";
            this.passtextBox.Click += new System.EventHandler(this.passtextBox_Click);
            this.passtextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.passtextBox_MouseClick);
            this.passtextBox.TextChanged += new System.EventHandler(this.passtextBox_TextChanged);
            // 
            // loginbutton
            // 
            this.loginbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(56)))), ((int)(((byte)(255)))));
            this.loginbutton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.loginbutton.FlatAppearance.BorderSize = 0;
            this.loginbutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(56)))), ((int)(((byte)(255)))));
            this.loginbutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(56)))), ((int)(((byte)(255)))));
            this.loginbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.loginbutton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.loginbutton.Location = new System.Drawing.Point(100, 192);
            this.loginbutton.Name = "loginbutton";
            this.loginbutton.Size = new System.Drawing.Size(200, 30);
            this.loginbutton.TabIndex = 5;
            this.loginbutton.Text = "Log In";
            this.loginbutton.UseVisualStyleBackColor = false;
            this.loginbutton.Click += new System.EventHandler(this.loginbutton_Click);
            // 
            // versionlabel
            // 
            this.versionlabel.AutoSize = true;
            this.versionlabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.versionlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(56)))), ((int)(((byte)(255)))));
            this.versionlabel.Location = new System.Drawing.Point(12, 349);
            this.versionlabel.Name = "versionlabel";
            this.versionlabel.Size = new System.Drawing.Size(112, 14);
            this.versionlabel.TabIndex = 0;
            this.versionlabel.Text = "Clothier Version Label";
            // 
            // registerlabel
            // 
            this.registerlabel.AutoSize = true;
            this.registerlabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.registerlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(56)))), ((int)(((byte)(255)))));
            this.registerlabel.Location = new System.Drawing.Point(97, 267);
            this.registerlabel.Name = "registerlabel";
            this.registerlabel.Size = new System.Drawing.Size(208, 15);
            this.registerlabel.TabIndex = 6;
            this.registerlabel.Text = "Don\'t you have an account? Register.";
            this.registerlabel.Click += new System.EventHandler(this.registerlabel_Click);
            this.registerlabel.MouseLeave += new System.EventHandler(this.registerlabel_MouseLeave);
            this.registerlabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.registerlabel_MouseMove);
            // 
            // registerslidetimer
            // 
            this.registerslidetimer.Tick += new System.EventHandler(this.registerslidetimer_Tick);
            // 
            // userlogincontrollabel
            // 
            this.userlogincontrollabel.AutoSize = true;
            this.userlogincontrollabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.userlogincontrollabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(56)))), ((int)(((byte)(255)))));
            this.userlogincontrollabel.Location = new System.Drawing.Point(97, 225);
            this.userlogincontrollabel.Name = "userlogincontrollabel";
            this.userlogincontrollabel.Size = new System.Drawing.Size(0, 15);
            this.userlogincontrollabel.TabIndex = 7;
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
            // form_user_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(400, 375);
            this.Controls.Add(this.userlogincontrollabel);
            this.Controls.Add(this.programicon);
            this.Controls.Add(this.registerlabel);
            this.Controls.Add(this.formtoaltlabel);
            this.Controls.Add(this.versionlabel);
            this.Controls.Add(this.formtoexitlabel);
            this.Controls.Add(this.loginbutton);
            this.Controls.Add(this.passline);
            this.Controls.Add(this.passtextBox);
            this.Controls.Add(this.usernameline);
            this.Controls.Add(this.usernametextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "form_user_login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form_user_login_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.programicon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox usernametextBox;
        private System.Windows.Forms.Panel usernameline;
        private System.Windows.Forms.Panel passline;
        private System.Windows.Forms.TextBox passtextBox;
        private System.Windows.Forms.Button loginbutton;
        private System.Windows.Forms.Label versionlabel;
        private System.Windows.Forms.Label formtoaltlabel;
        private System.Windows.Forms.Label formtoexitlabel;
        private System.Windows.Forms.PictureBox programicon;
        private System.Windows.Forms.Label registerlabel;
        private System.Windows.Forms.Timer registerslidetimer;
        private System.Windows.Forms.Label userlogincontrollabel;
    }
}

