using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClothierProject
{
    public partial class form_user_data : Form
    {
        public form_user_data()
        {
            InitializeComponent();
        }

        private void form_user_data_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                class_borderlessmove.ReleaseCapture();
                class_borderlessmove.SendMessage(Handle, class_borderlessmove.WM_NCLBUTTONDOWN, class_borderlessmove.HT_CAPTION, 0);
            }
        }

        private void form_user_data_Load(object sender, EventArgs e)
        {
            label1.Text = "User: " + class_ProgramMaster.logged_user;
            if(class_ProgramMaster.logged_user_id == 5)
            {
                label1.Text = "[Admin]User: " + class_ProgramMaster.logged_user;
            }
            label2.Text = "Body Mass Index: " + class_ProgramMaster.user_body_mass_index.ToString();
            label7.Text = "Body State: " + class_ProgramMaster.user_body_mass_string.ToString();
            label3.Text = "Body Type: " + class_ProgramMaster.user_bodytype;
            label4.Text = "Clothing Style: " + class_ProgramMaster.user_clothingstyle;
            label5.Text = "Season: " + class_ProgramMaster.user_season;
            label6.Text = "Place: " + class_ProgramMaster.user_place;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                class_borderlessmove.ReleaseCapture();
                class_borderlessmove.SendMessage(Handle, class_borderlessmove.WM_NCLBUTTONDOWN, class_borderlessmove.HT_CAPTION, 0);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                class_borderlessmove.ReleaseCapture();
                class_borderlessmove.SendMessage(Handle, class_borderlessmove.WM_NCLBUTTONDOWN, class_borderlessmove.HT_CAPTION, 0);
            }
        }

        private void formtoexitlabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formtoaltlabel_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void formtoexitlabel_MouseMove(object sender, MouseEventArgs e)
        {
            formtoexitlabel.ForeColor = Color.FromArgb(180, 56, 255);
        }

        private void formtoexitlabel_MouseLeave(object sender, EventArgs e)
        {
            formtoexitlabel.ForeColor = Color.FromArgb(245, 56, 255);
        }

        private void formtoaltlabel_MouseMove(object sender, MouseEventArgs e)
        {
            formtoaltlabel.ForeColor = Color.FromArgb(180, 56, 255);
        }

        private void formtoaltlabel_MouseLeave(object sender, EventArgs e)
        {
            formtoaltlabel.ForeColor = Color.FromArgb(245, 56, 255);
        }
    }
}
