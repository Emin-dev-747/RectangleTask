
using Rubiconmp_RectangleTask.Application;
using Rubiconmp_RectangleTask.Application.Extensions;

namespace Rubiconmp_RectangleTask.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddApplication(builder.Configuration);


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                app.ApplyMigrations();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
