using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using thekumral.Core.Services.Mails;

namespace thekumral.Service.Services.MailService
{
    public class MailService : IMailService
    {
        private readonly EmailSettings _emailSettings;

        public MailService(IOptions<EmailSettings> emailOptions)
        {
            _emailSettings = emailOptions.Value;
        }

        public bool Send(string recipient, string subject, string body, bool isBodyHTML)
        {
            try
            {
                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(_emailSettings.Email),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = isBodyHTML
                };
                mailMessage.To.Add(new MailAddress(recipient));

                SmtpClient smtp = new SmtpClient
                {
                    Host = _emailSettings.SmtpServer,
                    Port = _emailSettings.SmtpPort,
                    EnableSsl = _emailSettings.EnableSsl,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_emailSettings.Email, _emailSettings.Password)
                };

                smtp.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
