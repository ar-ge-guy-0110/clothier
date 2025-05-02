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
    public partial class form_main_clothier : Form
    {
        SqlConnection conn = class_dbconnections.connect;


        public form_main_clothier()
        {
            InitializeComponent();
        }

        private void form_main_clothier_FormClosed(object sender, FormClosedEventArgs e)
        {
            form_user_login mainwin = (form_user_login)Application.OpenForms["form_user_login"];
            mainwin.Close();
        }

        private void form_main_clothier_Load(object sender, EventArgs e)
        {



            //MessageBox.Show(class_ProgramMaster.logged_user + " " + class_ProgramMaster.logged_user_id + "\n" + class_ProgramMaster.user_body_mass_index + "\n" + class_ProgramMaster.user_bodytype + " " + class_ProgramMaster.user_bodytype_id + "\n" + class_ProgramMaster.user_clothingstyle + " " + class_ProgramMaster.user_clothingstyle_id + "\n" + class_ProgramMaster.user_season + " " + class_ProgramMaster.user_season_id + "\n" + class_ProgramMaster.user_place + " " + class_ProgramMaster.user_place_id);
            //fill clothes
            DataTable cloth = new DataTable();
            //string fetchc = "SELECT * FROM cloth";
            string fetchc = @"SELECT TOP 200 
            cloth.id AS 'Cloth ID', 
            cloth.cloth_name AS 'Cloth Name', 
            cloth_category.category_name AS 'Main Category', 
            cloth_subcategory.subcategory_name AS 'Sub Category', 
            cloth_bmi_category.bmi_name AS 'BMI Category', 
            body_type.body_type_name AS 'Body Type Category', 
            cloth_clothingstyle_category.category_name AS 'Style', 
            cloth_season_category.category_name AS 'Season', 
            cloth_place_category.category_name AS 'Place'
            FROM cloth
            JOIN cloth_which_category ON cloth.id = cloth_which_category.cloth_id JOIN cloth_category ON cloth_which_category.cloth_category_id = cloth_category.id
            JOIN cloth_which_subcategory ON cloth.id = cloth_which_subcategory.cloth_id JOIN cloth_subcategory ON cloth_which_subcategory.cloth_subcategory_id = cloth_subcategory.id
            JOIN cloth_which_bmi_category ON cloth.id = cloth_which_bmi_category.cloth_id JOIN cloth_bmi_category ON cloth_which_bmi_category.cloth_bmi_category_id = cloth_bmi_category.id
            JOIN cloth_which_bodytype_category ON cloth.id = cloth_which_bodytype_category.cloth_id JOIN body_type ON cloth_which_bodytype_category.body_type_id = body_type.id
            JOIN cloth_which_clothingstyle_category ON cloth.id = cloth_which_clothingstyle_category.cloth_id JOIN cloth_clothingstyle_category ON cloth_which_clothingstyle_category.cloth_clothingstyle_category_id = cloth_clothingstyle_category.id
            JOIN cloth_which_season_category ON cloth.id = cloth_which_season_category.cloth_id JOIN cloth_season_category ON cloth_which_season_category.cloth_season_category_id = cloth_season_category.id
            JOIN cloth_which_place_category ON cloth.id = cloth_which_place_category.cloth_id JOIN cloth_place_category ON cloth_which_place_category.cloth_place_category_id = cloth_place_category.id
            WHERE cloth_bmi_category.bmi_name = '" + class_ProgramMaster.user_body_mass_string + @"'
            AND body_type.body_type_name = '" + class_ProgramMaster.user_bodytype + @"'
            AND cloth_clothingstyle_category.category_name = '" + class_ProgramMaster.user_clothingstyle + @"'
            AND cloth_season_category.category_name = '" + class_ProgramMaster.user_season + @"'
            AND cloth_place_category.category_name = '" + class_ProgramMaster.user_place + @"'";
            SqlDataAdapter da = new SqlDataAdapter(fetchc, conn);
            da.Fill(cloth);

            DataTable cloth_image = new DataTable();

            int dtcounter = 0;
            foreach (DataRow row in cloth.Rows)
            {
                dtcounter++;
                try
                {
                    //create picturebox and its label; then add controls
                    PictureBox p = addpicturebox(Convert.ToInt32(row[0]), row[1].ToString() + "-");
                    flowLayoutPanel1.Controls.Add(p);
                    p.DoubleClick += new System.EventHandler(this.picboxDoubleClick);


                    Label l = addlabel(dtcounter, row[1].ToString());
                    flowLayoutPanel1.Controls.Add(l);
                    l.DoubleClick += new System.EventHandler(this.labelDoubleClick);

                    //add picturebox image
                    string fetchimage = "SELECT * FROM cloth_image WHERE cloth_id = " + row[0].ToString();
                    SqlDataAdapter fida = new SqlDataAdapter(fetchimage, conn);
                    fida.Fill(cloth_image);
                    byte[] img;
                    if (cloth_image.Rows.Count == 0) 
                    {
                        img = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mP8z/C/HgAGgwJ/lK3Q6wAAAABJRU5ErkJggg==");
                    }
                    else
                    {
                        img = (byte[])cloth_image.Rows[0][2];
                    }

                    if (img != null)
                    {
                        MemoryStream ms = new MemoryStream(img);
                        p.Image = Image.FromStream(ms);
                    }
                    else
                    {
                        p.Image = null;
                    }
                    cloth_image.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            //fill categories
            conn.Open();
            SqlCommand comm1 = new SqlCommand("SELECT * FROM cloth_category", conn);
            SqlDataReader read1 = comm1.ExecuteReader();
            while (read1.Read())
            {
                categorydefinitioncomboBox1.Items.Add(read1["category_name"]);
            }
            conn.Close();



            conn.Open();
            SqlCommand comm3 = new SqlCommand("SELECT * FROM cloth_bmi_category", conn);
            SqlDataReader read3 = comm3.ExecuteReader();
            while (read3.Read())
            {
                bmicomboBox1.Items.Add(read3["bmi_name"]);
            }
            conn.Close();

            conn.Open();
            SqlCommand comm4 = new SqlCommand("SELECT * FROM body_type", conn);
            SqlDataReader read4 = comm4.ExecuteReader();
            while (read4.Read())
            {
                bodytypecomboBox1.Items.Add(read4["body_type_name"]);
            }
            conn.Close();

            conn.Open();
            SqlCommand comm5 = new SqlCommand("SELECT * FROM cloth_clothingstyle_category", conn);
            SqlDataReader read5 = comm5.ExecuteReader();
            while (read5.Read())
            {
                stylecomboBox1.Items.Add(read5["category_name"]);
            }
            conn.Close();

            conn.Open();
            SqlCommand comm6 = new SqlCommand("SELECT * FROM cloth_season_category", conn);
            SqlDataReader read6 = comm6.ExecuteReader();
            while (read6.Read())
            {
                seasoncomboBox1.Items.Add(read6["category_name"]);
            }
            conn.Close();

            conn.Open();
            SqlCommand comm7 = new SqlCommand("SELECT * FROM cloth_place_category", conn);
            SqlDataReader read7 = comm7.ExecuteReader();
            while (read7.Read())
            {
                placecomboBox1.Items.Add(read7["category_name"]);
            }
            conn.Close();
        }

        private void form_main_clothier_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                class_borderlessmove.ReleaseCapture();
                class_borderlessmove.SendMessage(Handle, class_borderlessmove.WM_NCLBUTTONDOWN, class_borderlessmove.HT_CAPTION, 0);
            }
        }

        //combobox transactions
        private void categorydefinitioncomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (categorydefinitioncomboBox1.SelectedIndex != -1)
            {
                int categoryid;

                DataTable idal = new DataTable();
                string idalsql = "SELECT id FROM cloth_category WHERE category_name = '" + categorydefinitioncomboBox1.SelectedItem.ToString() + "'";
                SqlDataAdapter da = new SqlDataAdapter(idalsql, conn);
                da.Fill(idal);
                categoryid = Convert.ToInt32(idal.Rows[0][0]);

                subcategorydefinitioncomboBox1.Items.Clear();
                conn.Open();
                SqlCommand comm2 = new SqlCommand("SELECT * FROM cloth_subcategory WHERE cloth_category_id = " + categoryid, conn);
                SqlDataReader read2 = comm2.ExecuteReader();
                while (read2.Read())
                {
                    subcategorydefinitioncomboBox1.Items.Add(read2["subcategory_name"]);
                }
                conn.Close();
            }
        }


        // USER PANEL

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

        private void userpanelbutton1_Click(object sender, EventArgs e)
        {
            Form userform1 = new form_onetime_defbmi();
            userform1.ShowDialog();
        }

        private void userpanelbutton2_Click(object sender, EventArgs e)
        {
            Form userform2 = new form_onetime_defBodyType();
            userform2.ShowDialog();
        }

        private void userpanelbutton3_Click(object sender, EventArgs e)
        {
            Form userform3 = new form_onetime_defClothingStyle();
            userform3.ShowDialog();
        }

        private void userpanelbutton4_Click(object sender, EventArgs e)
        {
            Form userform4 = new form_onetime_defSeason();
            userform4.ShowDialog();
        }

        private void userpanelbutton5_Click(object sender, EventArgs e)
        {
            Form userform5 = new form_onetime_defPlace();
            userform5.ShowDialog();
        }

        private void userpanelbutton6_Click(object sender, EventArgs e)
        {
            Form userform6 = new form_user_data();
            userform6.ShowDialog();
        }

        private void formtoexitlabel_Click(object sender, EventArgs e)
        {
            form_user_login mainwin = (form_user_login)Application.OpenForms["form_user_login"];
            mainwin.Close();
        }

        private void formtoaltlabel_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void userpanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                class_borderlessmove.ReleaseCapture();
                class_borderlessmove.SendMessage(Handle, class_borderlessmove.WM_NCLBUTTONDOWN, class_borderlessmove.HT_CAPTION, 0);
            }
        }




        //-----------------------------------------------------------------------------

        // ESSENTIAL FLOW LAYOUT PANEL--------------------------------------------------
        private void flowLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
                if (e.Button == MouseButtons.Left)
                {
                    class_borderlessmove.ReleaseCapture();
                    class_borderlessmove.SendMessage(Handle, class_borderlessmove.WM_NCLBUTTONDOWN, class_borderlessmove.HT_CAPTION, 0);
                }
        }

        //fill the clothes first
        Label addlabel(int i, string name)  // int id, int name
        {


            Label l = new Label();
            l.Name = name + "-" + i.ToString();
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

            ContextMenu cm = new ContextMenu();

            MenuItem itemtokensubmenu = new MenuItem();
            itemtokensubmenu.Name = name + i;
            itemtokensubmenu.Text = "Add to Combination Template";

            itemtokensubmenu.Click += new System.EventHandler(this.addToTemplate);

            cm.Name = "conmenu" + name + i;
            cm.MenuItems.Add(itemtokensubmenu);

            p.ContextMenu = cm;

            return p;
        }

        void labelDoubleClick(object sender, EventArgs e)
        {
            Label currentLabel = (Label)sender;
        }

        void picboxDoubleClick(object sender, EventArgs e)
        {
            PictureBox currentPictureBox = (PictureBox)sender;
        }

        void addToTemplate(object sender, EventArgs e)
        {
            MenuItem currentContextMenuitem = (MenuItem)sender;

            string submenuname = currentContextMenuitem.Name;
            int clothfc_id = Convert.ToInt32(submenuname.Substring(submenuname.IndexOf("-") + 1));

            class_ProgramMaster.cloth_id_for_combination = clothfc_id;

            //find this cloth's category
            DataTable whichcategory = new DataTable();
            string findcatsql = @"SELECT cloth_category.category_name, cloth_which_category.cloth_category_id FROM cloth_category 
            JOIN cloth_which_category ON cloth_which_category.cloth_category_id = cloth_category.id 
            JOIN cloth ON cloth_which_category.cloth_id = cloth.id WHERE cloth.id = " + clothfc_id;
            SqlDataAdapter da = new SqlDataAdapter(findcatsql, conn);
            da.Fill(whichcategory);
            class_ProgramMaster.cloth_maincategory_for_combination = whichcategory.Rows[0][0].ToString();
            class_ProgramMaster.cloth_maincategory_id_for_combination = Convert.ToInt32(whichcategory.Rows[0][1]);

            //then shoot the ball to adder-to-combination form
            Form adder = new form_user_adderToCombination();
            adder.ShowDialog();


        }




        //------------------------------------------------------------------------------

        // Cloth Filter Select Panel
        private void clothespanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                class_borderlessmove.ReleaseCapture();
                class_borderlessmove.SendMessage(Handle, class_borderlessmove.WM_NCLBUTTONDOWN, class_borderlessmove.HT_CAPTION, 0);
            }
        }

        private void clothpanelbutton1_Click(object sender, EventArgs e)
        {


            //FIRST FIND THE RIGHT SQL
            string search = "";


            string cmd_start = "SELECT TOP 200";
            string cmd_middle = @" cloth.id AS 'Cloth ID', 
                                cloth.cloth_name AS 'Cloth Name', 
                                cloth_category.category_name AS 'Main Category', 
                                cloth_subcategory.subcategory_name AS 'Sub Category', 
                                cloth_bmi_category.bmi_name AS 'BMI Category', 
                                body_type.body_type_name AS 'Body Type Category', 
                                cloth_clothingstyle_category.category_name AS 'Style', 
                                cloth_season_category.category_name AS 'Season', 
                                cloth_place_category.category_name AS 'Place' ";
            string cmd_end = @"FROM cloth 
                             JOIN cloth_which_category ON cloth.id = cloth_which_category.cloth_id JOIN cloth_category ON cloth_which_category.cloth_category_id = cloth_category.id
                             JOIN cloth_which_subcategory ON cloth.id = cloth_which_subcategory.cloth_id JOIN cloth_subcategory ON cloth_which_subcategory.cloth_subcategory_id = cloth_subcategory.id
                             JOIN cloth_which_bmi_category ON cloth.id = cloth_which_bmi_category.cloth_id JOIN cloth_bmi_category ON cloth_which_bmi_category.cloth_bmi_category_id = cloth_bmi_category.id
                             JOIN cloth_which_bodytype_category ON cloth.id = cloth_which_bodytype_category.cloth_id JOIN body_type ON cloth_which_bodytype_category.body_type_id = body_type.id
                             JOIN cloth_which_clothingstyle_category ON cloth.id = cloth_which_clothingstyle_category.cloth_id JOIN cloth_clothingstyle_category ON cloth_which_clothingstyle_category.cloth_clothingstyle_category_id = cloth_clothingstyle_category.id
                             JOIN cloth_which_season_category ON cloth.id = cloth_which_season_category.cloth_id JOIN cloth_season_category ON cloth_which_season_category.cloth_season_category_id = cloth_season_category.id
                             JOIN cloth_which_place_category ON cloth.id = cloth_which_place_category.cloth_id JOIN cloth_place_category ON cloth_which_place_category.cloth_place_category_id = cloth_place_category.id WHERE";

            int cmdend_length = cmd_end.Length;

            if (clothnametextBox.Text != "")
            {
                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " cloth.cloth_name LIKE '%" + clothnametextBox.Text + "%'";
            }

            if (categorydefinitioncomboBox1.SelectedIndex != -1)
            {

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " cloth_category.category_name LIKE '%" + categorydefinitioncomboBox1.SelectedItem.ToString() + "%'";
            }

            if (subcategorydefinitioncomboBox1.SelectedIndex != -1)
            {

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " cloth_subcategory.subcategory_name LIKE '%" + subcategorydefinitioncomboBox1.SelectedItem.ToString() + "%'";
            }

            if (bmicomboBox1.SelectedIndex != -1)
            {

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " cloth_bmi_category.bmi_name LIKE '%" + bmicomboBox1.SelectedItem.ToString() + "%'";
            }

            if (bodytypecomboBox1.SelectedIndex != -1)
            {

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " body_type.body_type_name LIKE '%" + bodytypecomboBox1.SelectedItem.ToString() + "%'";
            }

            if (stylecomboBox1.SelectedIndex != -1)
            {

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " cloth_clothingstyle_category.category_name LIKE '%" + stylecomboBox1.SelectedItem.ToString() + "%'";
            }

            if (seasoncomboBox1.SelectedIndex != -1)
            {

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " cloth_season_category.category_name LIKE '%" + seasoncomboBox1.SelectedItem.ToString() + "%'";
            }

            if (placecomboBox1.SelectedIndex != -1)
            {

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " cloth_place_category.category_name LIKE '%" + placecomboBox1.SelectedItem.ToString() + "%'";
            }

            search = cmd_start + cmd_middle + cmd_end;

            //THEN FILL THE PANEL WITH THIS CLOTHES

            if ((clothnametextBox.Text != "" && clothnametextBox.Text != "Cloth Name") || categorydefinitioncomboBox1.SelectedIndex != -1 || subcategorydefinitioncomboBox1.SelectedIndex != -1 || bmicomboBox1.SelectedIndex != -1 || bodytypecomboBox1.SelectedIndex != -1 || stylecomboBox1.SelectedIndex != -1 || seasoncomboBox1.SelectedIndex != -1 || placecomboBox1.SelectedIndex != -1)
            {

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

                DataTable cloth = new DataTable();
                string fetchc = search;
                SqlDataAdapter da = new SqlDataAdapter(fetchc, conn);
                da.Fill(cloth);

                DataTable cloth_image = new DataTable();

                int dtcounter = 0;
                foreach (DataRow row in cloth.Rows)
                {
                    dtcounter++;
                    try
                    {
                        PictureBox p = addpicturebox(Convert.ToInt32(row[0]), row[1].ToString() + "-");
                        flowLayoutPanel1.Controls.Add(p);
                        p.DoubleClick += new System.EventHandler(this.picboxDoubleClick);


                        Label l = addlabel(dtcounter, row[1].ToString());
                        flowLayoutPanel1.Controls.Add(l);
                        l.DoubleClick += new System.EventHandler(this.labelDoubleClick);


                        string fetchimage = "SELECT * FROM cloth_image WHERE cloth_id = " + row[0].ToString();
                        SqlDataAdapter fida = new SqlDataAdapter(fetchimage, conn);
                        fida.Fill(cloth_image);
                        byte[] img;
                        if (cloth_image.Rows.Count == 0)
                        {
                            img = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mP8z/C/HgAGgwJ/lK3Q6wAAAABJRU5ErkJggg==");
                        }
                        else
                        {
                            img = (byte[])cloth_image.Rows[0][2];
                        }

                        if (img != null)
                        {
                            MemoryStream ms = new MemoryStream(img);
                            p.Image = Image.FromStream(ms);
                        }
                        else
                        {
                            p.Image = null;
                        }
                        cloth_image.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {

            }





        }

        private void clothpanelbutton2_Click(object sender, EventArgs e)
        {
            clothnametextBox.Text = "";

            categorydefinitioncomboBox1.SelectedIndex = -1;
            subcategorydefinitioncomboBox1.SelectedIndex = -1;
            bmicomboBox1.SelectedIndex = -1;
            bodytypecomboBox1.SelectedIndex = -1;
            stylecomboBox1.SelectedIndex = -1;
            seasoncomboBox1.SelectedIndex = -1;
            placecomboBox1.SelectedIndex = -1;
        }

        private void clothpanelbutton3_Click(object sender, EventArgs e)
        {
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

            DataTable cloth = new DataTable();
            string fetchc = "SELECT * FROM cloth";
            SqlDataAdapter da = new SqlDataAdapter(fetchc, conn);
            da.Fill(cloth);

            DataTable cloth_image = new DataTable();

            int dtcounter = 0;
            foreach (DataRow row in cloth.Rows)
            {
                dtcounter++;
                try
                {
                    PictureBox p = addpicturebox(Convert.ToInt32(row[0]), row[1].ToString() + "-");
                    flowLayoutPanel1.Controls.Add(p);
                    p.DoubleClick += new System.EventHandler(this.picboxDoubleClick);


                    Label l = addlabel(dtcounter, row[1].ToString());
                    flowLayoutPanel1.Controls.Add(l);
                    l.DoubleClick += new System.EventHandler(this.labelDoubleClick);


                    string fetchimage = "SELECT * FROM cloth_image WHERE cloth_id = " + row[0].ToString();
                    SqlDataAdapter fida = new SqlDataAdapter(fetchimage, conn);
                    fida.Fill(cloth_image);
                    byte[] img;
                    if (cloth_image.Rows.Count == 0)
                    {
                        img = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mP8z/C/HgAGgwJ/lK3Q6wAAAABJRU5ErkJggg==");
                    }
                    else
                    {
                        img = (byte[])cloth_image.Rows[0][2];
                    }

                    if (img != null)
                    {
                        MemoryStream ms = new MemoryStream(img);
                        p.Image = Image.FromStream(ms);
                    }
                    else
                    {
                        p.Image = null;
                    }
                    cloth_image.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void clothpanelbutton4_Click(object sender, EventArgs e)
        {

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

            //fill clothes
            DataTable cloth = new DataTable();
            //string fetchc = "SELECT * FROM cloth";
            string fetchc = @"SELECT TOP 200 
            cloth.id AS 'Cloth ID', 
            cloth.cloth_name AS 'Cloth Name', 
            cloth_category.category_name AS 'Main Category', 
            cloth_subcategory.subcategory_name AS 'Sub Category', 
            cloth_bmi_category.bmi_name AS 'BMI Category', 
            body_type.body_type_name AS 'Body Type Category', 
            cloth_clothingstyle_category.category_name AS 'Style', 
            cloth_season_category.category_name AS 'Season', 
            cloth_place_category.category_name AS 'Place'
            FROM cloth
            JOIN cloth_which_category ON cloth.id = cloth_which_category.cloth_id JOIN cloth_category ON cloth_which_category.cloth_category_id = cloth_category.id
            JOIN cloth_which_subcategory ON cloth.id = cloth_which_subcategory.cloth_id JOIN cloth_subcategory ON cloth_which_subcategory.cloth_subcategory_id = cloth_subcategory.id
            JOIN cloth_which_bmi_category ON cloth.id = cloth_which_bmi_category.cloth_id JOIN cloth_bmi_category ON cloth_which_bmi_category.cloth_bmi_category_id = cloth_bmi_category.id
            JOIN cloth_which_bodytype_category ON cloth.id = cloth_which_bodytype_category.cloth_id JOIN body_type ON cloth_which_bodytype_category.body_type_id = body_type.id
            JOIN cloth_which_clothingstyle_category ON cloth.id = cloth_which_clothingstyle_category.cloth_id JOIN cloth_clothingstyle_category ON cloth_which_clothingstyle_category.cloth_clothingstyle_category_id = cloth_clothingstyle_category.id
            JOIN cloth_which_season_category ON cloth.id = cloth_which_season_category.cloth_id JOIN cloth_season_category ON cloth_which_season_category.cloth_season_category_id = cloth_season_category.id
            JOIN cloth_which_place_category ON cloth.id = cloth_which_place_category.cloth_id JOIN cloth_place_category ON cloth_which_place_category.cloth_place_category_id = cloth_place_category.id
            WHERE cloth_bmi_category.bmi_name = '" + class_ProgramMaster.user_body_mass_string + @"'
            AND body_type.body_type_name = '" + class_ProgramMaster.user_bodytype + @"'
            AND cloth_clothingstyle_category.category_name = '" + class_ProgramMaster.user_clothingstyle + @"'
            AND cloth_season_category.category_name = '" + class_ProgramMaster.user_season + @"'
            AND cloth_place_category.category_name = '" + class_ProgramMaster.user_place + @"'";
            SqlDataAdapter da = new SqlDataAdapter(fetchc, conn);
            da.Fill(cloth);

            DataTable cloth_image = new DataTable();

            int dtcounter = 0;
            foreach (DataRow row in cloth.Rows)
            {
                dtcounter++;
                try
                {
                    //create picturebox and its label; then add controls
                    PictureBox p = addpicturebox(Convert.ToInt32(row[0]), row[1].ToString() + "-");
                    flowLayoutPanel1.Controls.Add(p);
                    p.DoubleClick += new System.EventHandler(this.picboxDoubleClick);


                    Label l = addlabel(dtcounter, row[1].ToString());
                    flowLayoutPanel1.Controls.Add(l);
                    l.DoubleClick += new System.EventHandler(this.labelDoubleClick);

                    //add picturebox image
                    string fetchimage = "SELECT * FROM cloth_image WHERE cloth_id = " + row[0].ToString();
                    SqlDataAdapter fida = new SqlDataAdapter(fetchimage, conn);
                    fida.Fill(cloth_image);
                    byte[] img;
                    if (cloth_image.Rows.Count == 0)
                    {
                        img = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mP8z/C/HgAGgwJ/lK3Q6wAAAABJRU5ErkJggg==");
                    }
                    else
                    {
                        img = (byte[])cloth_image.Rows[0][2];
                    }

                    if (img != null)
                    {
                        MemoryStream ms = new MemoryStream(img);
                        p.Image = Image.FromStream(ms);
                    }
                    else
                    {
                        p.Image = null;
                    }
                    cloth_image.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }








        //------------------------------------------------------------------------------

        //COMBINATION CREATE
        private void createcombbutton_Click(object sender, EventArgs e)
        {
            Form combcreateform = new form_user_createCombination();
            combcreateform.ShowDialog();
        }

        private void userpanelbutton7_Click(object sender, EventArgs e)
        {
            Form combplaza = new form_user_combinationsPlaza();
            combplaza.ShowDialog();
        }

        private void clothnametextBox_MouseDown(object sender, MouseEventArgs e)
        {
            clothnametextBox.Text = "";
        }




        //------------------------------------------------------------------------------
    }
}
