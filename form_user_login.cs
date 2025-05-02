using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClothierProject
{
    public partial class form_user_login : Form
    {
        SqlConnection conn = class_dbconnections.connect;

        int unameboxdirty;
        int passboxdirty;

        Form childwinn; //form_user_register
        Form formref1;

        public bool isFormOpen_userRegister { get; set; }

        public bool registerslidetimer_isRunning { get; set; }

        public form_user_login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            versionlabel.Text = class_ProgramMaster.name + " " + class_ProgramMaster.version;
            unameboxdirty = 0;
            passboxdirty = 0;

            isFormOpen_userRegister = false;

            registerslidetimer_isRunning = false;

            class_ProgramMaster.core_login_form = this;
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
            if(unameboxdirty == 0)
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


        private void registerlabel_MouseLeave(object sender, EventArgs e)
        {
            registerlabel.ForeColor = Color.FromArgb(245, 56, 255);
        }

        private void registerlabel_Click(object sender, EventArgs e)
        {
            if (isFormOpen_userRegister == false && registerslidetimer_isRunning == false)
            {
                Form form_user_register = new form_user_register();
                childwinn = form_user_register;
                form_user_register.Location = this.Location;

                childwinn.Show();
                registerslidetimer.Start();
                registerslidetimer_isRunning = true;

                childwinn.TopMost = false;
            }
        }

        private void registerslidetimer_Tick(object sender, EventArgs e)
        {

            childwinn.Left += 240;

            if(childwinn.Location.X >= this.Location.X + 480)
            {
                registerslidetimer.Stop();
                registerslidetimer_isRunning = false;
                childwinn.TopMost = true;

            }
        }

        private void form_user_login_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                class_borderlessmove.ReleaseCapture();
                class_borderlessmove.SendMessage(Handle, class_borderlessmove.WM_NCLBUTTONDOWN, class_borderlessmove.HT_CAPTION, 0);
            }
        }

        private void registerlabel_MouseMove(object sender, MouseEventArgs e)
        {
            registerlabel.ForeColor = Color.FromArgb(180, 56, 255);
        }

        private void formtoexitlabel_MouseMove(object sender, MouseEventArgs e)
        {
            formtoexitlabel.ForeColor = Color.FromArgb(180, 56, 255);
        }

        private void formtoaltlabel_MouseMove(object sender, MouseEventArgs e)
        {
            formtoaltlabel.ForeColor = Color.FromArgb(180, 56, 255);
        }

        private void formtoaltlabel_MouseLeave(object sender, EventArgs e)
        {
            formtoaltlabel.ForeColor = Color.FromArgb(245, 56, 255);
        }

        private void formtoexitlabel_MouseLeave(object sender, EventArgs e)
        {
            formtoexitlabel.ForeColor = Color.FromArgb(245, 56, 255);
        }


        //
        //
        //
        //TRANSACTIONS
        //
        //
        //

        private void loginbutton_Click(object sender, EventArgs e)
        {
            if(unameboxdirty == 1 && passboxdirty == 1 && usernametextBox.Text != "" && passtextBox.Text != "")
            {


                DataTable accounts = new DataTable();


                string sql = "SELECT id, username, password FROM user_account WHERE username = N'" + usernametextBox.Text + "'" + " AND" + " password = N'" + passtextBox.Text + "'";
                
                
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(accounts);
                

                
                if(accounts.Rows.Count == 1)
                {
                    this.Hide();
                    userlogincontrollabel.Text = "";
                    class_ProgramMaster.logged_user = accounts.Rows[0][1].ToString();
                    class_ProgramMaster.logged_user_id = Convert.ToInt32(accounts.Rows[0][0]);
                    

                    DataTable accounts_bools1 = new DataTable();
                    string accountbools1sql = "SELECT * FROM bools_user WHERE user_id = " + class_ProgramMaster.logged_user_id;
                    da.SelectCommand.CommandText = accountbools1sql;
                    da.Fill(accounts_bools1);

                    class_ProgramMaster.isUserHasDefBmi = Convert.ToBoolean(Convert.ToInt32(accounts_bools1.Rows[0][2]));
                    class_ProgramMaster.isUserHasDefBodyType = Convert.ToBoolean(Convert.ToInt32(accounts_bools1.Rows[0][3]));
                    class_ProgramMaster.isUserHasDefClothingStyle = Convert.ToBoolean(Convert.ToInt32(accounts_bools1.Rows[0][4]));
                    class_ProgramMaster.isUserHasDefSeason = Convert.ToBoolean(Convert.ToInt32(accounts_bools1.Rows[0][6]));
                    class_ProgramMaster.isUserHasDefPlace = Convert.ToBoolean(Convert.ToInt32(accounts_bools1.Rows[0][5]));

                    //insert user's defaults
                    DataTable userinfo = new DataTable();
                    string userfetchinfosql = @"SELECT user_body_mass_index.bmi, 
                    body_type.body_type_name, body_type.id, 
                    cloth_clothingstyle_category.category_name, cloth_clothingstyle_category.id, 
                    cloth_season_category.category_name, cloth_season_category.id,
                    cloth_place_category.category_name, cloth_place_category.id FROM user_body_mass_index 
                    JOIN user_account ON user_body_mass_index.user_id = user_account.id 
                    JOIN user_which_body_type ON user_account.id = user_which_body_type.user_id JOIN body_type ON user_which_body_type.body_type_id = body_type.id 
                    JOIN user_which_clothingstyle ON user_account.id = user_which_clothingstyle.user_id JOIN cloth_clothingstyle_category ON user_which_clothingstyle.clothingstyle_id = cloth_clothingstyle_category.id 
                    JOIN user_which_season ON user_account.id = user_which_season.user_id JOIN cloth_season_category ON user_which_season.clothing_season_id = cloth_season_category.id 
                    JOIN user_which_place ON user_account.id = user_which_place.user_id JOIN cloth_place_category ON user_which_place.clothing_place_id = cloth_place_category.id 
                    WHERE user_account.id = " + class_ProgramMaster.logged_user_id;
                    SqlDataAdapter fetchinfoda = new SqlDataAdapter(userfetchinfosql, conn);
                    fetchinfoda.Fill(userinfo);

                    if(userinfo.Rows.Count != 0)
                    {
                        if (!DBNull.Value.Equals(userinfo.Rows[0][0]))
                        {
                            class_ProgramMaster.user_body_mass_index = (float)userinfo.Rows[0][0];

                            if (class_ProgramMaster.user_body_mass_index <= (float)18.5)
                            {
                                class_ProgramMaster.user_body_mass_string = "Thin";
                            }
                            else if (class_ProgramMaster.user_body_mass_index <= (float)24.99 && class_ProgramMaster.user_body_mass_index > (float)18.5)
                            {
                                class_ProgramMaster.user_body_mass_string = "Normal";
                            }
                            else if (class_ProgramMaster.user_body_mass_index <= (float)29.99 && class_ProgramMaster.user_body_mass_index > (float)24.99)
                            {
                                class_ProgramMaster.user_body_mass_string = "Fat";
                            }
                            else if (class_ProgramMaster.user_body_mass_index <= (float)39.99 && class_ProgramMaster.user_body_mass_index > (float)29.99)
                            {
                                class_ProgramMaster.user_body_mass_string = "Very Fat";
                            }
                            else if (class_ProgramMaster.user_body_mass_index > (float)39.99)
                            {
                                class_ProgramMaster.user_body_mass_string = "Obese";
                            }
                            else
                            {
                                class_ProgramMaster.user_body_mass_string = "Obese";
                            }
                        }

                        if (!DBNull.Value.Equals(userinfo.Rows[0][1]))
                        {
                            class_ProgramMaster.user_bodytype = userinfo.Rows[0][1].ToString();
                            class_ProgramMaster.user_bodytype_id = Convert.ToInt32(userinfo.Rows[0][2]);
                        }

                        if (!DBNull.Value.Equals(userinfo.Rows[0][3]))
                        {
                            class_ProgramMaster.user_clothingstyle = userinfo.Rows[0][3].ToString();
                            class_ProgramMaster.user_clothingstyle_id = Convert.ToInt32(userinfo.Rows[0][4]);
                        }

                        if (!DBNull.Value.Equals(userinfo.Rows[0][5]))
                        {
                            class_ProgramMaster.user_season = userinfo.Rows[0][5].ToString();
                            class_ProgramMaster.user_season_id = Convert.ToInt32(userinfo.Rows[0][6]);
                        }

                        if (!DBNull.Value.Equals(userinfo.Rows[0][7]))
                        {
                            class_ProgramMaster.user_place = userinfo.Rows[0][7].ToString();
                            class_ProgramMaster.user_place_id = Convert.ToInt32(userinfo.Rows[0][8]);
                        }
                    }








                    //----------------------
                    //MessageBox.Show(class_ProgramMaster.logged_user + " " + class_ProgramMaster.logged_user_id + "\n" + class_ProgramMaster.user_body_mass_index + "\n" + class_ProgramMaster.user_bodytype + " " + class_ProgramMaster.user_bodytype_id + "\n" + class_ProgramMaster.user_clothingstyle + " " + class_ProgramMaster.user_clothingstyle_id + "\n" + class_ProgramMaster.user_season + " " + class_ProgramMaster.user_season_id + "\n" + class_ProgramMaster.user_place + " " + class_ProgramMaster.user_place_id);

                    if (class_ProgramMaster.isUserHasDefBmi == false && class_ProgramMaster.isOneTimeFormOpen == false)
                    {
                        Form form_onetime_defbmi = new form_onetime_defbmi();
                        formref1 = form_onetime_defbmi;
                        formref1.Show();
                    }
                    else if(class_ProgramMaster.isUserHasDefBodyType == false && class_ProgramMaster.isOneTimeFormOpen == false)
                    {
                        Form form_onetime_defBodyType = new form_onetime_defBodyType();
                        formref1 = form_onetime_defBodyType;
                        formref1.Show();
                    }
                    else if(class_ProgramMaster.isUserHasDefClothingStyle == false && class_ProgramMaster.isOneTimeFormOpen == false)
                    {
                        Form form_onetime_defClothingStyle = new form_onetime_defClothingStyle();
                        formref1 = form_onetime_defClothingStyle;
                        formref1.Show();
                    }
                    else if(class_ProgramMaster.isUserHasDefSeason == false && class_ProgramMaster.isOneTimeFormOpen == false)
                    {
                        Form form_onetime_defSeason = new form_onetime_defSeason();
                        formref1 = form_onetime_defSeason;
                        formref1.Show();
                    }
                    else if(class_ProgramMaster.isUserHasDefPlace == false && class_ProgramMaster.isOneTimeFormOpen == false)
                    {
                        Form form_onetime_defPlace = new form_onetime_defPlace();
                        formref1 = form_onetime_defPlace;
                        formref1.Show();
                    }
                    else
                    {
                        //open main...


                        Form form_main_clothier = new form_main_clothier();
                        formref1 = form_main_clothier;
                        formref1.Show();
                    }


                    //if developer log in..
                    if(class_ProgramMaster.logged_user_id == 5)
                    {
                        //devtools
                        Form devtoolsimageinserter = new devhelper_form_imageinserter();
                        devtoolsimageinserter.Show();

                        Form devtoolsclothdefiner = new devhelper_form_clothdefiner();
                        devtoolsclothdefiner.Show();
                    }
                }
                else
                {
                    userlogincontrollabel.Text = "There is no such account here, sorry :<";
                }


            }
            else if(unameboxdirty == 0 && passboxdirty == 0)
            {
                userlogincontrollabel.Text = "Please enter your user information!";
            }
            else
            {
                userlogincontrollabel.Text = "Please enter your user information correctly!";
            }
        }


    }
}
