

// MailService
using System.Net;
using System.Net.Mail;

namespace HouseForSale_Api.Services.MailService
{
    public class MailService
    {
        private readonly string _smtpServer = "smtp.gmail.com";
        private readonly string _smtpUsername = "houseforsaleoffical@gmail.com"; // Gmail adresi
        private readonly string _smtpPassword = "ertc herl vall camt";          // Gmail şifresi
        private readonly string _fromEmail = "houseforsaleoffical@gmail.com";

        public void SendVerificationEmail(string toEmail, string verificationCode)
        {
            var client = new SmtpClient(_smtpServer, 587)
            {
                Credentials = new NetworkCredential(_smtpUsername, _smtpPassword),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_fromEmail),
                Subject = "Hesap Doğrulama",
                Body = $"Doğrulama Kodu: {verificationCode}",
                IsBodyHtml = true
            };

            mailMessage.To.Add(toEmail);

            try
            {
                client.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw new Exception("E-posta gönderilirken bir hata oluştu: " + ex.Message);
            }
        }
    }
}