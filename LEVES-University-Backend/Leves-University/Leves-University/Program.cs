
using Leves_University.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
//using Serilog;

namespace Leves_University
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
            //    .WriteTo.File("log/Logs.txt", rollingInterval: RollingInterval.Hour).CreateLogger();

            //builder.Host.UseSerilog();

            // Add services to the container.
            builder.Services.AddDbContext<LevesEntities>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LevesUniversity")));


            //builder.Services.
            //    AddIdentityCore<LevesEntities>()
            //    .AddDefaultTokenProviders();


            //builder.Services.Configure<IdentityOptions>(options =>
            //{
            //    options.Password.RequiredLength = 8;
            //    options.Password.RequireDigit = false;
            //    options.Password.RequireLowercase = false;
            //    options.Password.RequireUppercase = false;
            //    options.Password.RequireNonAlphanumeric = false;
            //});




            builder.Services.AddControllers().AddNewtonsoftJson();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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