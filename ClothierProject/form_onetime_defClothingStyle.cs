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
using System.IO;

namespace ClothierProject
{
    public partial class form_onetime_defClothingStyle : Form
    {
        SqlConnection conn = class_dbconnections.connect;

        Form formref1;
        public form_onetime_defClothingStyle()
        {
            InitializeComponent();
        }

        private void form_onetime_defClothingStyle_Load(object sender, EventArgs e)
        {
            class_ProgramMaster.isOneTimeFormOpen = true;

            DataTable cloth_clothingstyle_category = new DataTable();
            string fetchcs = "SELECT * FROM cloth_clothingstyle_category";
            SqlDataAdapter da = new SqlDataAdapter(fetchcs, conn);
            da.Fill(cloth_clothingstyle_category);

            DataTable clothing_style_image = new DataTable();

            int dtcounter = 0;

            foreach (DataRow row in cloth_clothingstyle_category.Rows)
            {
                dtcounter++;
                try
                {
                    PictureBox p = addpicturebox(Convert.ToInt32(row[0]), row[1].ToString() + "-");
                    clothingstyleflowLayoutPanel1.Controls.Add(p);
                    p.DoubleClick += new System.EventHandler(this.picboxDoubleClick);


                    Label l = addlabel(dtcounter, row[1].ToString());
                    clothingstyleflowLayoutPanel1.Controls.Add(l);
                    l.DoubleClick += new System.EventHandler(this.labelDoubleClick);


                    string fetchimage = "SELECT * FROM clothing_style_image WHERE clothing_style_id = " + row[0].ToString();
                    SqlDataAdapter fida = new SqlDataAdapter(fetchimage, conn);
                    fida.Fill(clothing_style_image);
                    byte[] img = (byte[])clothing_style_image.Rows[0][2];
                    if (img != null)
                    {
                        MemoryStream ms = new MemoryStream(img);
                        p.Image = Image.FromStream(ms);
                    }
                    clothing_style_image.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        Label addlabel(int i, string name)  // int start, int end
        {


            Label l = new Label();
            l.Name = "genericlabel" + i.ToString();
            l.Text = name;
            l.TextAlign = ContentAlignment.BottomCenter;
            l.ForeColor = Color.FromArgb(252, 160, 0);
            l.BackColor = Color.FromArgb(30, 28, 38);
            l.Font = new Font("Arial", 12, FontStyle.Regular);
            l.ImageAlign = ContentAlignment.TopCenter;
            l.Width = 150;
            l.Height = 20;
            //l.Location = new Point(start, end);
            l.Margin = new Padding(5);



            return l;
        }

        PictureBox addpicturebox(int i, string name)
        {
            PictureBox p = new PictureBox();
            p.SizeMode = PictureBoxSizeMode.StretchImage;
            p.Name = name + i.ToString();
            p.BackColor = Color.FromArgb(30, 28, 38);
            p.Width = 200;
            p.Height = 200;
            p.Margin = new Padding(5);

            return p;
        }

        void labelDoubleClick(object sender, EventArgs e)
        {
            Label currentLabel = (Label)sender;
            //MessageBox.Show(currentLabel.Text);
        }

        void picboxDoubleClick(object sender, EventArgs e)
        {
            PictureBox currentPictureBox = (PictureBox)sender;
            //MessageBox.Show(currentPictureBox.Name);

            DataTable bools_user = new DataTable();
            string bools_user_sql = "SELECT isUserHasDefClothingStyle FROM bools_user WHERE user_id = " + class_ProgramMaster.logged_user_id;
            SqlDataAdapter da = new SqlDataAdapter(bools_user_sql, conn);
            da.Fill(bools_user);

            if (Convert.ToInt32(bools_user.Rows[0][0]) == 0)
            {

                string picname = currentPictureBox.Name;
                int clothingstyleid = Convert.ToInt32(picname.Substring(picname.IndexOf("-") + 1));
                string clothingstylename = picname.Substring(0, picname.IndexOf("-"));
                class_ProgramMaster.user_clothingstyle = clothingstylename;
                class_ProgramMaster.user_clothingstyle_id = clothingstyleid;
                //MessageBox.Show("User clothing style = " + class_ProgramMaster.user_clothingstyle);
                //MessageBox.Show("User clothing style id = " + class_ProgramMaster.user_clothingstyle_id);

                SqlCommand userclothingstyle = new SqlCommand("INSERT INTO user_which_clothingstyle(user_id, clothingstyle_id) VALUES(@uid, @btid)", conn);
                userclothingstyle.Parameters.AddWithValue("@uid", SqlDbType.Int).Value = class_ProgramMaster.logged_user_id;
                userclothingstyle.Parameters.AddWithValue("@btid", SqlDbType.Int).Value = class_ProgramMaster.user_clothingstyle_id;

                conn.Open();
                userclothingstyle.ExecuteNonQuery();
                conn.Close();



                SqlCommand nowUserHasDefClothingStyle = new SqlCommand("UPDATE bools_user SET isUserHasDefClothingStyle = @b3 WHERE user_id = @uid", conn);
                nowUserHasDefClothingStyle.Parameters.AddWithValue("@b3", SqlDbType.Int).Value = 1;
                nowUserHasDefClothingStyle.Parameters.AddWithValue("@uid", SqlDbType.Int).Value = class_ProgramMaster.logged_user_id;

                conn.Open();
                nowUserHasDefClothingStyle.ExecuteNonQuery();
                conn.Close();
                class_ProgramMaster.isUserHasDefClothingStyle = true;

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

                if (class_ProgramMaster.isUserHasDefBmi == false && class_ProgramMaster.isOneTimeFormOpen == false)
                {
                    Form form_onetime_defbmi = new form_onetime_defbmi();
                    formref1 = form_onetime_defbmi;
                    formref1.Show();
                }
                else if (class_ProgramMaster.isUserHasDefBodyType == false && class_ProgramMaster.isOneTimeFormOpen == false)
                {
                    Form form_onetime_defBodyType = new form_onetime_defBodyType();
                    formref1 = form_onetime_defBodyType;
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
            }
            else
            {
                string picname = currentPictureBox.Name;
                int clothingstyleid = Convert.ToInt32(picname.Substring(picname.IndexOf("-") + 1));
                string clothingstylename = picname.Substring(0, picname.IndexOf("-"));
                class_ProgramMaster.user_clothingstyle = clothingstylename;
                class_ProgramMaster.user_clothingstyle_id = clothingstyleid;
                //MessageBox.Show("User clothing style = " + class_ProgramMaster.user_clothingstyle);
                //MessageBox.Show("User clothing style id = " + class_ProgramMaster.user_clothingstyle_id);

                SqlCommand userclothingstyle = new SqlCommand("UPDATE user_which_clothingstyle SET clothingstyle_id = @btid WHERE user_id = @uid", conn);
                userclothingstyle.Parameters.AddWithValue("@uid", SqlDbType.Int).Value = class_ProgramMaster.logged_user_id;
                userclothingstyle.Parameters.AddWithValue("@btid", SqlDbType.Int).Value = class_ProgramMaster.user_clothingstyle_id;

                conn.Open();
                userclothingstyle.ExecuteNonQuery();
                conn.Close();
            }

            this.Close();
        }
    }
}
