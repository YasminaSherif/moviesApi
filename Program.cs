using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using movies.Models;
using movies.Repository;

namespace movies
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
            builder.Services.AddCors();
            builder.Services.AddDbContext<ApplicationContext>(OptionsBuilder=> 
            {
                OptionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });
            //registering service 
            builder.Services.AddScoped<IGenre, GenreRepo>();
            builder.Services.AddScoped<IMovie,MovieRepo>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
