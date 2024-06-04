namespace HRHiringSystem.Application.Features;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

//TODO: namespace HRHiringSystem.Application.Features???;

public interface IEmailSender
{
    Task SendEmailAsync(string email, string subject, string message);
}

public class EmailSender : IEmailSender
{
    private readonly EmailSettings _emailSettings;

    public EmailSender(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
        _emailSettings.Password = Environment.GetEnvironmentVariable("EMAIL_PASSWORD");
    }

    public async Task SendEmailAsync(string email, string subject, string message)
    {
        var smtpClient = new SmtpClient
        {
            Host = _emailSettings.Host,
            Port = _emailSettings.Port,
            EnableSsl = true,
            Credentials = new NetworkCredential(_emailSettings.UserName, _emailSettings.Password)
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(_emailSettings.SenderEmail, _emailSettings.SenderName),
            Subject = subject,
            Body = message,
            IsBodyHtml = true
        };

        mailMessage.To.Add(email);

        await smtpClient.SendMailAsync(mailMessage);
    }
}

public class EmailSettings
{
    public string Host { get; set; }
    public int Port { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string SenderName { get; set; }
    public string SenderEmail { get; set; }
}
