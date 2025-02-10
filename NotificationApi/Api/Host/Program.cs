using DatabaseModel;
using DomainService.Config;
using Host.Consumers;
using DomainService.Operations;
using Host.Helpers.Swagger;
using Host.Middlewares;
using Microsoft.EntityFrameworkCore;
using MassTransit;
using DomainService.Interface;

namespace EventManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Config

            var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var configuration = configurationBuilder.Build();

            builder.WebHost.UseConfiguration(configuration);

            builder.Services.Configure<SmtpConfig>(configuration.GetSection("Smtp"));

            #endregion

            #region Kestrel

            // appsettings.json dosyasýndan Kestrel ayarlarýný oku
            var kestrelConfig = builder.Configuration.GetSection("Api:Kestrel:Http");

            // Kestrel konfigürasyonunu ayarla
            builder.WebHost.ConfigureKestrel(options =>
            {
                var url = kestrelConfig["Url"];
                var port = int.Parse(kestrelConfig["Port"]);

                options.ListenAnyIP(port); // Belirtilen port ve URL'de Kestrel'i dinle
            });

            #endregion

            builder.Services.AddControllers();

            #region Swagger

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.OperationFilter<TokenParameterFilter>();
                c.CustomSchemaIds((type) => type.FullName.Replace("+", "_"));
                c.CustomOperationIds(e => $"{e.ActionDescriptor.RouteValues["controller"]}{e.HttpMethod}{e.RelativePath}");
            });

            #endregion

            #region EntityFramework

            string connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            builder.Services.AddDbContext<MainDbContext>(options =>
            {
                options.UseSqlServer(connectionString, x =>
                {
                    x.MigrationsHistoryTable("_EFMigrationsHistory", "Notification");
                });
            });

            #endregion

            #region Registirations

            builder.Services.AddTransient<IEMailOperations, EMailOperations>();

            #endregion

            #region RabbitMQ

            builder.Services.AddMassTransit(x =>
            {
                x.AddConsumer<EmailConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("rabbitmq://localhost", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    cfg.ReceiveEndpoint("email_queue", e =>
                    {
                        e.ConfigureConsumer<EmailConsumer>(context);
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });

            builder.Services.AddMassTransitHostedService();

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseSwagger();
            app.UseSwaggerUI();


            #region Middlewares

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseMiddleware<TransactionMiddleware>();

            #endregion

            //app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
