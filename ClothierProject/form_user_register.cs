using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace ClothierProject
{
    public partial class form_user_register : Form
    {
        SqlConnection conn = class_dbconnections.connect;

        int unameboxdirty;
        int passboxdirty;

        public form_user_register()
        {
            InitializeComponent();
        }

        private void form_user_register_Load(object sender, EventArgs e)
        {
            unameboxdirty = 0;
            passboxdirty = 0;

            form_user_login mainwin = (form_user_login)Application.OpenForms["form_user_login"];
            mainwin.isFormOpen_userRegister = true;
        }

        private void formtoexitlabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formtoaltlabel_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void usernametextBox_Click(object sender, EventArgs e)
        {
            if (unameboxdirty == 0)
            {
                unameboxdirty = 1;
                usernametextBox.Text = "";
            }
        }

        private void passtextBox_Click(object sender, EventArgs e)
        {
            if (passboxdirty == 0)
            {
                passboxdirty = 1;
                passtextBox.Text = "";
                passtextBox.PasswordChar = '*';
            }
        }

        private void usernametextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (unameboxdirty == 0)
            {
                unameboxdirty = 1;
                usernametextBox.Text = "";
            }
        }

        private void passtextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (passboxdirty == 0)
            {
                passboxdirty = 1;
                passtextBox.Text = "";
                passtextBox.PasswordChar = '*';
            }
        }

        private void usernametextBox_TextChanged(object sender, EventArgs e)
        {
            if (unameboxdirty == 0)
            {
                unameboxdirty = 1;
                usernametextBox.Text = "";
            }
        }

        private void passtextBox_TextChanged(object sender, EventArgs e)
        {
            if (passboxdirty == 0)
            {
                passboxdirty = 1;
                passtextBox.Text = "";
                passtextBox.PasswordChar = '*';
            }
        }

        private void form_user_register_FormClosed(object sender, FormClosedEventArgs e)
        {
            form_user_login mainwin = (form_user_login)Application.OpenForms["form_user_login"];
            mainwin.isFormOpen_userRegister = false;
        }

        private void formtoexitlabel_MouseMove(object sender, MouseEventArgs e)
        {
            formtoexitlabel.ForeColor = Color.FromArgb(180, 56, 255);
        }

        private void formtoaltlabel_MouseMove(object sender, MouseEventArgs e)
        {
            formtoaltlabel.ForeColor = Color.FromArgb(180, 56, 255);
        }

        private void formtoexitlabel_MouseLeave(object sender, EventArgs e)
        {
            formtoexitlabel.ForeColor = Color.FromArgb(245, 56, 255);
        }

        private void formtoaltlabel_MouseLeave(object sender, EventArgs e)
        {
            formtoaltlabel.ForeColor = Color.FromArgb(245, 56, 255);
        }

        private void form_user_register_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                class_borderlessmove.ReleaseCapture();
                class_borderlessmove.SendMessage(Handle, class_borderlessmove.WM_NCLBUTTONDOWN, class_borderlessmove.HT_CAPTION, 0);
            }
        }


        //
        //
        //
        //TRANSACTIONS
        //
        //
        //

        private void registerbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (usernametextBox.Text != "" && passtextBox.Text != "" && unameboxdirty == 1 && passboxdirty == 1 && usernametextBox.Text.Length >= 4)
                {
                    DataTable accounts = new DataTable();
                    string sql = "SELECT username, password FROM user_account WHERE username = N'" + usernametextBox.Text + "'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.Fill(accounts);

                    if (accounts.Rows.Count == 0)
                    {
                        int registered_user_id;

                        SqlCommand add = new SqlCommand("INSERT INTO user_account(username, password) VALUES(@uname, @pass) SELECT SCOPE_IDENTITY()", conn);
                        add.Parameters.AddWithValue("@uname", SqlDbType.NVarChar).Value = usernametextBox.Text;
                        add.Parameters.AddWithValue("@pass", SqlDbType.NVarChar).Value = passtextBox.Text;



                        conn.Open();
                        registered_user_id = Convert.ToInt32(add.ExecuteScalar());
                        conn.Close();

                        SqlCommand addbools_user = new SqlCommand("INSERT INTO bools_user(user_id, isUserHasDefBmi, isUserHasDefBodyType, isUserHasDefClothingStyle, isUserHasDefPlace, isUserHasDefSeason) VALUES(@uid, @b1, @b2, @b3, @b4, @b5)", conn);
                        addbools_user.Parameters.AddWithValue("@uid", SqlDbType.Int).Value = registered_user_id;
                        addbools_user.Parameters.AddWithValue("@b1", SqlDbType.Int).Value = 0;
                        addbools_user.Parameters.AddWithValue("@b2", SqlDbType.Int).Value = 0;
                        addbools_user.Parameters.AddWithValue("@b3", SqlDbType.Int).Value = 0;
                        addbools_user.Parameters.AddWithValue("@b4", SqlDbType.Int).Value = 0;
                        addbools_user.Parameters.AddWithValue("@b5", SqlDbType.Int).Value = 0;

                        conn.Open();
                        addbools_user.ExecuteNonQuery();
                        conn.Close();

                        controllabel.Text = "Registration Successful.";
                    }
                    else
                    {
                        controllabel.Text = "This user name has already in use!";
                    }


                }
                else
                {
                    controllabel.Text = "Please enter your user information!";
                    if (usernametextBox.Text.Length < 4 && unameboxdirty == 1)
                    {
                        controllabel.Text = "User name must be at least four character length!";
                    }
                }
            }
            catch
            {
                MessageBox.Show("There was an error.. Please retry for another time.");
            }
            
        }


    }
}
