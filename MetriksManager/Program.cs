using MetricsAgent.Converters;
using MetriksManager.Models;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace MetriksManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // �������� ������ � ���������.
            builder.Services.AddSingleton<AgentPool>();

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                  options.JsonSerializerOptions.Converters
                  .Add(new CustomTimeSpanConverter()));
            
            // ������� ������ � ��������� Swagger/OpenAPI at
            // https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MetricsManager", Version = "v1" });

                    // ��������� TimeSpan
                    c.MapType<TimeSpan>(() => new OpenApiSchema
                    {
                        Type = "string",
                        Example = new OpenApiString("00:00:00")
                    });
                });

            var app = builder.Build();

            // ��������� �������� HTTP-��������.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}