using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace BillManage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            ConfigureService(builder);
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        public static void ConfigureService(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<BillManageService>();
            builder.Services.AddScoped<IRepository<BillInformation>, SqlRepository<BillInformation>>();
            builder.Services.AddTransient<IDbConnection>(db =>
            {
                var connection = new SqlConnection(builder.Configuration.GetConnectionString("default"));
                connection.Open();
                return connection;
            });
        }
    }
}