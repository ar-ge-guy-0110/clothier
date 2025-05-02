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
    public partial class form_user_createCombination : Form
    {
        SqlConnection conn = class_dbconnections.connect;

        int combid;

        public form_user_createCombination()
        {
            InitializeComponent();
        }

        private void combnametextBox_Enter(object sender, EventArgs e)
        {
            combnametextBox.Text = "";
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {

                    combid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    combnametextBox.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                    DataTable user_outfit_combination = new DataTable();
                    string fetchcombinations = @"SELECT user_outfit_combination.dress_slot, cloth_image.image, 
                    user_outfit_combination.topwear_slot, cloth_image2.image, 
                    user_outfit_combination.bottomwear_slot, cloth_image3.image, 
                    user_outfit_combination.shoe_slot, cloth_image4.image, 
                    user_outfit_combination.bag_slot, cloth_image5.image FROM user_outfit_combination 
                    LEFT JOIN cloth_image ON user_outfit_combination.dress_slot = cloth_image.cloth_id 
                    LEFT JOIN cloth_image AS cloth_image2 ON user_outfit_combination.topwear_slot = cloth_image2.cloth_id 
                    LEFT JOIN cloth_image AS cloth_image3 ON user_outfit_combination.bottomwear_slot = cloth_image3.cloth_id 
                    LEFT JOIN cloth_image AS cloth_image4 ON user_outfit_combination.shoe_slot = cloth_image4.cloth_id 
                    LEFT JOIN cloth_image AS cloth_image5 ON user_outfit_combination.bag_slot = cloth_image5.cloth_id WHERE user_outfit_combination.id = " + combid;
                    SqlDataAdapter da = new SqlDataAdapter(fetchcombinations, conn);
                    da.Fill(user_outfit_combination);

                    byte[] img;
                    byte[] blankimg = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mP8z/C/HgAGgwJ/lK3Q6wAAAABJRU5ErkJggg==");


                    dressortoppictureBox.Image = null;
                    bottompictureBox.Image = null;
                    shoepictureBox.Image = null;
                    bagpictureBox.Image = null;

                   
                    foreach (DataRow row in user_outfit_combination.Rows)
                    {
                        if(!DBNull.Value.Equals(row["dress_slot"]))
                        {
                            if(!DBNull.Value.Equals(row[1]))
                            {
                                img = (byte[])row[1];


                                MemoryStream ms = new MemoryStream(img);
                                dressortoppictureBox.Image = Image.FromStream(ms);
                            }
                            else
                            {
                                MemoryStream ms = new MemoryStream(blankimg);
                                dressortoppictureBox.Image = Image.FromStream(ms);
                            }

                        }
                        else
                        {
                            if(DBNull.Value.Equals(row["topwear_slot"]))
                            {
                                MemoryStream ms = new MemoryStream(blankimg);
                                dressortoppictureBox.Image = Image.FromStream(ms);
                            }
                        }





                        if (!DBNull.Value.Equals(row["topwear_slot"]))
                        {

                            if (!DBNull.Value.Equals(row[3]))
                            {
                                img = (byte[])row[3];


                                MemoryStream ms = new MemoryStream(img);
                                dressortoppictureBox.Image = Image.FromStream(ms);
                            }
                            else
                            {
                                MemoryStream ms = new MemoryStream(blankimg);
                                dressortoppictureBox.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            if(DBNull.Value.Equals(row["dress_slot"]))
                            {
                                MemoryStream ms = new MemoryStream(blankimg);
                                dressortoppictureBox.Image = Image.FromStream(ms);
                            }
                        }





                        if (!DBNull.Value.Equals(row["bottomwear_slot"]))
                        {

                            if (!DBNull.Value.Equals(row[5]))
                            {
                                img = (byte[])row[5];


                                MemoryStream ms = new MemoryStream(img);
                                bottompictureBox.Image = Image.FromStream(ms);
                            }
                            else
                            {
                                MemoryStream ms = new MemoryStream(blankimg);
                                bottompictureBox.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {                    
                            MemoryStream ms = new MemoryStream(blankimg);
                            bottompictureBox.Image = Image.FromStream(ms);

                        }





                        if (!DBNull.Value.Equals(row["shoe_slot"]))
                        {

                            if (!DBNull.Value.Equals(row[7]))
                            {
                                img = (byte[])row[7];


                                MemoryStream ms = new MemoryStream(img);
                                shoepictureBox.Image = Image.FromStream(ms);
                            }
                            else
                            {
                                MemoryStream ms = new MemoryStream(blankimg);
                                shoepictureBox.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(blankimg);
                            shoepictureBox.Image = Image.FromStream(ms);

                        }




                        if (!DBNull.Value.Equals(row["bag_slot"]))
                        {
                            if (!DBNull.Value.Equals(row[9]))
                            {
                                img = (byte[])row[9];


                                MemoryStream ms = new MemoryStream(img);
                                bagpictureBox.Image = Image.FromStream(ms);
                            }
                            else
                            {
                                MemoryStream ms = new MemoryStream(blankimg);
                                bagpictureBox.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(blankimg);
                            bagpictureBox.Image = Image.FromStream(ms);

                        }
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Please choose the right row.");
                MessageBox.Show(ex.Message);
                combid = -1;
            }
        }

        private void form_user_createCombination_Load(object sender, EventArgs e)
        {
            list1();
            combid = -1;
        }

        private void list1()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT user_outfit_combination.id AS 'Combination ID', user_outfit_combination.user_id AS 'User ID', 
            user_outfit_combination.combination_name AS 'Combination Name', cloth.cloth_name AS dress_slot, 
            cloth2.cloth_name AS topwear_slot, cloth3.cloth_name AS bottomwear_slot, cloth4.cloth_name AS shoe_slot, 
            cloth5.cloth_name AS bag_slot, user_outfit_combination.sharing AS 'Sharing Status' FROM user_outfit_combination 
            LEFT JOIN cloth ON user_outfit_combination.dress_slot = cloth.id 
            LEFT JOIN cloth AS cloth2 ON user_outfit_combination.topwear_slot = cloth2.id 
            LEFT JOIN cloth AS cloth3 ON user_outfit_combination.bottomwear_slot = cloth3.id 
            LEFT JOIN cloth AS cloth4 ON user_outfit_combination.shoe_slot = cloth4.id 
            LEFT JOIN cloth AS cloth5 ON user_outfit_combination.bag_slot = cloth5.id WHERE user_outfit_combination.user_id = " + class_ProgramMaster.logged_user_id;
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void formtoexitlabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formtoaltlabel_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(combnametextBox.Text != "" && combnametextBox.Text != "Combination Name")
            {
                try
                {
                    int sharingstatus = 2;

                    if(checkBox1.CheckState == CheckState.Checked)
                    {
                        sharingstatus = 1;
                    }
                    else
                    {
                        sharingstatus = 2;
                    }

                    SqlCommand definecomb = new SqlCommand("INSERT INTO user_outfit_combination(user_id, combination_name, sharing) VALUES(@uid, @combname, @sh)", conn);
                    definecomb.Parameters.AddWithValue("@uid", SqlDbType.Int).Value = class_ProgramMaster.logged_user_id;
                    definecomb.Parameters.AddWithValue("@combname", SqlDbType.Int).Value = combnametextBox.Text;
                    definecomb.Parameters.AddWithValue("@sh", SqlDbType.Int).Value = sharingstatus;

                    conn.Open();
                    definecomb.ExecuteNonQuery();
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

        private void button2_Click(object sender, EventArgs e)
        {
            if(combid != -1)
            {
                try
                {
                    SqlCommand deletethiscombfavs = new SqlCommand("DELETE FROM user_favorite_combination WHERE combination_id = @id", conn);
                    deletethiscombfavs.Parameters.AddWithValue("@id", SqlDbType.Int).Value = combid;
                    conn.Open();
                    deletethiscombfavs.ExecuteNonQuery();
                    conn.Close();

                    SqlCommand deletecomb = new SqlCommand("DELETE FROM user_outfit_combination WHERE id = @id", conn);
                    deletecomb.Parameters.AddWithValue("@id", SqlDbType.Int).Value = combid;
                    conn.Open();
                    deletecomb.ExecuteNonQuery();
                    conn.Close();

                    list1();
                    combid = -1;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please double click and select the combination you want to delete.");
            }
        }

        private void form_user_createCombination_MouseDown(object sender, MouseEventArgs e)
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
    }
}
