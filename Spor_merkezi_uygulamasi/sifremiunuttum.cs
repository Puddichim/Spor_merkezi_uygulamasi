using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Spor_merkezi_uygulamasi
{
    public partial class sifremiunuttum : Form
    {
        public sifremiunuttum()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Baglanti bgln = new Baglanti();
            SqlCommand cmd =
                new SqlCommand(
                    "select * from admin where username='" + textBox1.Text.ToString() + "'and email='"+textBox2.Text.ToString()+"'",
                    bgln.baglan());
            SqlDataReader oku = cmd.ExecuteReader();
            if (oku.Read())
            {
                try
                {
                    if (bgln.baglan().State == ConnectionState.Closed)
                    {
                        bgln.baglan().Open();
                    }
                     
                    SmtpClient smptserver = new SmtpClient();
                    MailMessage mail = new MailMessage();
                    string tarih = DateTime.Now.ToLongDateString();
                    string mailadresi = ("gaziprojehesabi@gmail.com");
                    string sifre = ("gaziproje06");
                    string smtpsrvr = ("smtp.gmail.com");
                    string kime = (oku["email"].ToString());
                    string konu = ("Şifre hatırlatma talebi");
                    string yazı = ("Sayın,"+oku["username"].ToString()+""+"\n"+"Bizden "+tarih+" tarihinde şifre hatırlatma talebinde bulundunuz."+"\n"+"Parolanız:"+oku["password"].ToString()+""+"\n"+"İyi günler.");
                    smptserver.Credentials = new NetworkCredential(mailadresi, sifre);
                    smptserver.Port = 587;
                    smptserver.Host = smtpsrvr;
                    smptserver.EnableSsl= true;
                    mail.From = new MailAddress(mailadresi);
                    mail.To.Add(kime);
                    mail.Subject = konu;
                    mail.Body = yazı;
                    smptserver.Send(mail);
                    DialogResult bilgi = new DialogResult();
                    bilgi = MessageBox.Show(
                        "Girmiş olduğunuz bilgiler uyuşmaktadır, şifreniz mail adresinize gönderillmiştir.");
                    this.Close();

                }
                catch (Exception exception)
                {
                    MessageBox.Show("Mail gönderme hatası"+exception.ToString()
                                                          +"");
                }
                finally
                {
                    bgln.baglan().Close();
                }
            }
        }
    }
}
