using DatabaseModel;
using DomainService.Config;
using DomainService.Operations;
using Host.Helpers.Swagger;
using Host.Middlewares;
using Microsoft.EntityFrameworkCore;
using MassTransit;
using DomainService.Interface;
using Amazon.S3;

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
                    x.MigrationsHistoryTable("_EFMigrationsHistory", "ListingHub");
                });
            });

            #endregion

            #region Cors

            builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            #endregion

            #region Registirations

            builder.Services.AddTransient<ICategoryOperations, CategoryOperations>();
            builder.Services.AddTransient<ICityOperations, CityOperations>();
            builder.Services.AddTransient<IDistrictOperations, DistrictOperations>();
            builder.Services.AddTransient<INeighbourhoodOperations, NeighbourhoodOperations>();
            builder.Services.AddTransient<ISubNeighbourhoodOperations, SubNeighbourhoodOperations>();
            builder.Services.AddTransient<IFieldOperations, FieldOperations>();
            builder.Services.AddTransient<IListingOperations, ListingOperations>();
            builder.Services.AddTransient<IListingFieldOperations, ListingFieldOperations>();
            builder.Services.AddTransient<IListingDescriptionOperations, ListingDescriptionOperations>();
            builder.Services.AddTransient<IListingPhotoOperations, ListingPhotoOperations>();

            #endregion

            #region RabbitMQ

            builder.Services.AddMassTransit(x =>
            {
                //x.AddConsumer<EmailConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("rabbitmq://localhost", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    //cfg.ReceiveEndpoint("email_queue", e =>
                    //{
                    //    e.ConfigureConsumer<EmailConsumer>(context);
                    //});

                    cfg.ConfigureEndpoints(context);
                });
            });

            builder.Services.AddMassTransitHostedService();

            #endregion

            #region S3

            builder.Services.AddAWSService<IAmazonS3>();

            var awsAccessKey = configuration["AWS:AccessKey"];
            var awsSecretKey = configuration["AWS:SecretKey"];
            var region = Amazon.RegionEndpoint.GetBySystemName(configuration["AWS:Region"]);

            builder.Services.AddSingleton<IAmazonS3>(new AmazonS3Client(awsAccessKey, awsSecretKey, region));

            #endregion

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            #region Middlewares

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseMiddleware<TransactionMiddleware>();

            #endregion

            app.UseCors("MyPolicy");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
