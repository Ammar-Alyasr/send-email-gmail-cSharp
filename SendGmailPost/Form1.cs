using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;


namespace SendGmailPost
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string to = textBox1.Text;

            string subj = textBox2.Text;

            string msj = richTextBox1.Text;

            string mail = textBox4.Text;

            string pass = textBox3.Text;

            Send(to, subj, msj, mail, pass);


        }

        public void Send(string to, string subject, string msj , string yourMail, string pass)
        {


            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";

            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(yourMail, pass);
            //smtp.Credentials = new NetworkCredential("yaaserhamod@gmail.com", "258025802yaser");

            using (var message = new MailMessage(yourMail, to))
            {
                try
                {
                    message.Subject = subject;
                    message.Body = msj;
                    //message.Body = @"<h2>oops , Sitenizden birinde Değişiklik olmuştur ...  </h2><p></p><p>Bilgileri Aşağıda yeralan Site Şu Durumla Karşılaşmıştır: '" + Durum + "' </p> <p></p>Site Adi: '" + Adi + "'  <p></p>Site URL: '" + url + "' <p></p>Site Son Durumu: '" + Durum + "' <p></p>Site Son Güncelleme Zamanı '" + Songuncelleme + "' <p></p><p></p><p></p>  <h1>Iyi Kodlamalar)...</h1>";

                    message.IsBodyHtml = true;
                    smtp.Send(message);

                    MessageBox.Show("Ok");

                }
                catch (Exception ext)
                {
                    MessageBox.Show("Didnt sent !!!!",ext.ToString());

                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "Aslo you can paste any html code here like <h2> this is bold text</h2> <p></p> normal text ";
        }
    }
}
