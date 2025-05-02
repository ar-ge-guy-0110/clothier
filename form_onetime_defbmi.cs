using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace ClothierProject
{
    public partial class form_onetime_defbmi : Form
    {
        SqlConnection conn = class_dbconnections.connect;

        int heightboxdirty;
        int weightboxdirty;

        Form formref1;
        Form mainform;

        public form_onetime_defbmi()
        {
            InitializeComponent();
        }

        private void form_onetime_defbmi_Load(object sender, EventArgs e)
        {
            bmishowlabel.Text = "";
            infolabel.Text = "";

            heightboxdirty = 0;
            weightboxdirty = 0;

            class_ProgramMaster.isOneTimeFormOpen = true;
        }

        private void weighttextBox_TextChanged(object sender, EventArgs e)
        {
            if (weightboxdirty == 0)
            {
                weightboxdirty = 1;
                weighttextBox.Text = "";
            }
        }

        private void heighttextBox_TextChanged(object sender, EventArgs e)
        {
            if (heightboxdirty == 0)
            {
                heightboxdirty = 1;
                heighttextBox.Text = "";
            }
        }

        private void weighttextBox_Click(object sender, EventArgs e)
        {
            {
                weightboxdirty = 1;
                weighttextBox.Text = "";
            }
        }

        private void weighttextBox_MouseClick(object sender, MouseEventArgs e)
        {
            {
                weightboxdirty = 1;
                weighttextBox.Text = "";
            }
        }

        private void heighttextBox_Click(object sender, EventArgs e)
        {
            if (heightboxdirty == 0)
            {
                heightboxdirty = 1;
                heighttextBox.Text = "";
            }
        }

        private void heighttextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (heightboxdirty == 0)
            {
                heightboxdirty = 1;
                heighttextBox.Text = "";
            }
        }

        private void weighttextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, dot, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 46 && e.KeyChar != 8))
            {
                e.Handled = true;
                return;
            }

            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void heighttextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, dot, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 46 && e.KeyChar != 8))
            {
                e.Handled = true;
                return;
            }

            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }


        //
        //
        //
        //TRANSACTIONS
        //
        //
        //


        private void insertbutton_Click(object sender, EventArgs e)
        {
            if (heightboxdirty == 1 && weightboxdirty == 1 && heighttextBox.Text != "" && weighttextBox.Text != "")
            {
                DataTable bools_user = new DataTable();
                string bools_user_sql = "SELECT isUserHasDefBmi FROM bools_user WHERE user_id = " + class_ProgramMaster.logged_user_id;
                SqlDataAdapter da = new SqlDataAdapter(bools_user_sql, conn);
                da.Fill(bools_user);


                if (Convert.ToInt32(bools_user.Rows[0][0]) == 0)
                {
                    float height = (float)Convert.ToDouble(heighttextBox.Text);
                    float weight = (float)Convert.ToDouble(weighttextBox.Text);
                    float bmi = (weight / (height * height));

                    class_ProgramMaster.user_body_mass_index = bmi;
                    //MessageBox.Show("User Bmi = " + class_ProgramMaster.user_body_mass_index);

                    SqlCommand userbmi = new SqlCommand("INSERT INTO user_body_mass_index(user_id, height, weight, bmi) VALUES(@uid, @h, @w, @bmi)", conn);
                    userbmi.Parameters.AddWithValue("@uid", SqlDbType.Int).Value = class_ProgramMaster.logged_user_id;
                    userbmi.Parameters.AddWithValue("@h", SqlDbType.Float).Value = height;
                    userbmi.Parameters.AddWithValue("@w", SqlDbType.Float).Value = weight;
                    userbmi.Parameters.AddWithValue("@bmi", SqlDbType.Float).Value = bmi;

                    conn.Open();
                    userbmi.ExecuteNonQuery();
                    conn.Close();

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


                    class_ProgramMaster.isUserHasDefBmi = true;
                    SqlCommand nowUserHasDefBmi = new SqlCommand("UPDATE bools_user SET isUserHasDefBmi = @b1 WHERE user_id = @uid", conn);
                    nowUserHasDefBmi.Parameters.AddWithValue("@b1", SqlDbType.Int).Value = 1;
                    nowUserHasDefBmi.Parameters.AddWithValue("@uid", SqlDbType.Int).Value = class_ProgramMaster.logged_user_id;

                    conn.Open();
                    nowUserHasDefBmi.ExecuteNonQuery();
                    conn.Close();

                }
                else
                {
                    float height = (float)Convert.ToDouble(heighttextBox.Text);
                    float weight = (float)Convert.ToDouble(weighttextBox.Text);
                    float bmi = (weight / (height * height));

                    class_ProgramMaster.user_body_mass_index = bmi;

                    SqlCommand userbmi = new SqlCommand("UPDATE user_body_mass_index SET height = @h, weight = @w, bmi = @bmi WHERE user_id = @uid", conn);
                    userbmi.Parameters.AddWithValue("@uid", SqlDbType.Int).Value = class_ProgramMaster.logged_user_id;
                    userbmi.Parameters.AddWithValue("@h", SqlDbType.Float).Value = height;
                    userbmi.Parameters.AddWithValue("@w", SqlDbType.Float).Value = weight;
                    userbmi.Parameters.AddWithValue("@bmi", SqlDbType.Float).Value = bmi;

                    conn.Open();
                    userbmi.ExecuteNonQuery();
                    conn.Close();

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


                class_ProgramMaster.isOneTimeFormOpen = false;

                DataTable accounts_bools1 = new DataTable();
                string accountbools1sql = "SELECT * FROM bools_user WHERE user_id = " + class_ProgramMaster.logged_user_id;
                da.SelectCommand.CommandText = accountbools1sql;
                da.Fill(accounts_bools1);

                class_ProgramMaster.isUserHasDefBmi = Convert.ToBoolean(Convert.ToInt32(accounts_bools1.Rows[0][2]));
                class_ProgramMaster.isUserHasDefBodyType = Convert.ToBoolean(Convert.ToInt32(accounts_bools1.Rows[0][3]));
                class_ProgramMaster.isUserHasDefClothingStyle = Convert.ToBoolean(Convert.ToInt32(accounts_bools1.Rows[0][4]));
                class_ProgramMaster.isUserHasDefSeason = Convert.ToBoolean(Convert.ToInt32(accounts_bools1.Rows[0][6]));
                class_ProgramMaster.isUserHasDefPlace = Convert.ToBoolean(Convert.ToInt32(accounts_bools1.Rows[0][5]));

                if (class_ProgramMaster.isUserHasDefBodyType == false && class_ProgramMaster.isOneTimeFormOpen == false)
                {
                    Form form_onetime_defBodyType = new form_onetime_defBodyType();
                    formref1 = form_onetime_defBodyType;
                    formref1.Show();
                }
                else if (class_ProgramMaster.isUserHasDefClothingStyle == false && class_ProgramMaster.isOneTimeFormOpen == false)
                {
                    Form form_onetime_defClothingStyle = new form_onetime_defClothingStyle();
                    formref1 = form_onetime_defClothingStyle;
                    formref1.Show();
                }
                else if (class_ProgramMaster.isUserHasDefSeason == false && class_ProgramMaster.isOneTimeFormOpen == false)
                {
                    Form form_onetime_defSeason = new form_onetime_defSeason();
                    formref1 = form_onetime_defSeason;
                    formref1.Show();
                }
                else if (class_ProgramMaster.isUserHasDefPlace == false && class_ProgramMaster.isOneTimeFormOpen == false)
                {
                    Form form_onetime_defPlace = new form_onetime_defPlace();
                    formref1 = form_onetime_defPlace;
                    formref1.Show();
                }
                else
                {
                    //open main...

                    form_main_clothier mainwin = (form_main_clothier)Application.OpenForms["form_main_clothier"];
                    if (mainwin != null)
                    {

                    }
                    else
                    {
                        Form form_main_clothier = new form_main_clothier();
                        formref1 = form_main_clothier;
                        formref1.Show();
                    }

                }
                this.Close();
            }
            else if (heightboxdirty == 0 && weightboxdirty == 0)
            {
                infolabel.Text = "Please enter your information.";
            }
            else
            {
                infolabel.Text = "Please enter your information correctly.";
            }


        }


    }
}
