namespace BirthdayApi.Settings;

public interface IWorkerSettings
{
    IDbSettings Db { get; }
    IRabbitMqSettings RabbitMq { get; }
    IEmailSettings Email { get; }
}

