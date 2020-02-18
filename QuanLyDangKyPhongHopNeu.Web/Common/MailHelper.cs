using QuanLyDangKyPhongHopNeu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace QuanLyDangKyPhongHopNeu.Web.Common
{
    public class MailHelper
    {
       QuanLyDangKyPhongHopNeuDbContext db =null;

        public  MailHelper()
        {
            this.db = new QuanLyDangKyPhongHopNeuDbContext();
        }

        public  bool SendMail(string toEmail, string subject, string content)
        {
            try
            {
                var mailConfig = db.Mails.AsEnumerable();
                var FromEmail = mailConfig.Where(x => x.ValueOfMail == 6);
                var Password = mailConfig.Where(x => x.ValueOfMail == 7);
                var host = GetConfig.GetByKey("SMTPHost");
                var port = int.Parse(GetConfig.GetByKey("SMTPPort"));
                var fromEmail = FromEmail.First().TenMail;
                var password = Password.First().TenMail;
                var fromName = GetConfig.GetByKey("FromName");

                var smtpClient = new SmtpClient(host, port)
                {
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(fromEmail, password),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true,
                    Timeout = 100000
                };

                var mail = new MailMessage
                {
                    Body = content,
                    Subject = subject,
                    From = new MailAddress(fromEmail, fromName)
                };

                mail.To.Add(new MailAddress(toEmail));
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                smtpClient.Send(mail);

                return true;
            }
            catch (SmtpException smex)
            {

                return false;
            }
        }
    }
}