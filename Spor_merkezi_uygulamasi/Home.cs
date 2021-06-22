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
using Bunifu.UI.WinForms;

namespace Spor_merkezi_uygulamasi
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        
        private void Home_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'spormerkeziDataSon.ekipmanlar' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.ekipmanlarTableAdapter.Fill(this.spormerkeziDataSon.ekipmanlar);
            anaekranpanel.Visible = true;
            uyelerpanel.Visible = false;
            calisanpanel.Visible = false;
            ekipmanpanel.Visible = false;
            label1.Text = "Ana Ekran";
            pictureBox2.Image = Spor_merkezi_uygulamasi.Properties.Resources.home;
            label2.Text= DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            timer1.Start();
            Baglanti bgln = new Baglanti();
            using (SqlCommand cmdcount = new SqlCommand("select count(*) from kisiler",bgln.baglan())) 
            {
                try
                {
                    if (bgln.baglan().State != ConnectionState.Open)
                    {
                        bgln.baglan().Open();
                    }
                    uyelabel.Text = cmdcount.ExecuteScalar().ToString();
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
            using (SqlCommand cmdcount2 = new SqlCommand("select count(*) from calisanlar",bgln.baglan())) 
            {
                try
                {
                    if (bgln.baglan().State != ConnectionState.Open)
                    {
                        bgln.baglan().Open();
                    }
                    calisanlabel.Text = cmdcount2.ExecuteScalar().ToString();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text= DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
        }

        private void Anaekranbutton_Click(object sender, EventArgs e)
        {
            anaekranpanel.Visible = true;
            uyelerpanel.Visible = false;
            calisanpanel.Visible = false;
            ekipmanpanel.Visible = false;
            label1.Text = "Ana Ekran";
            pictureBox2.Image = Spor_merkezi_uygulamasi.Properties.Resources.home;
            Baglanti bgln = new Baglanti();
            using (SqlCommand cmdcount = new SqlCommand("select count(*) from kisiler",bgln.baglan())) 
            {
                try
                {
                    if (bgln.baglan().State != ConnectionState.Open)
                    {
                        bgln.baglan().Open();
                    }
                    uyelabel.Text = cmdcount.ExecuteScalar().ToString();
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
            using (SqlCommand cmdcount2 = new SqlCommand("select count(*) from calisanlar",bgln.baglan())) 
            {
                try
                {
                    if (bgln.baglan().State != ConnectionState.Open)
                    {
                        bgln.baglan().Open();
                    }
                    calisanlabel.Text = cmdcount2.ExecuteScalar().ToString();
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

        private void uyegosterbuton_Click(object sender, EventArgs e)
        {
            Uyegoruntule gecisuyUyegoruntule = new Uyegoruntule();
            this.Hide();
            gecisuyUyegoruntule.ShowDialog();
            this.Show();
        }

        private void uyeklebuton_Click(object sender, EventArgs e)
        {
            Uyeekle gecisuUyeekle = new Uyeekle();
            this.Hide();
            gecisuUyeekle.ShowDialog();
            this.Show();
        }

        private void uyeguncellebuton_Click(object sender, EventArgs e)
        {
            Uyeguncelle gecisUyeguncelle = new Uyeguncelle();
            this.Hide();
            gecisUyeguncelle.ShowDialog();
            this.Show();
        }

        private void uyesilbuton_Click(object sender, EventArgs e)
        {
            Uyesil gecisUyesil = new Uyesil();
            this.Hide();
            gecisUyesil.ShowDialog();
            this.Show();

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            anaekranpanel.Visible = false;
            uyelerpanel.Visible = true;
            calisanpanel.Visible = false;
            ekipmanpanel.Visible = false;
            label1.Text = "Üye işlemleri";
            pictureBox2.Image = Spor_merkezi_uygulamasi.Properties.Resources.addmember;
            
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            trackBar1.Value = axWindowsMediaPlayer1.settings.volume/10;
            axWindowsMediaPlayer1.URL = "http://kralpopwmp.radyotvonline.com:80/";
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            trackBar1.Value = axWindowsMediaPlayer1.settings.volume/10;
            axWindowsMediaPlayer1.URL = "https://radio-trtfm.live.trt.com.tr/master.m3u8";
            
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            trackBar1.Value = axWindowsMediaPlayer1.settings.volume/10;
            axWindowsMediaPlayer1.URL = "http://46.20.7.126/;stream.mp3";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = trackBar1.Value * 10;
        }

        private void bunifuTileButton5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Calisanguncelle gecisCalisanguncelle = new Calisanguncelle();
            gecisCalisanguncelle.ShowDialog();
            this.Show();
        }

        private void bunifuTileButton6_Click(object sender, EventArgs e)
        {
            //this.Hide();
            personelekle gecisPersonelekle = new personelekle();
            gecisPersonelekle.ShowDialog();
            this.Show();
        }

        private void bunifuTileButton4_Click(object sender, EventArgs e)
        {
            personelgoruntule gecisPersonelgoruntule = new personelgoruntule();
            this.Hide();
            gecisPersonelgoruntule.ShowDialog();
            this.Show();
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            personelsil gecisPersonelsil = new personelsil();
            this.Hide();
            gecisPersonelsil.ShowDialog();
            this.Show();
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            string message = "Kapatmak istediğinize emin misiniz?";  
            string title = "Çıkış";  
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;  
            DialogResult result = MessageBox.Show(message, title, buttons,MessageBoxIcon.Question);  
            if (result == DialogResult.Yes)
            {
                Giris gecisGiris = new Giris();
                gecisGiris.Show();
            } else
            {
                e.Cancel = true;
            }  
        }

        private void bunifuTileButton7_Click(object sender, EventArgs e)
        {
            ekipmanlar gecisEkipmanlar = new ekipmanlar();
            this.Hide();
            gecisEkipmanlar.ShowDialog();
            this.Show();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            anaekranpanel.Visible = false;
            uyelerpanel.Visible = false;
            calisanpanel.Visible = true;
            ekipmanpanel.Visible = false;
            label1.Text = "Personel işlemleri";
            pictureBox2.Image = Spor_merkezi_uygulamasi.Properties.Resources.staff;
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            anaekranpanel.Visible = false;
            uyelerpanel.Visible = false;
            calisanpanel.Visible = false;
            ekipmanpanel.Visible = true;
            label1.Text = "Ekipmanlar";
            pictureBox2.Image = Spor_merkezi_uygulamasi.Properties.Resources.icon;
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            Giris gecisGiris = new Giris();
            this.Close();
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            adminayarlari gecisaAdminayarlari = new adminayarlari();
            gecisaAdminayarlari.ShowDialog();
        }
    }
    
}
