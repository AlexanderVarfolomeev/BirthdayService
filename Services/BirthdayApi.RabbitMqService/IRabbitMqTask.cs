using BirthdayApi.RabbitMqService;

namespace BirthdayApi.RabbitMQService;

using System.Threading.Tasks;

public interface IRabbitMqTask
{
    Task SendEmail(EmailModel email);
}
