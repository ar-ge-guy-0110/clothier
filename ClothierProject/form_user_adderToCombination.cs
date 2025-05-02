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
    public partial class form_user_adderToCombination : Form
    {
        SqlConnection conn = class_dbconnections.connect;

        int combid;
        public form_user_adderToCombination()
        {
            InitializeComponent();
        }

        private void form_user_adderToCombination_Load(object sender, EventArgs e)
        {
            combid = -1;
            list1();
        }

        private void formtoexitlabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formtoaltlabel_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void form_user_adderToCombination_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                class_borderlessmove.ReleaseCapture();
                class_borderlessmove.SendMessage(Handle, class_borderlessmove.WM_NCLBUTTONDOWN, class_borderlessmove.HT_CAPTION, 0);
            }
        }

        private void createcombbutton_Click(object sender, EventArgs e)
        {
            if(class_ProgramMaster.cloth_maincategory_for_combination == "Dresses")
            {
                addToComb("dress_slot");
            }
            else if(class_ProgramMaster.cloth_maincategory_for_combination == "Top Wears")
            {
                addToComb("topwear_slot");
            }
            else if(class_ProgramMaster.cloth_maincategory_for_combination == "Bottom Wears")
            {
                addToComb("bottomwear_slot");
            }
            else if(class_ProgramMaster.cloth_maincategory_for_combination == "Shoes")
            {
                addToComb("shoe_slot");
            }
            else
            {
                addToComb("bag_slot");
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {

                    combid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                }

            }
            catch
            {
                MessageBox.Show("Please choose the right row.");
                combid = -1;
            }
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

        private void addToComb(string n)
        {
            if(combid != -1)
            {
                SqlCommand updatecomb = new SqlCommand("UPDATE user_outfit_combination SET " + n + " = @cid WHERE id = @combid", conn);
                updatecomb.Parameters.AddWithValue("@cid", SqlDbType.Int).Value = class_ProgramMaster.cloth_id_for_combination;
                updatecomb.Parameters.AddWithValue("@combid", SqlDbType.Int).Value = combid;
                conn.Open();
                updatecomb.ExecuteNonQuery();
                conn.Close();

                if(n == "dress_slot")
                {
                    SqlCommand updatecomb2 = new SqlCommand("UPDATE user_outfit_combination SET topwear_slot = NULL WHERE id = @combid", conn);
                    updatecomb2.Parameters.AddWithValue("@combid", SqlDbType.Int).Value = combid;
                    conn.Open();
                    updatecomb2.ExecuteNonQuery();
                    conn.Close();
                }
                else if(n == "topwear_slot")
                {
                    SqlCommand updatecomb3 = new SqlCommand("UPDATE user_outfit_combination SET dress_slot = NULL WHERE id = @combid", conn);
                    updatecomb3.Parameters.AddWithValue("@combid", SqlDbType.Int).Value = combid;
                    conn.Open();
                    updatecomb3.ExecuteNonQuery();
                    conn.Close();
                }

                list1();
            }
            else
            {
                MessageBox.Show("Please double click and select the combination you want to add into.");
            }
        }
    }
}
