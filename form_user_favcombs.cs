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
    public partial class form_user_favcombs : Form
    {
        SqlConnection conn = class_dbconnections.connect;
        public form_user_favcombs()
        {
            InitializeComponent();
        }

        private void form_user_favcombs_Load(object sender, EventArgs e)
        {
            list1();
        }

        private void list1()
        {
            DataTable user_outfit_combination = new DataTable();
            string fetchcomb = @"SELECT user_outfit_combination.id, user_outfit_combination.dress_slot, cloth_image.image, 
            user_outfit_combination.topwear_slot, cloth_image2.image, 
            user_outfit_combination.bottomwear_slot, cloth_image3.image, 
            user_outfit_combination.shoe_slot, cloth_image4.image, 
            user_outfit_combination.bag_slot, cloth_image5.image, user_outfit_combination.combination_name 
            FROM user_outfit_combination 
            LEFT JOIN cloth_image ON user_outfit_combination.dress_slot = cloth_image.cloth_id 
            LEFT JOIN cloth_image AS cloth_image2 ON user_outfit_combination.topwear_slot = cloth_image2.cloth_id 
            LEFT JOIN cloth_image AS cloth_image3 ON user_outfit_combination.bottomwear_slot = cloth_image3.cloth_id 
            LEFT JOIN cloth_image AS cloth_image4 ON user_outfit_combination.shoe_slot = cloth_image4.cloth_id 
            LEFT JOIN cloth_image AS cloth_image5 ON user_outfit_combination.bag_slot = cloth_image5.cloth_id 
            LEFT JOIN user_favorite_combination ON user_outfit_combination.id = user_favorite_combination.combination_id WHERE user_favorite_combination.user_id = " + class_ProgramMaster.logged_user_id;
            SqlDataAdapter da = new SqlDataAdapter(fetchcomb, conn);
            da.Fill(user_outfit_combination);

            int dtcounter = 0;
            byte[] blankimg = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mP8z/C/HgAGgwJ/lK3Q6wAAAABJRU5ErkJggg==");
            byte[] img;

            foreach (DataRow row in user_outfit_combination.Rows)
            {
                dtcounter++;
                try
                {
                    FlowLayoutPanel f = addflowlayoutcapsule(Convert.ToInt32(row[0]), "CombContainer-");
                    flowLayoutPanel1.Controls.Add(f);
                    f.DoubleClick += new System.EventHandler(this.flowDoubleClick);

                    PictureBox p1 = addpicturebox(dtcounter, "clothitem-");
                    f.Controls.Add(p1);

                    PictureBox p2 = addpicturebox(dtcounter + 1, "clothitem-");
                    f.Controls.Add(p2);

                    PictureBox p3 = addpicturebox(dtcounter + 2, "clothitem-");
                    f.Controls.Add(p3);

                    PictureBox p4 = addpicturebox(dtcounter + 3, "clothitem-");
                    f.Controls.Add(p4);

                    if (DBNull.Value.Equals(row[2]))
                    {
                        if (DBNull.Value.Equals(row[4]))
                        {
                            MemoryStream ms = new MemoryStream(blankimg);
                            p1.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {

                        img = (byte[])row[2];
                        MemoryStream ms = new MemoryStream(img);
                        p1.Image = Image.FromStream(ms);
                    }

                    if (DBNull.Value.Equals(row[4]))
                    {
                        if (DBNull.Value.Equals(row[2]))
                        {
                            MemoryStream ms = new MemoryStream(blankimg);
                            p1.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        img = (byte[])row[4];
                        MemoryStream ms = new MemoryStream(img);
                        p1.Image = Image.FromStream(ms);
                    }

                    if (DBNull.Value.Equals(row[6]))
                    {
                        MemoryStream ms = new MemoryStream(blankimg);
                        p2.Image = Image.FromStream(ms);
                    }
                    else
                    {
                        img = (byte[])row[6];
                        MemoryStream ms = new MemoryStream(img);
                        p2.Image = Image.FromStream(ms);
                    }

                    if (DBNull.Value.Equals(row[8]))
                    {
                        MemoryStream ms = new MemoryStream(blankimg);
                        p3.Image = Image.FromStream(ms);
                    }
                    else
                    {
                        img = (byte[])row[8];
                        MemoryStream ms = new MemoryStream(img);
                        p3.Image = Image.FromStream(ms);
                    }

                    if (DBNull.Value.Equals(row[10]))
                    {
                        MemoryStream ms = new MemoryStream(blankimg);
                        p4.Image = Image.FromStream(ms);
                    }
                    else
                    {
                        img = (byte[])row[10];
                        MemoryStream ms = new MemoryStream(img);
                        p4.Image = Image.FromStream(ms);
                    }

                    Label l = addlabel(dtcounter, "combname-", row[11].ToString());
                    f.Controls.Add(l);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        Label addlabel(int i, string name, string text)  // int start, int end
        {


            Label l = new Label();
            l.Name = name + i.ToString();
            l.Text = text;
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
            p.Width = 150;
            p.Height = 190;
            p.Margin = new Padding(5);

            return p;
        }


        FlowLayoutPanel addflowlayoutcapsule(int i, string name)
        {
            FlowLayoutPanel f = new FlowLayoutPanel();
            f.Width = 620;
            f.Height = 780;
            f.Name = name + i.ToString();
            f.BackColor = Color.FromArgb(30, 28, 38);
            f.Margin = new Padding(5);

            ContextMenu cm = new ContextMenu();

            MenuItem itemtokensubmenu = new MenuItem();
            itemtokensubmenu.Name = name + i;
            itemtokensubmenu.Text = "Delete Combination From Favorites";

            itemtokensubmenu.Click += new System.EventHandler(this.deleteFromFavorite);

            cm.Name = "conmenu" + name + i;
            cm.MenuItems.Add(itemtokensubmenu);

            f.ContextMenu = cm;

            return f;
        }

        void deleteFromFavorite(object sender, EventArgs e)
        {
            MenuItem currentContextMenuitem = (MenuItem)sender;

            //MessageBox.Show(currentContextMenuitem.Name);

            string submenuname = currentContextMenuitem.Name;
            int combfc_id = Convert.ToInt32(submenuname.Substring(submenuname.IndexOf("-") + 1));
            //MessageBox.Show(combfc_id.ToString());


            SqlCommand delfav = new SqlCommand("DELETE FROM user_favorite_combination WHERE combination_id = @combid", conn);
            delfav.Parameters.AddWithValue("@combid", SqlDbType.Int).Value = combfc_id;

            conn.Open();
            delfav.ExecuteNonQuery();
            conn.Close();

            List<Control> listControls = new List<Control>();

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                listControls.Add(control);
            }

            foreach (Control control in listControls)
            {
                flowLayoutPanel1.Controls.Remove(control);
                control.Dispose();
            }

            list1();

        }





        void flowDoubleClick(object sender, EventArgs e)
        {
            FlowLayoutPanel currentflow = (FlowLayoutPanel)sender;
            //MessageBox.Show(currentflow.Name);
        }

        private void formtoexitlabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formtoaltlabel_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void form_user_favcombs_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                class_borderlessmove.ReleaseCapture();
                class_borderlessmove.SendMessage(Handle, class_borderlessmove.WM_NCLBUTTONDOWN, class_borderlessmove.HT_CAPTION, 0);
            }
        }

        private void flowLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                class_borderlessmove.ReleaseCapture();
                class_borderlessmove.SendMessage(Handle, class_borderlessmove.WM_NCLBUTTONDOWN, class_borderlessmove.HT_CAPTION, 0);
            }
        }
    }
}
