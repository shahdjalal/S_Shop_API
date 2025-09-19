using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;
using System.Net;

namespace Shahd_PresentationL.Utils
{
    public class EmailSetting : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("shahdjalal2018@gmail.com", "osbm rqmk xmlo ayoo")
            };

            return client.SendMailAsync(
                new MailMessage(from: "shahdjalal2018@gmail.com",
                                to: email,
                                subject,
                                htmlMessage
                                )
                { IsBodyHtml = true });
            

        }
    }
    
}
