using System.Net;
using System.Net.Mail;
namespace MailNameSpace;
public class MailSender
{
    private string _smtpServer;
    private int _smtpPort;
    private string _fromEmail;
    private string _password;
    public MailSender(string smtpServer, int smtpPort, string fromEmail, string password)
    {
        _smtpServer = smtpServer;
        _smtpPort = smtpPort;
        _fromEmail = fromEmail;
        _password = password;
    }
    public bool SendMail(string toEmail, string subject, string body)
    {
        try
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(_fromEmail);
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient(_smtpServer, _smtpPort))
                {
                    smtp.Credentials = new NetworkCredential(_fromEmail, _password);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
            return true;
        }
        catch
        {
            return false;
        }
    }
}