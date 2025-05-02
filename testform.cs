using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClothierProject
{
    public partial class testform : Form
    {
        public testform()
        {
            InitializeComponent();
        }

        private void testform_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'clothierdbDataSetAccounts.user_account' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.user_accountTableAdapter.Fill(this.clothierdbDataSetAccounts.user_account);

        }
    }
}
