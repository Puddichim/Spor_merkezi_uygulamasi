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
    public partial class personelekle : Form
    {
        public personelekle()
        {
            InitializeComponent();
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            bunifuTextBox1.Clear();
            bunifuTextBox4.Clear();
            bunifuTextBox5.Clear();
            bunifuTextBox3.Clear();
            bunifuTextBox2.Clear();
            bunifuRadioButton3.Checked = false;
            bunifuRadioButton4.Checked = false;
            bunifuDatePicker2.Value = DateTime.Now;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string gender = "";
            if (bunifuRadioButton3.Checked)
            {
                gender = "Bay";
            }

            if (bunifuRadioButton4.Checked)
            {
                gender = "Bayan";
            }

            int x = int.Parse(bunifuTextBox2.Text);
            Baglanti bgln = new Baglanti();
            SqlCommand komut = new SqlCommand(
                    "INSERT INTO calisanlar (isim,soyisim,plan_türü,ücret,cinsiyet,telefon,doğum_tarihi,katılma_tarihi) VALUES ('"+bunifuTextBox4.Text+"','"+bunifuTextBox5.Text+"','"+bunifuTextBox1.Text+"','"+x+"','"+gender+"','"+bunifuTextBox3.Text+"','"+bunifuDatePicker1.Value.Date.ToString("MM/dd/yyyy")+"','"+bunifuDatePicker2.Value.Date.ToString("MM/dd/yyyy")+"')",
                    bgln.baglan());
            komut.ExecuteNonQuery();
            bgln.baglan().Close();
            MessageBox.Show("Personel başarıyla eklendi!","Başarılı",MessageBoxButtons.OK);
        }

        private void personelekle_Load(object sender, EventArgs e)
        {
            bunifuDatePicker2.Value = DateTime.Now;
            bunifuTextBox1.Clear();
            bunifuTextBox4.Clear();
            bunifuTextBox5.Clear();
            bunifuTextBox3.Clear();
            bunifuTextBox2.Clear();
            bunifuRadioButton3.Checked = false;
            bunifuRadioButton4.Checked = false;
        }
    }
}
