using System.Net;
using System.Net.Mail;

namespace TopLearn.Core.Senders;
public class SendEmail
{
    public static void Send(string to, string subject, string body)
    {
        using (MailMessage mail = new MailMessage())
        {
            using (SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com"))
            {
                mail.From = new MailAddress("it93mohammad@gmail.com", "فروشگاه تست تاپ لرن");
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                SmtpServer.Port = 465;
                SmtpServer.Credentials = new NetworkCredential("it93mohammad@gmail.com", "clqtnirisjnphmrg");
                SmtpServer.EnableSsl = true;

                try
                {
                    SmtpServer.Send(mail);
                    Console.WriteLine("sending email... ");
                }
                catch (Exception ex)
                {
                    // Handle exception (e.g., log it)
                    Console.WriteLine("Error sending email: " + ex.ToString());
                }
            }
        }
    }
}
