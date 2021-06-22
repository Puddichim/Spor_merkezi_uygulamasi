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

namespace Spor_merkezi_uygulamasi
{
    public partial class Uyesil : Form
    {
        public Uyesil()
        {
            InitializeComponent();
        }

        private Baglanti bgln = new Baglanti();
        private void yenile()  
        {  
            if (bgln.baglan().State != ConnectionState.Open)
            {
                bgln.baglan().Open();
            }
            DataTable dt=new DataTable();
            SqlDataAdapter adapt;
            adapt=new SqlDataAdapter("select * from kisiler",bgln.baglan());  
            bunifuDataGridView1.DataSource = dt;  
            adapt.Fill(dt);  
            bgln.baglan().Close();
        } 
        private void bunifuButton10_Click(object sender, EventArgs e)
        {
            Baglanti bgln = new Baglanti();
            SqlCommand cmd = new SqlCommand("delete from kisiler where id='"+bunifuTextBox1.Text+"'", bgln.baglan());
            if (bgln.baglan().State != ConnectionState.Open)
            {
                bgln.baglan().Open();
            }
            cmd.ExecuteNonQuery();
            bgln.baglan().Close();
            bunifuTextBox1.Text = "";
            MessageBox.Show("Başarıyla silindi.");
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            yenile();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void bunifuDataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in bunifuDataGridView1.SelectedRows)
            {
                bunifuTextBox1.Text = row.Cells[0].Value.ToString();
            }
        }
    }
}
