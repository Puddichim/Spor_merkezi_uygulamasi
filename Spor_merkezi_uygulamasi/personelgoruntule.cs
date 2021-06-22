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

namespace Spor_merkezi_uygulamasi
{
    public partial class personelgoruntule : Form
    {
        public personelgoruntule()
        {
            InitializeComponent();
        }

        private Baglanti bgln = new Baglanti();
        public void verilerigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler,bgln.baglan());
            DataSet ds = new DataSet();
            da.Fill(ds);

            bunifuDataGridView1.DataSource = ds.Tables[0];
        }
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            verilerigoster("select *from calisanlar");
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
