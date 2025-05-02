namespace ClothierProject
{
    partial class form_onetime_defbmi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_onetime_defbmi));
            this.programicon = new System.Windows.Forms.PictureBox();
            this.insertbutton = new System.Windows.Forms.Button();
            this.passline = new System.Windows.Forms.Panel();
            this.heighttextBox = new System.Windows.Forms.TextBox();
            this.usernameline = new System.Windows.Forms.Panel();
            this.weighttextBox = new System.Windows.Forms.TextBox();
            this.bmishowlabel = new System.Windows.Forms.Label();
            this.infolabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.programicon)).BeginInit();
            this.SuspendLayout();
            // 
            // programicon
            // 
            this.programicon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.programicon.Image = global::ClothierProject.images.dress;
            this.programicon.Location = new System.Drawing.Point(12, 12);
            this.programicon.Name = "programicon";
            this.programicon.Size = new System.Drawing.Size(19, 18);
            this.programicon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.programicon.TabIndex = 3;
            this.programicon.TabStop = false;
            // 
            // insertbutton
            // 
            this.insertbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(56)))), ((int)(((byte)(255)))));
            this.insertbutton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.insertbutton.FlatAppearance.BorderSize = 0;
            this.insertbutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(56)))), ((int)(((byte)(255)))));
            this.insertbutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(56)))), ((int)(((byte)(255)))));
            this.insertbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.insertbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.insertbutton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.insertbutton.Location = new System.Drawing.Point(94, 224);
            this.insertbutton.Name = "insertbutton";
            this.insertbutton.Size = new System.Drawing.Size(200, 30);
            this.insertbutton.TabIndex = 12;
            this.insertbutton.Text = "Insert";
            this.insertbutton.UseVisualStyleBackColor = false;
            this.insertbutton.Click += new System.EventHandler(this.insertbutton_Click);
            // 
            // passline
            // 
            this.passline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(56)))), ((int)(((byte)(255)))));
            this.passline.Location = new System.Drawing.Point(94, 164);
            this.passline.Name = "passline";
            this.passline.Size = new System.Drawing.Size(200, 1);
            this.passline.TabIndex = 11;
            // 
            // heighttextBox
            // 
            this.heighttextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.heighttextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.heighttextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.heighttextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(56)))), ((int)(((byte)(255)))));
            this.heighttextBox.HideSelection = false;
            this.heighttextBox.Location = new System.Drawing.Point(94, 139);
            this.heighttextBox.MaxLength = 50;
            this.heighttextBox.Name = "heighttextBox";
            this.heighttextBox.Size = new System.Drawing.Size(200, 19);
            this.heighttextBox.TabIndex = 10;
            this.heighttextBox.Text = "Your height in meters";
            this.heighttextBox.Click += new System.EventHandler(this.heighttextBox_Click);
            this.heighttextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.heighttextBox_MouseClick);
            this.heighttextBox.TextChanged += new System.EventHandler(this.heighttextBox_TextChanged);
            this.heighttextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.heighttextBox_KeyPress);
            // 
            // usernameline
            // 
            this.usernameline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(56)))), ((int)(((byte)(255)))));
            this.usernameline.Location = new System.Drawing.Point(94, 122);
            this.usernameline.Name = "usernameline";
            this.usernameline.Size = new System.Drawing.Size(200, 1);
            this.usernameline.TabIndex = 9;
            // 
            // weighttextBox
            // 
            this.weighttextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.weighttextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.weighttextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.weighttextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(56)))), ((int)(((byte)(255)))));
            this.weighttextBox.HideSelection = false;
            this.weighttextBox.Location = new System.Drawing.Point(94, 97);
            this.weighttextBox.MaxLength = 20;
            this.weighttextBox.Name = "weighttextBox";
            this.weighttextBox.Size = new System.Drawing.Size(200, 19);
            this.weighttextBox.TabIndex = 8;
            this.weighttextBox.Text = "Your weight in kilograms";
            this.weighttextBox.Click += new System.EventHandler(this.weighttextBox_Click);
            this.weighttextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.weighttextBox_MouseClick);
            this.weighttextBox.TextChanged += new System.EventHandler(this.weighttextBox_TextChanged);
            this.weighttextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.weighttextBox_KeyPress);
            // 
            // bmishowlabel
            // 
            this.bmishowlabel.AutoSize = true;
            this.bmishowlabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bmishowlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(56)))), ((int)(((byte)(255)))));
            this.bmishowlabel.Location = new System.Drawing.Point(151, 181);
            this.bmishowlabel.Name = "bmishowlabel";
            this.bmishowlabel.Size = new System.Drawing.Size(68, 18);
            this.bmishowlabel.TabIndex = 14;
            this.bmishowlabel.Text = "user bmi";
            this.bmishowlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // infolabel
            // 
            this.infolabel.AutoSize = true;
            this.infolabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.infolabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(56)))), ((int)(((byte)(255)))));
            this.infolabel.Location = new System.Drawing.Point(91, 257);
            this.infolabel.Name = "infolabel";
            this.infolabel.Size = new System.Drawing.Size(54, 15);
            this.infolabel.TabIndex = 15;
            this.infolabel.Text = "infolabel";
            // 
            // form_onetime_defbmi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(384, 337);
            this.Controls.Add(this.infolabel);
            this.Controls.Add(this.bmishowlabel);
            this.Controls.Add(this.insertbutton);
            this.Controls.Add(this.passline);
            this.Controls.Add(this.heighttextBox);
            this.Controls.Add(this.usernameline);
            this.Controls.Add(this.weighttextBox);
            this.Controls.Add(this.programicon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "form_onetime_defbmi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.form_onetime_defbmi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.programicon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox programicon;
        private System.Windows.Forms.Button insertbutton;
        private System.Windows.Forms.Panel passline;
        private System.Windows.Forms.TextBox heighttextBox;
        private System.Windows.Forms.Panel usernameline;
        private System.Windows.Forms.TextBox weighttextBox;
        private System.Windows.Forms.Label bmishowlabel;
        private System.Windows.Forms.Label infolabel;
    }
}