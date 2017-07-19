using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMail
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                System.Net.Mail.MailAddress from = new System.Net.Mail.MailAddress(address: "anawat@seniorsoft.co.th"/*, displayName: "POND"*/);
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.From = from;
                //mail.To.Add("duangporn@seniorsoft.co.th");
                //mail.Bcc.Add("wongsapat@seniorsoft.co.th");
                //mail.Bcc.Add("thunwa@seniorsoft.co.th");

                mail.To.Add("devdailyprogress@seniorsoft.co.th");
                //mail.To.Add("wasan@seniorsoft.co.th");

                mail.Subject = "ขอส่งสรุปประจำวันที่ " + DateTime.Now.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.GetCultureInfo("th-TH")) + " โดยแนบไฟล์ Excel มาด้วยครับ";
                mail.Body = null;
                mail.IsBodyHtml = true;

                System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(@"C:\Users\senior\Desktop\20170703_DailyProgress_Pond.xlsx");
                mail.Attachments.Add(attachment);

                System.Net.Mail.SmtpClient smtpMail = new System.Net.Mail.SmtpClient("smtp.gmail.com");
                smtpMail.Port = 25;
                smtpMail.EnableSsl = true;

                smtpMail.Credentials = new System.Net.NetworkCredential("anawat@seniorsoft.co.th", System.IO.File.ReadAllText("..\\..\\in")); // ใส่อีเมล์และรหัสผ่านของอีเมล์ฝั่งเซิร์ฟเวอร์
                smtpMail.Timeout = 200000;  //200วินาที
                smtpMail.Send(mail);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
            }
        }
    }
}
