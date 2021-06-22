using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Spor_merkezi_uygulamasi
{
    public partial class Giris : Form
    {


        public Giris()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            Baglanti bgln = new Baglanti();
            SqlCommand komut = new SqlCommand("select * from admin where username = '" + username +
                                              "'and + password = '" + password + "'", bgln.baglan());
            SqlDataReader oku = komut.ExecuteReader();
            try
            {
                if (bgln.baglan().State == ConnectionState.Closed)
                {
                    bgln.baglan().Open();
                }

                if (oku.Read())
                {
                    this.Hide();
                    Home gecishome = new Home();
                    gecishome.Show();
                }
                else
                {
                    MessageBox.Show("Hatalı kullanıcı adı veya şifre girdiniz!");
                }

            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, hata.Message);
            }
            finally
            {
                bgln.baglan().Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bilgi gecisBilgi = new Bilgi();
            gecisBilgi.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sifremiunuttum gecissifremiunuttum = new sifremiunuttum();
            gecissifremiunuttum.ShowDialog();
        }
    }
}
