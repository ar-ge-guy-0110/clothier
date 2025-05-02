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
    public partial class form_onetime_defPlace : Form
    {
        SqlConnection conn = class_dbconnections.connect;

        Form formref1;
        public form_onetime_defPlace()
        {
            InitializeComponent();
        }

        private void form_onetime_defPlace_Load(object sender, EventArgs e)
        {
            class_ProgramMaster.isOneTimeFormOpen = true;

            DataTable cloth_place_category = new DataTable();
            string fetchcp = "SELECT * FROM cloth_place_category";
            SqlDataAdapter da = new SqlDataAdapter(fetchcp, conn);
            da.Fill(cloth_place_category);

            DataTable cloth_place_image = new DataTable();

            int dtcounter = 0;

            foreach (DataRow row in cloth_place_category.Rows)
            {
                dtcounter++;
                try
                {
                    PictureBox p = addpicturebox(Convert.ToInt32(row[0]), row[1].ToString() + "-");
                    placeflowLayoutPanel1.Controls.Add(p);
                    p.DoubleClick += new System.EventHandler(this.picboxDoubleClick);


                    Label l = addlabel(dtcounter, row[1].ToString());
                    placeflowLayoutPanel1.Controls.Add(l);
                    l.DoubleClick += new System.EventHandler(this.labelDoubleClick);


                    string fetchimage = "SELECT * FROM cloth_place_image WHERE cloth_place_id = " + row[0].ToString();
                    SqlDataAdapter fida = new SqlDataAdapter(fetchimage, conn);
                    fida.Fill(cloth_place_image);
                    byte[] img = (byte[])cloth_place_image.Rows[0][2];
                    if (img != null)
                    {
                        MemoryStream ms = new MemoryStream(img);
                        p.Image = Image.FromStream(ms);
                    }
                    cloth_place_image.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //MessageBox.Show(dtcounter.ToString());
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
            string bools_user_sql = "SELECT isUserHasDefPlace FROM bools_user WHERE user_id = " + class_ProgramMaster.logged_user_id;
            SqlDataAdapter da = new SqlDataAdapter(bools_user_sql, conn);
            da.Fill(bools_user);

            if (Convert.ToInt32(bools_user.Rows[0][0]) == 0)
            {

                string picname = currentPictureBox.Name;
                int clothplaceid = Convert.ToInt32(picname.Substring(picname.IndexOf("-") + 1));
                string clothplacename = picname.Substring(0, picname.IndexOf("-"));
                class_ProgramMaster.user_place = clothplacename;
                class_ProgramMaster.user_place_id = clothplaceid;
                //MessageBox.Show("User place = " + class_ProgramMaster.user_place);
                //MessageBox.Show("User place id = " + class_ProgramMaster.user_place_id);

                SqlCommand userplace = new SqlCommand("INSERT INTO user_which_place(user_id, clothing_place_id) VALUES(@uid, @btid)", conn);
                userplace.Parameters.AddWithValue("@uid", SqlDbType.Int).Value = class_ProgramMaster.logged_user_id;
                userplace.Parameters.AddWithValue("@btid", SqlDbType.Int).Value = class_ProgramMaster.user_place_id;

                conn.Open();
                userplace.ExecuteNonQuery();
                conn.Close();



                SqlCommand nowUserHasDefPlace = new SqlCommand("UPDATE bools_user SET isUserHasDefPlace = @b5 WHERE user_id = @uid", conn);
                nowUserHasDefPlace.Parameters.AddWithValue("@b5", SqlDbType.Int).Value = 1;
                nowUserHasDefPlace.Parameters.AddWithValue("@uid", SqlDbType.Int).Value = class_ProgramMaster.logged_user_id;

                conn.Open();
                nowUserHasDefPlace.ExecuteNonQuery();
                conn.Close();
                class_ProgramMaster.isUserHasDefPlace = true;

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
                int clothplaceid = Convert.ToInt32(picname.Substring(picname.IndexOf("-") + 1));
                string clothplacename = picname.Substring(0, picname.IndexOf("-"));
                class_ProgramMaster.user_place = clothplacename;
                class_ProgramMaster.user_place_id = clothplaceid;
                //MessageBox.Show("User place = " + class_ProgramMaster.user_place);
                //MessageBox.Show("User place id = " + class_ProgramMaster.user_place_id);

                SqlCommand userplace = new SqlCommand("UPDATE user_which_place SET clothing_place_id = @btid WHERE user_id = @uid", conn);
                userplace.Parameters.AddWithValue("@uid", SqlDbType.Int).Value = class_ProgramMaster.logged_user_id;
                userplace.Parameters.AddWithValue("@btid", SqlDbType.Int).Value = class_ProgramMaster.user_place_id;

                conn.Open();
                userplace.ExecuteNonQuery();
                conn.Close();
            }
            this.Close();
        }
    }
}
