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
    public partial class Calisanguncelle : Form
    {
        public Calisanguncelle()
        {
            InitializeComponent();
        }

        private Baglanti bgln = new Baglanti();
        private SqlDataAdapter da;


        void yenile()
        {
            if (bgln.baglan().State != ConnectionState.Open)
            {
                bgln.baglan().Open();
            }
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select *from calisanlar", bgln.baglan());
            dt.Clear();
            da.Fill(dt);
            bgln.baglan().Close();
            bunifuDataGridView1.DataSource = dt;
            bunifuDataGridView1.AllowUserToAddRows = false;
        }
        private void Musteri_Load(object sender, EventArgs e)
        {
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            yenile();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            for(int item=0; item <= bunifuDataGridView1.Rows.Count-1 ; item++)
            {
                SqlCommand cmd2 = new SqlCommand("update calisanlar set isim=@isim,soyisim=@soyisim,plan_türü=@plan,ücret=@ücret,cinsiyet=@cinsiyet,telefon=@telefon,doğum_tarihi=@doğum,katılma_tarihi=@katılma where id='"+bunifuDataGridView1.Rows[item].Cells[0].Value+"'",bgln.baglan());
                cmd2.Parameters.AddWithValue("@isim", bunifuDataGridView1.Rows[item].Cells[1].Value);
                cmd2.Parameters.AddWithValue("@soyisim", bunifuDataGridView1.Rows[item].Cells[2].Value);
                cmd2.Parameters.AddWithValue("@plan", bunifuDataGridView1.Rows[item].Cells[3].Value);
                cmd2.Parameters.AddWithValue("@ücret", bunifuDataGridView1.Rows[item].Cells[4].Value);
                cmd2.Parameters.AddWithValue("@cinsiyet", bunifuDataGridView1.Rows[item].Cells[5].Value);
                cmd2.Parameters.AddWithValue("@telefon", bunifuDataGridView1.Rows[item].Cells[6].Value);
                cmd2.Parameters.AddWithValue("@doğum", bunifuDataGridView1.Rows[item].Cells[7].Value);
                cmd2.Parameters.AddWithValue("@katılma", bunifuDataGridView1.Rows[item].Cells[8].Value);
                if (bgln.baglan().State != ConnectionState.Open)
                {
                    bgln.baglan().Open();
                }
                cmd2.ExecuteNonQuery();
                bgln.baglan().Close();
            }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
