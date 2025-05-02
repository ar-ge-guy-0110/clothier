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
    public partial class devhelper_form_clothdefiner : Form
    {
        SqlConnection conn = class_dbconnections.connect;
        SqlCommand command;

        bool isDefinitionsSection;
        bool isClothesSection;

        //ids
        int clothid;
        int categoryid;
        int subcategoryid;
        int bmiid;
        int bodytypeid;
        int styleid;
        int seasonid;
        int placeid;

        //paths
        string imgLoc = "";

        public devhelper_form_clothdefiner()
        {
            InitializeComponent();
        }

        private void devhelper_form_clothdefiner_Load(object sender, EventArgs e)
        {
            //list
            list1();

            //load panel options
            isDefinitionsSection = false;
            isClothesSection = false;

            //load ids
            clothid = -1;
            categoryid = -1;
            subcategoryid = -1;
            bmiid = -1;
            bodytypeid = -1;
            styleid = -1;
            seasonid = -1;
            placeid = -1;

            //load comboBoxes
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

        private void mainbutton1_Click(object sender, EventArgs e)
        {
            if (isDefinitionsSection == false)
            {
                isDefinitionsSection = true;
                definitionspanel.Visible = true;
            }
            else
            {
                isDefinitionsSection = false;
                definitionspanel.Visible = false;
            }

        }

        private void mainbutton2_Click(object sender, EventArgs e)
        {
            if (isClothesSection == false)
            {
                isClothesSection = true;
                clothespanel.Visible = true;
            }
            else
            {
                isClothesSection = false;
                clothespanel.Visible = false;
            }
        }

        private void headerpanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                class_borderlessmove.ReleaseCapture();
                class_borderlessmove.SendMessage(Handle, class_borderlessmove.WM_NCLBUTTONDOWN, class_borderlessmove.HT_CAPTION, 0);
            }
        }

        private void definitionspanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                class_borderlessmove.ReleaseCapture();
                class_borderlessmove.SendMessage(Handle, class_borderlessmove.WM_NCLBUTTONDOWN, class_borderlessmove.HT_CAPTION, 0);
            }
        }

        //ComboBoxFuncs
        private void categorydefinitioncomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(categorydefinitioncomboBox1.SelectedIndex != -1)
            {
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

        private void subcategorydefinitioncomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(subcategorydefinitioncomboBox1.SelectedIndex != -1)
            {
                DataTable idal = new DataTable();
                string idalsql = "SELECT id FROM cloth_subcategory WHERE subcategory_name = '" + subcategorydefinitioncomboBox1.SelectedItem.ToString() + "'";
                SqlDataAdapter da = new SqlDataAdapter(idalsql, conn);
                da.Fill(idal);
                subcategoryid = Convert.ToInt32(idal.Rows[0][0]);
            }
        }

        private void bmicomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bmicomboBox1.SelectedIndex != -1)
            {
                DataTable idal = new DataTable();
                string idalsql = "SELECT id FROM cloth_bmi_category WHERE bmi_name = '" + bmicomboBox1.SelectedItem.ToString() + "'";
                SqlDataAdapter da = new SqlDataAdapter(idalsql, conn);
                da.Fill(idal);
                bmiid = Convert.ToInt32(idal.Rows[0][0]);
            }
        }

        private void bodytypecomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bodytypecomboBox1.SelectedIndex != -1)
            {
                DataTable idal = new DataTable();
                string idalsql = "SELECT id FROM body_type WHERE body_type_name = '" + bodytypecomboBox1.SelectedItem.ToString() + "'";
                SqlDataAdapter da = new SqlDataAdapter(idalsql, conn);
                da.Fill(idal);
                bodytypeid = Convert.ToInt32(idal.Rows[0][0]);
            }
        }

        private void stylecomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (stylecomboBox1.SelectedIndex != -1)
            {
                DataTable idal = new DataTable();
                string idalsql = "SELECT id FROM cloth_clothingstyle_category WHERE category_name = '" + stylecomboBox1.SelectedItem.ToString() + "'";
                SqlDataAdapter da = new SqlDataAdapter(idalsql, conn);
                da.Fill(idal);
                styleid = Convert.ToInt32(idal.Rows[0][0]);
            }
        }

        private void seasoncomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (seasoncomboBox1.SelectedIndex != -1)
            {
                DataTable idal = new DataTable();
                string idalsql = "SELECT id FROM cloth_season_category WHERE category_name = '" + seasoncomboBox1.SelectedItem.ToString() + "'";
                SqlDataAdapter da = new SqlDataAdapter(idalsql, conn);
                da.Fill(idal);
                seasonid = Convert.ToInt32(idal.Rows[0][0]);
            }
        }

        private void placecomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (placecomboBox1.SelectedIndex != -1)
            {
                DataTable idal = new DataTable();
                string idalsql = "SELECT id FROM cloth_place_category WHERE category_name = '" + placecomboBox1.SelectedItem.ToString() + "'";
                SqlDataAdapter da = new SqlDataAdapter(idalsql, conn);
                da.Fill(idal);
                placeid = Convert.ToInt32(idal.Rows[0][0]);
            }
        }

        //lists
        private void list1()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT cloth.id AS 'Cloth ID', 
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
                          JOIN cloth_which_place_category ON cloth.id = cloth_which_place_category.cloth_id JOIN cloth_place_category ON cloth_which_place_category.cloth_place_category_id = cloth_place_category.id";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        //Clic'n Fetch(s)
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if(dataGridView1.CurrentRow != null)
                {

                    clothid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    clothnametextBox.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    
                    categorydefinitioncomboBox1.SelectedItem = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    subcategorydefinitioncomboBox1.SelectedItem = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    bmicomboBox1.SelectedItem = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    bodytypecomboBox1.SelectedItem = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    stylecomboBox1.SelectedItem = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    seasoncomboBox1.SelectedItem = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                    placecomboBox1.SelectedItem = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                }

            }
            catch
            {
                MessageBox.Show("Please choose the right row.");
                clothid = -1;
            }
        }




        //
        //
        //
        //BUTTONS
        //
        //
        //

        //ADD
        private void button1_Click(object sender, EventArgs e)
        {
            if(clothnametextBox.Text != "" && 
                categorydefinitioncomboBox1.SelectedIndex != -1 && categoryid != -1 && 
                subcategorydefinitioncomboBox1.SelectedIndex != -1 && subcategoryid != -1 && 
                bmicomboBox1.SelectedIndex != -1 && bmiid != -1 && 
                bodytypecomboBox1.SelectedIndex != -1 && bodytypeid != -1 && 
                stylecomboBox1.SelectedIndex != -1 && styleid != -1 &&
                seasoncomboBox1.SelectedIndex != -1 && seasonid != -1 &&
                placecomboBox1.SelectedIndex != -1 && placeid != -1 && 
                clothnametextBox.Text != "Cloth Name")
            {
                try
                {
                    int idbull;

                    //add cloth and find its id
                    SqlCommand definecloth = new SqlCommand("INSERT INTO cloth(cloth_name) VALUES(@cname) SELECT SCOPE_IDENTITY()", conn);
                    definecloth.Parameters.AddWithValue("@cname", SqlDbType.NVarChar).Value = clothnametextBox.Text;

                    conn.Open();
                    idbull = Convert.ToInt32(definecloth.ExecuteScalar());
                    conn.Close();

                    //cloth_which_category?
                    SqlCommand definecategory = new SqlCommand("INSERT INTO cloth_which_category(cloth_id, cloth_category_id) VALUES(@cid, @ccid)", conn);
                    definecategory.Parameters.AddWithValue("@cid", SqlDbType.Int).Value = idbull;
                    definecategory.Parameters.AddWithValue("@ccid", SqlDbType.Int).Value = categoryid;

                    conn.Open();
                    definecategory.ExecuteNonQuery();
                    conn.Close();

                    //cloth_which_subcategory?
                    SqlCommand definesubcategory = new SqlCommand("INSERT INTO cloth_which_subcategory(cloth_id, cloth_subcategory_id) VALUES(@cid, @ccid)", conn);
                    definesubcategory.Parameters.AddWithValue("@cid", SqlDbType.Int).Value = idbull;
                    definesubcategory.Parameters.AddWithValue("@ccid", SqlDbType.Int).Value = subcategoryid;

                    conn.Open();
                    definesubcategory.ExecuteNonQuery();
                    conn.Close();

                    //cloth_which_bmi_category?
                    SqlCommand definebmi = new SqlCommand("INSERT INTO cloth_which_bmi_category(cloth_id, cloth_bmi_category_id) VALUES(@cid, @ccid)", conn);
                    definebmi.Parameters.AddWithValue("@cid", SqlDbType.Int).Value = idbull;
                    definebmi.Parameters.AddWithValue("@ccid", SqlDbType.Int).Value = bmiid;

                    conn.Open();
                    definebmi.ExecuteNonQuery();
                    conn.Close();

                    //cloth_which_bodytype_category?
                    SqlCommand definebodytype = new SqlCommand("INSERT INTO cloth_which_bodytype_category(cloth_id, body_type_id) VALUES(@cid, @ccid)", conn);
                    definebodytype.Parameters.AddWithValue("@cid", SqlDbType.Int).Value = idbull;
                    definebodytype.Parameters.AddWithValue("@ccid", SqlDbType.Int).Value = bodytypeid;

                    conn.Open();
                    definebodytype.ExecuteNonQuery();
                    conn.Close();

                    //cloth_which_clothingstyle_category?
                    SqlCommand definestyle = new SqlCommand("INSERT INTO cloth_which_clothingstyle_category(cloth_id, cloth_clothingstyle_category_id) VALUES(@cid, @ccid)", conn);
                    definestyle.Parameters.AddWithValue("@cid", SqlDbType.Int).Value = idbull;
                    definestyle.Parameters.AddWithValue("@ccid", SqlDbType.Int).Value = styleid;

                    conn.Open();
                    definestyle.ExecuteNonQuery();
                    conn.Close();

                    //cloth_which_season_category?
                    SqlCommand defineseason = new SqlCommand("INSERT INTO cloth_which_season_category(cloth_id, cloth_season_category_id) VALUES(@cid, @ccid)", conn);
                    defineseason.Parameters.AddWithValue("@cid", SqlDbType.Int).Value = idbull;
                    defineseason.Parameters.AddWithValue("@ccid", SqlDbType.Int).Value = seasonid;

                    conn.Open();
                    defineseason.ExecuteNonQuery();
                    conn.Close();

                    //cloth_which_place_category?
                    SqlCommand defineplace = new SqlCommand("INSERT INTO cloth_which_place_category(cloth_id, cloth_place_category_id) VALUES(@cid, @ccid)", conn);
                    defineplace.Parameters.AddWithValue("@cid", SqlDbType.Int).Value = idbull;
                    defineplace.Parameters.AddWithValue("@ccid", SqlDbType.Int).Value = placeid;

                    conn.Open();
                    defineplace.ExecuteNonQuery();
                    conn.Close();

                    list1();


                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please be sure to enter the information completely.");
            }
        }

        //DELETE
        private void button2_Click(object sender, EventArgs e)
        {
            if(clothid != -1)
            {
                try
                {
                    //before delete, we must clear this clothing's sub things
                    SqlCommand nullifycombs1 = new SqlCommand("UPDATE user_outfit_combination SET dress_slot = NULL WHERE dress_slot = @id", conn);
                    nullifycombs1.Parameters.AddWithValue("@id", SqlDbType.Int).Value = clothid;
                    conn.Open();
                    nullifycombs1.ExecuteNonQuery();
                    conn.Close();

                    SqlCommand nullifycombs2 = new SqlCommand("UPDATE user_outfit_combination SET topwear_slot = NULL WHERE topwear_slot = @id", conn);
                    nullifycombs2.Parameters.AddWithValue("@id", SqlDbType.Int).Value = clothid;
                    conn.Open();
                    nullifycombs2.ExecuteNonQuery();
                    conn.Close();

                    SqlCommand nullifycombs3 = new SqlCommand("UPDATE user_outfit_combination SET bottomwear_slot = NULL WHERE bottomwear_slot = @id", conn);
                    nullifycombs3.Parameters.AddWithValue("@id", SqlDbType.Int).Value = clothid;
                    conn.Open();
                    nullifycombs3.ExecuteNonQuery();
                    conn.Close();

                    SqlCommand nullifycombs4 = new SqlCommand("UPDATE user_outfit_combination SET shoe_slot = NULL WHERE shoe_slot = @id", conn);
                    nullifycombs4.Parameters.AddWithValue("@id", SqlDbType.Int).Value = clothid;
                    conn.Open();
                    nullifycombs4.ExecuteNonQuery();
                    conn.Close();

                    SqlCommand nullifycombs5 = new SqlCommand("UPDATE user_outfit_combination SET bag_slot = NULL WHERE bag_slot = @id", conn);
                    nullifycombs5.Parameters.AddWithValue("@id", SqlDbType.Int).Value = clothid;
                    conn.Open();
                    nullifycombs5.ExecuteNonQuery();
                    conn.Close();


                    SqlCommand deletecategory = new SqlCommand("DELETE FROM cloth_which_category WHERE cloth_id = @id", conn);
                    deletecategory.Parameters.AddWithValue("@id", SqlDbType.Int).Value = clothid;
                    conn.Open();
                    deletecategory.ExecuteNonQuery();
                    conn.Close();

                    SqlCommand deletesubcategory = new SqlCommand("DELETE FROM cloth_which_subcategory WHERE cloth_id = @id", conn);
                    deletesubcategory.Parameters.AddWithValue("@id", SqlDbType.Int).Value = clothid;
                    conn.Open();
                    deletesubcategory.ExecuteNonQuery();
                    conn.Close();

                    SqlCommand deletebmi = new SqlCommand("DELETE FROM cloth_which_bmi_category WHERE cloth_id = @id", conn);
                    deletebmi.Parameters.AddWithValue("@id", SqlDbType.Int).Value = clothid;
                    conn.Open();
                    deletebmi.ExecuteNonQuery();
                    conn.Close();

                    SqlCommand deletebodytype = new SqlCommand("DELETE FROM cloth_which_bodytype_category WHERE cloth_id = @id", conn);
                    deletebodytype.Parameters.AddWithValue("@id", SqlDbType.Int).Value = clothid;
                    conn.Open();
                    deletebodytype.ExecuteNonQuery();
                    conn.Close();

                    SqlCommand deletestyle = new SqlCommand("DELETE FROM cloth_which_clothingstyle_category WHERE cloth_id = @id", conn);
                    deletestyle.Parameters.AddWithValue("@id", SqlDbType.Int).Value = clothid;
                    conn.Open();
                    deletestyle.ExecuteNonQuery();
                    conn.Close();

                    SqlCommand deleteseason = new SqlCommand("DELETE FROM cloth_which_season_category WHERE cloth_id = @id", conn);
                    deleteseason.Parameters.AddWithValue("@id", SqlDbType.Int).Value = clothid;
                    conn.Open();
                    deleteseason.ExecuteNonQuery();
                    conn.Close();

                    SqlCommand deleteplace = new SqlCommand("DELETE FROM cloth_which_place_category WHERE cloth_id = @id", conn);
                    deleteplace.Parameters.AddWithValue("@id", SqlDbType.Int).Value = clothid;
                    conn.Open();
                    deleteplace.ExecuteNonQuery();
                    conn.Close();

                    //delete its image
                    SqlCommand deleteimage = new SqlCommand("DELETE FROM cloth_image WHERE cloth_id = @id", conn);
                    deleteimage.Parameters.AddWithValue("@id", SqlDbType.Int).Value = clothid;
                    conn.Open();
                    deleteimage.ExecuteNonQuery();
                    conn.Close();


                    //main
                    SqlCommand deletecloth = new SqlCommand("DELETE FROM cloth WHERE id = @id", conn);
                    deletecloth.Parameters.AddWithValue("@id", SqlDbType.Int).Value = clothid;
                    conn.Open();
                    deletecloth.ExecuteNonQuery();
                    conn.Close();

                    list1();
                    clothid = -1;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please double click and select the cloth you want to delete.");
            }
        }

        //UPDATE
        private void button3_Click(object sender, EventArgs e)
        {
            /*
                         if(clothid != -1 && clothnametextBox.Text != "" &&
                categorydefinitioncomboBox1.SelectedIndex != -1 && categoryid != -1 &&
                subcategorydefinitioncomboBox1.SelectedIndex != -1 && subcategoryid != -1 &&
                bmicomboBox1.SelectedIndex != -1 && bmiid != -1 &&
                bodytypecomboBox1.SelectedIndex != -1 && bodytypeid != -1 &&
                stylecomboBox1.SelectedIndex != -1 && styleid != -1 &&
                seasoncomboBox1.SelectedIndex != -1 && seasonid != -1 &&
                placecomboBox1.SelectedIndex != -1 && placeid != -1)
            */
            if (clothid != -1 && clothnametextBox.Text != "" &&
                categorydefinitioncomboBox1.SelectedIndex != -1 && 
                subcategorydefinitioncomboBox1.SelectedIndex != -1 &&  
                bmicomboBox1.SelectedIndex != -1 && 
                bodytypecomboBox1.SelectedIndex != -1 && 
                stylecomboBox1.SelectedIndex != -1 && 
                seasoncomboBox1.SelectedIndex != -1 && 
                placecomboBox1.SelectedIndex != -1)
            {

                SqlCommand updatecategory = new SqlCommand("UPDATE cloth_which_category SET cloth_category_id = @cid WHERE cloth_id = @id", conn);
                updatecategory.Parameters.AddWithValue("@cid", SqlDbType.Int).Value = categoryid;
                updatecategory.Parameters.AddWithValue("@id", SqlDbType.Int).Value = clothid;
                conn.Open();
                updatecategory.ExecuteNonQuery();
                conn.Close();

                SqlCommand updatesubcategory = new SqlCommand("UPDATE cloth_which_subcategory SET cloth_subcategory_id = @cid  WHERE cloth_id = @id", conn);
                updatesubcategory.Parameters.AddWithValue("@cid", SqlDbType.Int).Value = subcategoryid;
                updatesubcategory.Parameters.AddWithValue("@id", SqlDbType.Int).Value = clothid;
                conn.Open();
                updatesubcategory.ExecuteNonQuery();
                conn.Close();

                SqlCommand updatebmi = new SqlCommand("UPDATE cloth_which_bmi_category SET cloth_bmi_category_id = @cid WHERE cloth_id = @id", conn);
                updatebmi.Parameters.AddWithValue("@cid", SqlDbType.Int).Value = bmiid;
                updatebmi.Parameters.AddWithValue("@id", SqlDbType.Int).Value = clothid;
                conn.Open();
                updatebmi.ExecuteNonQuery();
                conn.Close();

                SqlCommand updatebodytype = new SqlCommand("UPDATE cloth_which_bodytype_category SET body_type_id = @cid WHERE cloth_id = @id", conn);
                updatebodytype.Parameters.AddWithValue("@cid", SqlDbType.Int).Value = bodytypeid;
                updatebodytype.Parameters.AddWithValue("@id", SqlDbType.Int).Value = clothid;
                conn.Open();
                updatebodytype.ExecuteNonQuery();
                conn.Close();

                SqlCommand updatestyle = new SqlCommand("UPDATE cloth_which_clothingstyle_category SET cloth_clothingstyle_category_id = @cid WHERE cloth_id = @id", conn);
                updatestyle.Parameters.AddWithValue("@cid", SqlDbType.Int).Value = styleid;
                updatestyle.Parameters.AddWithValue("@id", SqlDbType.Int).Value = clothid;
                conn.Open();
                updatestyle.ExecuteNonQuery();
                conn.Close();

                SqlCommand updateseason = new SqlCommand("UPDATE cloth_which_season_category SET cloth_season_category_id = @cid  WHERE cloth_id = @id", conn);
                updateseason.Parameters.AddWithValue("@cid", SqlDbType.Int).Value = seasonid;
                updateseason.Parameters.AddWithValue("@id", SqlDbType.Int).Value = clothid;
                conn.Open();
                updateseason.ExecuteNonQuery();
                conn.Close();

                SqlCommand updateplace = new SqlCommand("UPDATE cloth_which_place_category SET cloth_place_category_id = @cid  WHERE cloth_id = @id", conn);
                updateplace.Parameters.AddWithValue("@cid", SqlDbType.Int).Value = placeid;
                updateplace.Parameters.AddWithValue("@id", SqlDbType.Int).Value = clothid;
                conn.Open();
                updateplace.ExecuteNonQuery();
                conn.Close();

                SqlCommand updatename = new SqlCommand("UPDATE cloth SET cloth_name = @cname WHERE id = @id", conn);
                updatename.Parameters.AddWithValue("@cname", SqlDbType.NVarChar).Value = clothnametextBox.Text;
                updatename.Parameters.AddWithValue("@id", SqlDbType.Int).Value = clothid;
                conn.Open();
                updatename.ExecuteNonQuery();
                conn.Close();

                list1();
            }
            else
            {
                MessageBox.Show("Please double click and select the cloth you want to update.");
            }
        }

        //SEARCH
        private void button4_Click(object sender, EventArgs e)
        {
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

            if(clothnametextBox.Text != "")
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
                cmd_end += " body_type.body_type_name LIKE '%" +bodytypecomboBox1.SelectedItem.ToString() + "%'";
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

            if((clothnametextBox.Text != "" && clothnametextBox.Text != "Cloth Name") || categorydefinitioncomboBox1.SelectedIndex != -1 || subcategorydefinitioncomboBox1.SelectedIndex != -1 || bmicomboBox1.SelectedIndex != -1 || bodytypecomboBox1.SelectedIndex != -1 || stylecomboBox1.SelectedIndex != -1 || seasoncomboBox1.SelectedIndex != -1 || placecomboBox1.SelectedIndex != -1)
            {
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(search, conn);
                da2.Fill(dt2);
                dataGridView1.DataSource = dt2;
            }
            else
            {
                list1();
            }
        }

        //CLEAR BOXES
        private void button5_Click(object sender, EventArgs e)
        {
            clothid = -1;
            clothnametextBox.Text = "";

            categorydefinitioncomboBox1.SelectedIndex = -1;
            subcategorydefinitioncomboBox1.SelectedIndex = -1;
            bmicomboBox1.SelectedIndex = -1;
            bodytypecomboBox1.SelectedIndex = -1;
            stylecomboBox1.SelectedIndex = -1;
            seasoncomboBox1.SelectedIndex = -1;
            placecomboBox1.SelectedIndex = -1;
        }

        //LIST!
        private void button6_Click(object sender, EventArgs e)
        {
            list1();
        }



        //
        //
        //IMAGE SECTION
        //
        //

        private void defbutton1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|All Files (*.*)|*.*";
                dlg.Title = "Select Clothing Image";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = dlg.FileName.ToString();
                    pictureBox1.ImageLocation = imgLoc;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void defbutton2_Click(object sender, EventArgs e)
        {
            if (clothid != -1)
            {
                DataTable imagecontrol = new DataTable();
                string idhasimage = "SELECT cloth_id FROM cloth_image WHERE cloth_id = " + clothid;
                SqlDataAdapter da = new SqlDataAdapter(idhasimage, conn);
                da.Fill(imagecontrol);

                if (imagecontrol.Rows.Count == 1)
                {
                    imgLoc = "";
                    clothid = -1;
                    pictureBox1.Image = null;
                }
            }


            if (clothid != -1 && imgLoc != "" && pictureBox1.Image != null)
            {

                try
                {
                    byte[] img = null;
                    FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    img = br.ReadBytes((int)fs.Length);
                    string sql = "INSERT INTO cloth_image(cloth_id, image) VALUES(" + clothid + ", @img)";
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
                    clothid = -1;
                    pictureBox1.Image = null;
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

        private void defbutton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (clothid != -1)
                {
                    string sql = "SELECT image FROM cloth_image WHERE cloth_id = " + clothid;
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
                            pictureBox1.Image = null;
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(img);
                            pictureBox1.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Oops.. This clothing does not exist.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select the clothing.");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void defbutton4_Click(object sender, EventArgs e)
        {
            if (clothid != -1)
            {
                DialogResult areyousure = MessageBox.Show("This picture will be deleted. Are you sure?", "Sure!", MessageBoxButtons.YesNo);
                if (areyousure == DialogResult.Yes)
                {
                    try
                    {
                        SqlCommand deleteimage = new SqlCommand("DELETE FROM cloth_image WHERE cloth_id = @btid", conn);
                        deleteimage.Parameters.AddWithValue("@btid", SqlDbType.Int).Value = clothid;
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
                MessageBox.Show("Please select the clothing.");
            }
        }
    }





}
