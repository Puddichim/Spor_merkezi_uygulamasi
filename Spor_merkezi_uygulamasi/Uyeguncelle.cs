using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;

namespace Spor_merkezi_uygulamasi
{
    public partial class Uyeguncelle : Form
    {
        
        public Uyeguncelle()
        {
            InitializeComponent();
        }
        Baglanti bgln = new Baglanti();
        
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
        private void Uyeguncelle_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'spormerkeziDS.kisiler' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.kisilerTableAdapter.Fill(this.spormerkeziDS.kisiler);
            yenile();
        }

        private void bunifuDataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in bunifuDataGridView1.SelectedRows)
            {
                label1.Text = row.Cells[0].Value.ToString();
                if (row.Cells[1].Value != "")
                {
                    bunifuTextBox1.Text = row.Cells[1].Value.ToString();
                }
                else
                {
                    bunifuTextBox1.Text = "";
                }
                if (row.Cells[2].Value != "")
                {
                    bunifuTextBox2.Text = row.Cells[2].Value.ToString();
                }
                else
                {
                    bunifuTextBox2.Text = "";
                }
                if (row.Cells[5].Value != "")
                {
                    bunifuTextBox3.Text = row.Cells[5].Value.ToString();
                }
                else
                {
                    bunifuTextBox3.Text = "";
                }
                if (row.Cells[4].Value.ToString() == "Bay")
                {
                    bunifuRadioButton1.Checked = true;
                    bunifuRadioButton2.Checked = false;
                }
                if (row.Cells[4].Value.ToString() == "Bayan")
                {
                    bunifuRadioButton2.Checked = true;
                    bunifuRadioButton1.Checked = false;
                }

                if (row.Cells[6].Value != null)
                {
                    bunifuDatePicker1.Value = Convert.ToDateTime(row.Cells[6].Value);
                }
                
                if (row.Cells[3].Value.ToString().Contains("Havuz"))
                {
                    bunifuCheckBox3.Checked = true;
                }
                else
                {
                    bunifuCheckBox3.Checked = false;
                }
                if (row.Cells[3].Value.ToString().Contains("Tenis"))
                {
                    bunifuCheckBox1.Checked = true;
                }
                else
                {
                    bunifuCheckBox1.Checked = false;
                }
                if (row.Cells[3].Value.ToString().Contains("Spor Salonu"))
                {
                    bunifuCheckBox2.Checked = true;
                }
                else
                {
                    bunifuCheckBox2.Checked = false;
                }
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string kekw = "";
            if (bunifuCheckBox3.Checked)
            {
                kekw = kekw + "Havuz";
            }

            if (bunifuCheckBox1.Checked)
            {
                if (kekw != "")
                {
                    kekw = kekw + " ";
                }
                kekw = kekw + "Tenis";
            }

            if (bunifuCheckBox2.Checked)
            {
                if (kekw != "")
                {
                    kekw = kekw + " ";
                }

                kekw = kekw + "Spor Salonu";
            }

            string gender = "";
            if(bunifuRadioButton1.Checked)
                gender = "Bay";
            if (bunifuRadioButton2.Checked)
                gender = "Bayan";


            SqlCommand cmd =
                new SqlCommand(
                    "update kisiler set isim='" + bunifuTextBox1.Text + "',soyisim='" + bunifuTextBox2.Text + "',plan_türü='"+kekw+"',cinsiyet='"+gender+"',telefon='"+bunifuTextBox3.Text+"',doğum_tarihi='"+bunifuDatePicker1.Value.Date.ToString("MM/dd/yyyy")+"'where id = '"+int.Parse(label1.Text)+"'",
                    bgln.baglan());
            cmd.ExecuteNonQuery();
            bgln.baglan().Close();

            bunifuTextBox1.Text = "";
            bunifuTextBox2.Text = "";
            bunifuTextBox3.Text = "";
            bunifuRadioButton1.Checked = false;
            bunifuRadioButton2.Checked = false;
            bunifuCheckBox1.Checked = false;
            bunifuCheckBox2.Checked = false;
            bunifuCheckBox3.Checked = false;
            bunifuDataGridView1.Update();
            bunifuDataGridView1.Refresh();
            yenile();
        }

        private void  bunifuButton4_Click(object sender, EventArgs e)
        {
            bunifuTextBox1.Text = "";
            bunifuTextBox2.Text = "";
            bunifuTextBox3.Text = "";
            bunifuRadioButton1.Checked = false;
            bunifuRadioButton2.Checked = false;
            bunifuCheckBox1.Checked = false;
            bunifuCheckBox2.Checked = false;
            bunifuCheckBox3.Checked = false;
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuButton10_Click(object sender, EventArgs e)
        {
            yenile();
        }
    }
}
