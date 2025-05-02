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
using System.IO;

namespace ClothierProject
{
    public partial class form_onetime_defSeason : Form
    {
        SqlConnection conn = class_dbconnections.connect;

        Form formref1;
        public form_onetime_defSeason()
        {
            InitializeComponent();
        }

        private void form_onetime_defSeason_Load(object sender, EventArgs e)
        {
            class_ProgramMaster.isOneTimeFormOpen = true;

            DataTable cloth_season_category = new DataTable();
            string fetchcs = "SELECT * FROM cloth_season_category";
            SqlDataAdapter da = new SqlDataAdapter(fetchcs, conn);
            da.Fill(cloth_season_category);

            DataTable cloth_season_image = new DataTable();

            int dtcounter = 0;

            foreach (DataRow row in cloth_season_category.Rows)
            {
                dtcounter++;
                try
                {
                    PictureBox p = addpicturebox(Convert.ToInt32(row[0]), row[1].ToString() + "-");
                    seasonflowLayoutPanel1.Controls.Add(p);
                    p.DoubleClick += new System.EventHandler(this.picboxDoubleClick);


                    Label l = addlabel(dtcounter, row[1].ToString());
                    seasonflowLayoutPanel1.Controls.Add(l);
                    l.DoubleClick += new System.EventHandler(this.labelDoubleClick);


                    string fetchimage = "SELECT * FROM cloth_season_image WHERE cloth_season_id = " + row[0].ToString();
                    SqlDataAdapter fida = new SqlDataAdapter(fetchimage, conn);
                    fida.Fill(cloth_season_image);
                    byte[] img = (byte[])cloth_season_image.Rows[0][2];
                    if (img != null)
                    {
                        MemoryStream ms = new MemoryStream(img);
                        p.Image = Image.FromStream(ms);
                    }
                    cloth_season_image.Clear();
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
            string bools_user_sql = "SELECT isUserHasDefSeason FROM bools_user WHERE user_id = " + class_ProgramMaster.logged_user_id;
            SqlDataAdapter da = new SqlDataAdapter(bools_user_sql, conn);
            da.Fill(bools_user);

            if (Convert.ToInt32(bools_user.Rows[0][0]) == 0)
            {

                string picname = currentPictureBox.Name;
                int clothseasonid = Convert.ToInt32(picname.Substring(picname.IndexOf("-") + 1));
                string clothseasonname = picname.Substring(0, picname.IndexOf("-"));
                class_ProgramMaster.user_season = clothseasonname;
                class_ProgramMaster.user_season_id = clothseasonid;
                //MessageBox.Show("User season = " + class_ProgramMaster.user_season);
                //MessageBox.Show("User season id = " + class_ProgramMaster.user_season_id);

                SqlCommand userseason = new SqlCommand("INSERT INTO user_which_season(user_id, clothing_season_id) VALUES(@uid, @btid)", conn);
                userseason.Parameters.AddWithValue("@uid", SqlDbType.Int).Value = class_ProgramMaster.logged_user_id;
                userseason.Parameters.AddWithValue("@btid", SqlDbType.Int).Value = class_ProgramMaster.user_season_id;

                conn.Open();
                userseason.ExecuteNonQuery();
                conn.Close();



                SqlCommand nowUserHasDefSeason = new SqlCommand("UPDATE bools_user SET isUserHasDefSeason = @b4 WHERE user_id = @uid", conn);
                nowUserHasDefSeason.Parameters.AddWithValue("@b4", SqlDbType.Int).Value = 1;
                nowUserHasDefSeason.Parameters.AddWithValue("@uid", SqlDbType.Int).Value = class_ProgramMaster.logged_user_id;

                conn.Open();
                nowUserHasDefSeason.ExecuteNonQuery();
                conn.Close();
                class_ProgramMaster.isUserHasDefSeason = true;

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
                int clothseasonid = Convert.ToInt32(picname.Substring(picname.IndexOf("-") + 1));
                string clothseasonname = picname.Substring(0, picname.IndexOf("-"));
                class_ProgramMaster.user_season = clothseasonname;
                class_ProgramMaster.user_season_id = clothseasonid;
                //MessageBox.Show("User season = " + class_ProgramMaster.user_season);
                //MessageBox.Show("User season id = " + class_ProgramMaster.user_season_id);

                SqlCommand userseason = new SqlCommand("UPDATE user_which_season SET clothing_season_id = @btid WHERE user_id = @uid", conn);
                userseason.Parameters.AddWithValue("@uid", SqlDbType.Int).Value = class_ProgramMaster.logged_user_id;
                userseason.Parameters.AddWithValue("@btid", SqlDbType.Int).Value = class_ProgramMaster.user_season_id;

                conn.Open();
                userseason.ExecuteNonQuery();
                conn.Close();
            }
            this.Close();
        }
    }
}
