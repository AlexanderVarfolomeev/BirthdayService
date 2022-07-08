using BirthdayApi.RabbitMqService;

namespace BirthdayApi.EmailService;

using BirthdayApi.RabbitMQService;

public interface IEmailSender
{
    Task SendEmailAsync(EmailModel model);
    Task SendEmailAsync(string email, string subject, string message);
}
