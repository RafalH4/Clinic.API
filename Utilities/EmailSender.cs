using MailKit.Net.Smtp;
using MimeKit;

namespace Clinic.API.Utilities
{
    public static class EmailSender
    {
        public static void SendEmail(string toEmail, string title, string body)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("kinopz.wat@gmail.com", "projekt428"));
            message.To.Add(new MailboxAddress("Pacjent", toEmail));
            message.Subject = title;

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = body;
            bodyBuilder.TextBody = "Hello world";

            message.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 465, true);
            client.Authenticate("kinopz.wat@gmail.com", "projekt428");
            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
        }
    }
}
