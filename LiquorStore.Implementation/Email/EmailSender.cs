using LiquorStore.Application.DataTransfer;
using LiquorStore.Application.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Implementation.Email
{
    public class EmailSender : IEmailSender
    {
        public void Send(EmailDto dto)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("duka.asp@gmail.com", "Pass#word123")
            };

            var message = new MailMessage("duka.asp@gmail.com", dto.EmailTo);
            message.Subject = dto.Subject;
            message.Body = dto.Content;
            message.IsBodyHtml = true;
            smtp.Send(message);
        }
    }
}
