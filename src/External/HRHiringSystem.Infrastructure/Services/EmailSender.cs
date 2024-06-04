using HRHiringSystem.Application.Abstractions;
using HRHiringSystem.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace HRHiringSystem.Infrastructure.Services;
internal class EmailSender : IEmailSender
{
    private readonly EmailSettings _emailSettings;

    public EmailSender(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
        _emailSettings.Password = Environment.GetEnvironmentVariable("EMAIL_PASSWORD");
    }

    public async Task SendEmailAsync(string email, string subject, string body)
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
            Body = body,
            IsBodyHtml = true
        };

        mailMessage.To.Add(email);

        await smtpClient.SendMailAsync(mailMessage);
    }
}
