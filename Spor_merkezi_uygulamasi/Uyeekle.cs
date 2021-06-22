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
using Utilities.BunifuCheckBox.Transitions;

namespace Spor_merkezi_uygulamasi
{
    public partial class Uyeekle : Form
    {
        public Uyeekle()
        {
            InitializeComponent();
        }
        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            bunifuTextBox1.Clear();
            bunifuTextBox2.Clear();
            bunifuTextBox3.Clear();
            bunifuRadioButton1.Checked = false;
            bunifuRadioButton2.Checked = false;
            bunifuDatePicker2.Value = DateTime.Now;
        }

        private void Uyeekle_Load(object sender, EventArgs e)
        {
            bunifuTextBox1.Clear();
            bunifuTextBox2.Clear();
            bunifuTextBox3.Clear();
            bunifuRadioButton1.Checked = false;
            bunifuRadioButton2.Checked = false;
            bunifuDatePicker2.Value = DateTime.Now;
            
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            string gender=null;
            if (bunifuRadioButton1.Checked)
            {
                gender = "Bay";
            }
            if (bunifuRadioButton2.Checked)
            {
                gender ="Bayan";
            }

            string poo = "";

            if (checkBox1.Checked)
            {
                poo = poo + "Havuz";
            }

            if (checkBox2.Checked)
            {
                if (poo != "")
                {
                    poo = poo + " ";
                }
                poo = poo + "Tenis";
            }

            if (checkBox3.Checked)
            {
                if (poo != "")
                {
                    poo = poo + " ";
                }
                poo = poo + "Spor Salonu";
            }
            Baglanti bgln = new Baglanti();
            SqlCommand komut =
                new SqlCommand(
                    "INSERT INTO kisiler (isim,soyisim,plan_türü,cinsiyet,telefon,doğum_tarihi,katılma_tarihi) VALUES ('"+bunifuTextBox1.Text+"','"+bunifuTextBox2.Text+"','"+poo+"','"+gender+"',"+bunifuTextBox3.Text+",'"+bunifuDatePicker1.Value.Date.ToString("MM/dd/yyyy")+"','"+bunifuDatePicker2.Value.Date.ToString("MM/dd/yyyy")+"')",
                    bgln.baglan());
            komut.ExecuteNonQuery();
            bgln.baglan().Close();
            MessageBox.Show("Üye eklendi!");
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
