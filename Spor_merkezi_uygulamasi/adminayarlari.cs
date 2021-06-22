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
    public partial class adminayarlari : Form
    {
        public adminayarlari()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Baglanti bgln = new Baglanti();
            SqlCommand cmd = new SqlCommand("select username,password,email from admin where id=@id",bgln.baglan());
            cmd.Parameters.AddWithValue("@id", 0);
            if (bgln.baglan().State != ConnectionState.Open)
            {
                bgln.baglan().Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr.GetValue(0).ToString();
                textBox2.Text = dr.GetValue(1).ToString();
                textBox3.Text = dr.GetValue(2).ToString();
            }
            bgln.baglan().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Baglanti bgln = new Baglanti();
            SqlCommand cmd = new SqlCommand("UPDATE admin SET username=@username,password=@password,email=@email where id=@id",bgln.baglan());
            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            cmd.Parameters.AddWithValue("@password", textBox2.Text);
            cmd.Parameters.AddWithValue("@email", textBox3.Text);
            cmd.Parameters.AddWithValue("@id", 0);
            try
            {
                if (bgln.baglan().State != ConnectionState.Open)
                {
                    bgln.baglan().Open();
                }

                cmd.ExecuteNonQuery();
                MessageBox.Show("Başarılı!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                bgln.baglan().Close();
            }
        }
    }
}
