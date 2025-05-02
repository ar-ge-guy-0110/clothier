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
    public partial class form_onetime_defBodyType : Form
    {
        SqlConnection conn = class_dbconnections.connect;

        Form formref1;

        public form_onetime_defBodyType()
        {
            InitializeComponent();
        }

        private void form_onetime_defBodyType_Load(object sender, EventArgs e)
        {
            class_ProgramMaster.isOneTimeFormOpen = true;

            //int startPosition = 100;
            //int endPosition = 50;

            DataTable body_type = new DataTable();
            string fetchbt = "SELECT * FROM body_type";
            SqlDataAdapter da = new SqlDataAdapter(fetchbt, conn);
            da.Fill(body_type);

            DataTable body_type_image = new DataTable();


            int dtcounter = 0;
            foreach (DataRow row in body_type.Rows)
            {
                dtcounter++;
                try
                {
                    PictureBox p = addpicturebox(Convert.ToInt32(row[0]), row[1].ToString() + "-");
                    bodytypeflowLayoutPanel1.Controls.Add(p);
                    p.DoubleClick += new System.EventHandler(this.picboxDoubleClick);


                    Label l = addlabel(dtcounter, row[1].ToString());
                    bodytypeflowLayoutPanel1.Controls.Add(l);
                    l.DoubleClick += new System.EventHandler(this.labelDoubleClick);


                    string fetchimage = "SELECT * FROM body_type_image WHERE body_type_id = " + row[0].ToString();
                    SqlDataAdapter fida = new SqlDataAdapter(fetchimage, conn);
                    fida.Fill(body_type_image);
                    byte[] img = (byte[])body_type_image.Rows[0][2];
                    if (img != null)
                    {
                        MemoryStream ms = new MemoryStream(img);
                        p.Image = Image.FromStream(ms);
                    }
                    body_type_image.Clear();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //MessageBox.Show(dtcounter.ToString());
                }
            }

            /*
            for(int i = 0; i <= 7; i++)
            {
                Label l = addlabel(i, "You are dynamically generated" + i); // int start, int end
                bodytypeflowLayoutPanel1.Controls.Add(l);
                //endPosition += 100;

                l.DoubleClick += new System.EventHandler(this.labelDoubleClick);
            }
            */
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
            string bools_user_sql = "SELECT isUserHasDefBodyType FROM bools_user WHERE user_id = " + class_ProgramMaster.logged_user_id;
            SqlDataAdapter da = new SqlDataAdapter(bools_user_sql, conn);
            da.Fill(bools_user);

            if (Convert.ToInt32(bools_user.Rows[0][0]) == 0)
            {

                string picname = currentPictureBox.Name;
                int bodyid = Convert.ToInt32(picname.Substring(picname.IndexOf("-") + 1));
                string bodytypename = picname.Substring(0, picname.IndexOf("-"));
                class_ProgramMaster.user_bodytype = bodytypename;
                class_ProgramMaster.user_bodytype_id = bodyid;
                //MessageBox.Show("User body type = " + class_ProgramMaster.user_bodytype);
                //MessageBox.Show("User body type id = " + class_ProgramMaster.user_bodytype_id);

                SqlCommand userbodytype = new SqlCommand("INSERT INTO user_which_body_type(user_id, body_type_id) VALUES(@uid, @btid)", conn);
                userbodytype.Parameters.AddWithValue("@uid", SqlDbType.Int).Value = class_ProgramMaster.logged_user_id;
                userbodytype.Parameters.AddWithValue("@btid", SqlDbType.Int).Value = class_ProgramMaster.user_bodytype_id;

                conn.Open();
                userbodytype.ExecuteNonQuery();
                conn.Close();



                SqlCommand nowUserHasDefBodyType = new SqlCommand("UPDATE bools_user SET isUserHasDefBodyType = @b2 WHERE user_id = @uid", conn);
                nowUserHasDefBodyType.Parameters.AddWithValue("@b2", SqlDbType.Int).Value = 1;
                nowUserHasDefBodyType.Parameters.AddWithValue("@uid", SqlDbType.Int).Value = class_ProgramMaster.logged_user_id;

                conn.Open();
                nowUserHasDefBodyType.ExecuteNonQuery();
                conn.Close();
                class_ProgramMaster.isUserHasDefBodyType = true;

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

                class_ProgramMaster.isOneTimeFormOpen = false;

                if (class_ProgramMaster.isUserHasDefBmi == false && class_ProgramMaster.isOneTimeFormOpen == false)
                {
                    Form form_onetime_defbmi = new form_onetime_defbmi();
                    formref1 = form_onetime_defbmi;
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
            }
            else
            {
                string picname = currentPictureBox.Name;
                int bodyid = Convert.ToInt32(picname.Substring(picname.IndexOf("-") + 1));
                string bodytypename = picname.Substring(0, picname.IndexOf("-"));
                class_ProgramMaster.user_bodytype = bodytypename;
                class_ProgramMaster.user_bodytype_id = bodyid;
                //MessageBox.Show("User body type = " + class_ProgramMaster.user_bodytype);
                //MessageBox.Show("User body type id = " + class_ProgramMaster.user_bodytype_id);

                SqlCommand userbodytype = new SqlCommand("UPDATE user_which_body_type SET body_type_id = @btid WHERE user_id = @uid", conn);
                userbodytype.Parameters.AddWithValue("@uid", SqlDbType.Int).Value = class_ProgramMaster.logged_user_id;
                userbodytype.Parameters.AddWithValue("@btid", SqlDbType.Int).Value = class_ProgramMaster.user_bodytype_id;

                conn.Open();
                userbodytype.ExecuteNonQuery();
                conn.Close();
            }
            this.Close();


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
    }
}
