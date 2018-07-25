using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace WeddingMVC
{
    public static class Helper
    {
        public static string MD5Hash(string input)
        {
            byte[] data = System.Security.Cryptography.MD5.Create().ComputeHash
            (System.Text.Encoding.UTF8.GetBytes(input));
            string md5 = "";
            for (int i = 0; i < data.Length; i++)
            {
                md5 += data[i].ToString("x2");
            }
            return md5;
        }

        public static string Random32()
        {
            return Guid.NewGuid().ToString("N");
        }







        public static bool SendMail(string userMail, string subject, string body, bool isHTML = false)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.IsBodyHtml = isHTML;
                mail.From = new MailAddress("kristina.makalatia1993@gmail.com", "Confimation Male");
                mail.To.Add(userMail);
                mail.Subject = subject;
                mail.Body = body;
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
                smtpServer.Port = 587;
                smtpServer.Credentials = new NetworkCredential("kristina.makalatia1993@gmail.com", "gmailkristina");
                smtpServer.EnableSsl = true;
                smtpServer.Send(mail);
                return true;
            }
            catch
            {

                return false;
            }
        }



    }
}