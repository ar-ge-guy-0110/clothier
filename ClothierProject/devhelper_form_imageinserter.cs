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
    public partial class devhelper_form_imageinserter : Form
    {
        SqlConnection conn = class_dbconnections.connect;
        SqlCommand command;
        string imgLoc = "";
        
        int bodytype_id;
        int clothingstyle_id;
        int clothingseason_id;
        int clothingplace_id;

        bool isBodyTypeSection;
        bool isClothingStyleSection;
        bool isClothingSeasonSection;
        bool isClothingPlaceSection;

        public devhelper_form_imageinserter()
        {
            InitializeComponent();
        }

        private void devhelper_form_imageinserter_Load(object sender, EventArgs e)
        {
            bodytype_id = -1;
            clothingstyle_id = -1;
            clothingseason_id = -1;
            clothingplace_id = -1;

            isBodyTypeSection = false;
            isClothingStyleSection = false;
            isClothingSeasonSection = false;
            isClothingPlaceSection = false;

            conn.Open();
            SqlCommand comm1 = new SqlCommand("SELECT * FROM body_type", conn);
            SqlDataReader read1 = comm1.ExecuteReader();
            while (read1.Read())
            {
                bodytypecomboBox1.Items.Add(read1["body_type_name"]);
            }
            conn.Close();

            conn.Open();
            SqlCommand comm2 = new SqlCommand("SELECT * FROM cloth_clothingstyle_category", conn);
            SqlDataReader read2 = comm2.ExecuteReader();
            while (read2.Read())
            {
                clothingstylecomboBox1.Items.Add(read2["category_name"]);
            }
            conn.Close();

            conn.Open();
            SqlCommand comm3 = new SqlCommand("SELECT * FROM cloth_season_category", conn);
            SqlDataReader read3 = comm3.ExecuteReader();
            while (read3.Read())
            {
                clothingseasoncomboBox1.Items.Add(read3["category_name"]);
            }
            conn.Close();

            conn.Open();
            SqlCommand comm4 = new SqlCommand("SELECT * FROM cloth_place_category", conn);
            SqlDataReader read4 = comm4.ExecuteReader();
            while (read4.Read())
            {
                clothingplacecomboBox1.Items.Add(read4["category_name"]);
            }
            conn.Close();
        }

        private void devhelper_form_imageinserter_MouseDown(object sender, MouseEventArgs e)
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

        private void bodytypesection_Click(object sender, EventArgs e)
        {
            if (isBodyTypeSection == false)
            {
                bodytypeimagespanel.Visible = true;
                isBodyTypeSection = true;

                isClothingStyleSection = false;
                clothingstyleimagespanel.Visible = false;
                isClothingSeasonSection = false;
                clothingseasonimagespanel.Visible = false;
                isClothingPlaceSection = false;
                clothingplacepanel.Visible = false;


                imgLoc = "";
            }
        }

        private void clothingstylesection_Click(object sender, EventArgs e)
        {
            if (isClothingStyleSection == false)
            {
                clothingstyleimagespanel.Visible = true;
                isClothingStyleSection = true;

                isBodyTypeSection = false;
                bodytypeimagespanel.Visible = false;
                isClothingSeasonSection = false;
                clothingseasonimagespanel.Visible = false;
                isClothingPlaceSection = false;
                clothingplacepanel.Visible = false;

                imgLoc = "";
            }
        }

        private void clothingseasonsection_Click(object sender, EventArgs e)
        {
            if (isClothingSeasonSection == false)
            {
                clothingseasonimagespanel.Visible = true;
                isClothingSeasonSection = true;

                isBodyTypeSection = false;
                bodytypeimagespanel.Visible = false;
                isClothingStyleSection = false;
                clothingstyleimagespanel.Visible = false;
                isClothingPlaceSection = false;
                clothingplacepanel.Visible = false;

                imgLoc = "";
            }
        }

        private void clothingplacesection_Click(object sender, EventArgs e)
        {
            if (isClothingPlaceSection == false)
            {
                clothingplacepanel.Visible = true;
                isClothingPlaceSection = true;

                isBodyTypeSection = false;
                bodytypeimagespanel.Visible = false;
                isClothingStyleSection = false;
                clothingstyleimagespanel.Visible = false;
                isClothingSeasonSection = false;
                clothingseasonimagespanel.Visible = false;


                imgLoc = "";
            }
        }


        //
        //
        //Body Type
        //
        //
        private void bodytypebutton1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|All Files (*.*)|*.*";
                dlg.Title = "Select BodyType Picture";
                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = dlg.FileName.ToString();
                    bodytypepictureBox.ImageLocation = imgLoc;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bodytypebutton2_Click(object sender, EventArgs e)
        {

            if(bodytype_id != -1)
            {
                DataTable imagecontrol = new DataTable();
                string idhasimage = "SELECT body_type_id FROM body_type_image WHERE body_type_id = " + bodytype_id;
                SqlDataAdapter da = new SqlDataAdapter(idhasimage, conn);
                da.Fill(imagecontrol);

                if(imagecontrol.Rows.Count == 1)
                {
                    imgLoc = "";
                    bodytype_id = -1;
                }
            }


            if (bodytype_id != -1 && imgLoc != "")
            {

                try
                {
                    byte[] img = null;
                    FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    img = br.ReadBytes((int)fs.Length);
                    string sql = "INSERT INTO body_type_image(body_type_id, image) VALUES(" + bodytype_id + ", @img)";
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    command = new SqlCommand(sql, conn);
                    command.Parameters.Add(new SqlParameter("@img", img));
                    int x = command.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show(x.ToString() + "record(s) saved.");

                    imgLoc = "";
                    bodytype_id = -1;
                }
                catch (Exception ex)
                {
                    conn.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select the item and image. If selected then it has already an image.");
            }

        }

        private void bodytypecomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(bodytypecomboBox1.SelectedIndex != -1)
            {
                DataTable bodytypeids = new DataTable();
                string idfind = "SELECT id FROM body_type WHERE body_type_name = '" + bodytypecomboBox1.SelectedItem.ToString() + "'";
                SqlDataAdapter da = new SqlDataAdapter(idfind, conn);
                da.Fill(bodytypeids);

                bodytype_id = Convert.ToInt32(bodytypeids.Rows[0][0]);
            }
        }

        private void bodytypebutton3_Click(object sender, EventArgs e)
        {
            try
            {
                if(bodytype_id != -1)
                {
                    string sql = "SELECT image FROM body_type_image WHERE body_type_id = " + bodytype_id;
                    if(conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    command = new SqlCommand(sql, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        byte[] img = (byte[])(reader[0]);
                        if(img == null)
                        {
                            bodytypepictureBox.Image = null;
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(img);
                            bodytypepictureBox.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Oops.. This body type does not exist.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select the body type.");
                }
                conn.Close();
            }
            catch(Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void bodytypebutton4_Click(object sender, EventArgs e)
        {
            if(bodytype_id != -1)
            {
                DialogResult areyousure = MessageBox.Show("This picture will be deleted. Are you sure?", "Sure!", MessageBoxButtons.YesNo);
                if(areyousure == DialogResult.Yes)
                {
                    try
                    {
                        SqlCommand deleteimage = new SqlCommand("DELETE FROM body_type_image WHERE body_type_id = @btid", conn);
                        deleteimage.Parameters.AddWithValue("@btid", SqlDbType.Int).Value = bodytype_id;
                        conn.Open();
                        deleteimage.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select the body type.");
            }
        }





        //
        //
        //Clothing Style
        //
        //

        private void clothingstylecomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clothingstylecomboBox1.SelectedIndex != -1)
            {
                DataTable clothingstyleids = new DataTable();
                string idfind = "SELECT id FROM cloth_clothingstyle_category WHERE category_name = '" + clothingstylecomboBox1.SelectedItem.ToString() + "'";
                SqlDataAdapter da = new SqlDataAdapter(idfind, conn);
                da.Fill(clothingstyleids);

                clothingstyle_id = Convert.ToInt32(clothingstyleids.Rows[0][0]);
            }
        }

        private void clothingstylebutton1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|All Files (*.*)|*.*";
                dlg.Title = "Select Clothing Style Picture";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = dlg.FileName.ToString();
                    bodytypepictureBox.ImageLocation = imgLoc;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clothingstylebutton2_Click(object sender, EventArgs e)
        {
            if (clothingstyle_id != -1)
            {
                DataTable imagecontrol = new DataTable();
                string idhasimage = "SELECT clothing_style_id FROM clothing_style_image WHERE clothing_style_id = " + clothingstyle_id;
                SqlDataAdapter da = new SqlDataAdapter(idhasimage, conn);
                da.Fill(imagecontrol);

                if (imagecontrol.Rows.Count == 1)
                {
                    imgLoc = "";
                    clothingstyle_id = -1;
                }
            }


            if (clothingstyle_id != -1 && imgLoc != "")
            {

                try
                {
                    byte[] img = null;
                    FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    img = br.ReadBytes((int)fs.Length);
                    string sql = "INSERT INTO clothing_style_image(clothing_style_id, image) VALUES(" + clothingstyle_id + ", @img)";
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    command = new SqlCommand(sql, conn);
                    command.Parameters.Add(new SqlParameter("@img", img));
                    int x = command.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show(x.ToString() + "record(s) saved.");

                    imgLoc = "";
                    clothingstyle_id = -1;
                }
                catch (Exception ex)
                {
                    conn.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select the item and image. If selected then it has already an image.");
            }

        }

        private void clothingstylebutton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (clothingstyle_id != -1)
                {
                    string sql = "SELECT image FROM clothing_style_image WHERE clothing_style_id = " + clothingstyle_id;
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    command = new SqlCommand(sql, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        byte[] img = (byte[])(reader[0]);
                        if (img == null)
                        {
                            clothingstylepictureBox.Image = null;
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(img);
                            clothingstylepictureBox.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Oops.. This clothing style does not exist.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select the clothing style.");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void clothingstylebutton4_Click(object sender, EventArgs e)
        {
            if (clothingstyle_id != -1)
            {
                DialogResult areyousure = MessageBox.Show("This picture will be deleted. Are you sure?", "Sure!", MessageBoxButtons.YesNo);
                if (areyousure == DialogResult.Yes)
                {
                    try
                    {
                        SqlCommand deleteimage = new SqlCommand("DELETE FROM clothing_style_image WHERE clothing_style_id = @btid", conn);
                        deleteimage.Parameters.AddWithValue("@btid", SqlDbType.Int).Value = clothingstyle_id;
                        conn.Open();
                        deleteimage.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select the clothing style.");
            }
        }

        //
        //
        //Clothing Season
        //
        //

        private void clothingseasoncomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clothingseasoncomboBox1.SelectedIndex != -1)
            {
                DataTable clothingseasonids = new DataTable();
                string idfind = "SELECT id FROM cloth_season_category WHERE category_name = '" + clothingseasoncomboBox1.SelectedItem.ToString() + "'";
                SqlDataAdapter da = new SqlDataAdapter(idfind, conn);
                da.Fill(clothingseasonids);

                clothingseason_id = Convert.ToInt32(clothingseasonids.Rows[0][0]);
            }
        }

        private void clothingseasonbutton1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|All Files (*.*)|*.*";
                dlg.Title = "Select Clothing Season Picture";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = dlg.FileName.ToString();
                    clothingseasonpictureBox1.ImageLocation = imgLoc;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clothingseasonbutton2_Click(object sender, EventArgs e)
        {
            if (clothingseason_id != -1)
            {
                DataTable imagecontrol = new DataTable();
                string idhasimage = "SELECT cloth_season_id FROM cloth_season_image WHERE cloth_season_id = " + clothingseason_id;
                SqlDataAdapter da = new SqlDataAdapter(idhasimage, conn);
                da.Fill(imagecontrol);

                if (imagecontrol.Rows.Count == 1)
                {
                    imgLoc = "";
                    clothingstyle_id = -1;
                }
            }


            if (clothingseason_id != -1 && imgLoc != "")
            {

                try
                {
                    byte[] img = null;
                    FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    img = br.ReadBytes((int)fs.Length);
                    string sql = "INSERT INTO cloth_season_image(cloth_season_id, image) VALUES(" + clothingseason_id + ", @img)";
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    command = new SqlCommand(sql, conn);
                    command.Parameters.Add(new SqlParameter("@img", img));
                    int x = command.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show(x.ToString() + "record(s) saved.");

                    imgLoc = "";
                    clothingseason_id = -1;
                }
                catch (Exception ex)
                {
                    conn.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select the item and image. If selected then it has already an image.");
            }

        }

        private void clothingseasonbutton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (clothingseason_id != -1)
                {
                    string sql = "SELECT image FROM cloth_season_image WHERE cloth_season_id = " + clothingseason_id;
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    command = new SqlCommand(sql, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        byte[] img = (byte[])(reader[0]);
                        if (img == null)
                        {
                            clothingseasonpictureBox1.Image = null;
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(img);
                            clothingseasonpictureBox1.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Oops.. This season does not exist.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select the season.");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void clothingseasonbutton4_Click(object sender, EventArgs e)
        {
            if (clothingseason_id != -1)
            {
                DialogResult areyousure = MessageBox.Show("This picture will be deleted. Are you sure?", "Sure!", MessageBoxButtons.YesNo);
                if (areyousure == DialogResult.Yes)
                {
                    try
                    {
                        SqlCommand deleteimage = new SqlCommand("DELETE FROM cloth_season_image WHERE cloth_season_id = @btid", conn);
                        deleteimage.Parameters.AddWithValue("@btid", SqlDbType.Int).Value = clothingseason_id;
                        conn.Open();
                        deleteimage.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select the season.");
            }
        }


        //
        //
        //Clothing Place
        //
        //

        private void clothingplacecomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clothingplacecomboBox1.SelectedIndex != -1)
            {
                DataTable clothingplaceids = new DataTable();
                string idfind = "SELECT id FROM cloth_place_category WHERE category_name = '" + clothingplacecomboBox1.SelectedItem.ToString() + "'";
                SqlDataAdapter da = new SqlDataAdapter(idfind, conn);
                da.Fill(clothingplaceids);

                clothingplace_id = Convert.ToInt32(clothingplaceids.Rows[0][0]);
            }
        }

        private void clothingplacebutton1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|All Files (*.*)|*.*";
                dlg.Title = "Select Clothing Place Picture";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = dlg.FileName.ToString();
                    clothingplacepictureBox1.ImageLocation = imgLoc;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clothingplacebutton2_Click(object sender, EventArgs e)
        {
            if (clothingplace_id != -1)
            {
                DataTable imagecontrol = new DataTable();
                string idhasimage = "SELECT cloth_place_id FROM cloth_place_image WHERE cloth_place_id = " + clothingplace_id;
                SqlDataAdapter da = new SqlDataAdapter(idhasimage, conn);
                da.Fill(imagecontrol);

                if (imagecontrol.Rows.Count == 1)
                {
                    imgLoc = "";
                    clothingplace_id = -1;
                }
            }


            if (clothingplace_id != -1 && imgLoc != "")
            {

                try
                {
                    byte[] img = null;
                    FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    img = br.ReadBytes((int)fs.Length);
                    string sql = "INSERT INTO cloth_place_image(cloth_place_id, image) VALUES(" + clothingplace_id + ", @img)";
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    command = new SqlCommand(sql, conn);
                    command.Parameters.Add(new SqlParameter("@img", img));
                    int x = command.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show(x.ToString() + "record(s) saved.");

                    imgLoc = "";
                    clothingplace_id = -1;
                }
                catch (Exception ex)
                {
                    conn.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select the item and image. If selected then it has already an image.");
            }

        }

        private void clothingplacebutton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (clothingplace_id != -1)
                {
                    string sql = "SELECT image FROM cloth_place_image WHERE cloth_place_id = " + clothingplace_id;
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    command = new SqlCommand(sql, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        byte[] img = (byte[])(reader[0]);
                        if (img == null)
                        {
                            clothingplacepictureBox1.Image = null;
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(img);
                            clothingplacepictureBox1.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Oops.. This place does not exist.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select the place.");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void clothingplacebutton4_Click(object sender, EventArgs e)
        {
            if (clothingplace_id != -1)
            {
                DialogResult areyousure = MessageBox.Show("This picture will be deleted. Are you sure?", "Sure!", MessageBoxButtons.YesNo);
                if (areyousure == DialogResult.Yes)
                {
                    try
                    {
                        SqlCommand deleteimage = new SqlCommand("DELETE FROM cloth_place_image WHERE cloth_place_id = @btid", conn);
                        deleteimage.Parameters.AddWithValue("@btid", SqlDbType.Int).Value = clothingplace_id;
                        conn.Open();
                        deleteimage.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select the place.");
            }
        }
    }
}
