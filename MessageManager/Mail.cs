using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace MessageManager
{
    public class Mail : IMessage
    {
        public List<string> mailRecipients { get; set; }
        public string mailFrom { get; set; }
        public string mailSubject { get; set; }
        public string mailBody { get; set; }
        public bool isBodyHtml { get; set; }

        public MailMessage email;
        public SmtpClient smtp;

        public Mail(List<string> mailRecipients, string from, string subject, string body, bool isHtml)
        {
            this.mailRecipients = mailRecipients;
            this.mailFrom = from;
            this.mailSubject = subject;
            this.mailBody = body;
            this.isBodyHtml = isHtml;

            this.email = new MailMessage();
            this.smtp = new SmtpClient();

            CreateMailMessage();

            string smtp = Config.Get("smtp_server");
            int port = Convert.ToInt32(Config.Get("port"));
            string user = Config.Get("user");
            string pass = Config.Get("pass");

            CreateSMTP(smtp, port, user, pass);
        }

        private bool CreateMailMessage()
        {
            try
            {

                foreach (string to in mailRecipients)
                    email.To.Add(new MailAddress(to));

                email.From = new MailAddress(mailFrom);
                email.Subject = mailSubject;
                email.Body = mailBody;
                email.IsBodyHtml = isBodyHtml;
                email.Priority = MailPriority.Normal;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private bool CreateSMTP(string smtpServer, int port, string user, string pass)
        {
            try
            {

                smtp.Host = smtpServer;
                smtp.Port = port;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(user, pass);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Send()
        {
            try
            {
                smtp.Send(email);
                email.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                //output = "Error enviando correo electrónico: " + ex.Message;
                return false;
            }
        }
    }
}
