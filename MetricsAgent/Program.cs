using AutoMapper;
using MetricsAgent.Converters;
using MetricsAgent.Models;
using MetricsAgent.Services;
using MetricsAgent.Services.Impl;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using NLog.Web;
using System.Data.SQLite;

namespace MetricsAgent
{
    public class Program
    {
        public static void Main(string[] args)   //MetricsManagerLesson4newBranch
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure Automapper

            var mapperConfiguration = new MapperConfiguration(mp => mp.AddProfile(new
                MapperProfile()));
            var mapper = mapperConfiguration.CreateMapper();
            builder.Services.AddSingleton(mapper);

            #endregion

            #region Configure Options

            builder.Services.Configure<DatabaseOptions>(options =>
            {
                builder.Configuration.GetSection("Settings:DatabaseOptions").Bind(options);
            });

            #endregion

            #region Configure Repository

            builder.Services.AddScoped<ICpuMetricsRepository,
                CpuMetricsRepository>();

            #endregion

            #region Configure Database

            //ConfigureSqlLiteConnection(builder); //������� �������

            #endregion

            #region Configure logging

            builder.Host.ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();

            }).UseNLog(new NLogAspNetCoreOptions()
            { RemoveLoggerFactoryFilter = true });

            builder.Services.AddHttpLogging(logging =>
            {
                logging.LoggingFields = HttpLoggingFields.All
                | HttpLoggingFields.RequestQuery;
                logging.RequestBodyLogLimit = 4096;
                logging.ResponseBodyLogLimit = 4096;
                logging.RequestHeaders.Add("Authorization");
                logging.RequestHeaders.Add("X-Real-IP");
                logging.RequestHeaders.Add("X-Forwarded-For");
            });

            #endregion

            builder.Services.AddControllers()
              .AddJsonOptions(options =>
                  options.JsonSerializerOptions.Converters.
                  Add(new CustomTimeSpanConverter()));
            // Learn more about configuring Swagger/OpenAPI at
            // https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MetricsAgent", Version = "v1" });

                // ��������� TimeSpan
                c.MapType<TimeSpan>(() => new OpenApiSchema
                {
                    Type = "string",
                    Example = new OpenApiString("00:00:00")
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseHttpLogging();
            app.MapControllers();
            app.Run();
        }

        private static void ConfigureSqlLiteConnection(WebApplicationBuilder? builder)
        {
            var connection = new SQLiteConnection(builder.Configuration
                ["Settings:DatabaseOptions:ConnectionString"].ToString());
            connection.Open();
            PrepareSchema(connection);
        }

        private static void PrepareSchema(SQLiteConnection connection)
        {
            using (var command = new SQLiteCommand(connection))
            {
                // ����� ����� ����� ������� ��� ����������
                // ������� ������� � ���������, ���� ��� ���� � ���� ������
                command.CommandText = "DROP TABLE IF EXISTS cpumetrics";
                // ���������� ������ � ���� ������
                command.ExecuteNonQuery();
                command.CommandText =
                    @"CREATE TABLE cpumetrics(id INTEGER
                    PRIMARY KEY,
                    value INT, time INT)";
                command.ExecuteNonQuery();


                // ������� ������� � ���������, ���� ��� ���� � ���� ������
                command.CommandText = "DROP TABLE IF EXISTS hddmetrics";
                // ���������� ������ � ���� ������
                command.ExecuteNonQuery();
                command.CommandText =
                    @"CREATE TABLE hddmetrics(id INTEGER
                    PRIMARY KEY,
                    value INT, time INT)";
                command.ExecuteNonQuery();

                // ������� ������� � ���������, ���� ��� ���� � ���� ������
                command.CommandText = "DROP TABLE IF EXISTS networkmetrics";
                // ���������� ������ � ���� ������
                command.ExecuteNonQuery();
                command.CommandText =
                    @"CREATE TABLE networkmetrics(id INTEGER
                    PRIMARY KEY,
                    value INT, time INT)";
                command.ExecuteNonQuery();

                // ������� ������� � ���������, ���� ��� ���� � ���� ������
                command.CommandText = "DROP TABLE IF EXISTS rammetrics";
                // ���������� ������ � ���� ������
                command.ExecuteNonQuery();
                command.CommandText =
                    @"CREATE TABLE rammetrics(id INTEGER
                    PRIMARY KEY,
                    value INT, time INT)";
                command.ExecuteNonQuery();
            }
        }
    }
}