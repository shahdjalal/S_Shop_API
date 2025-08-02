
using Microsoft.EntityFrameworkCore;
using Shahd_DataAccessL.Data;
using Scalar;
using Scalar.AspNetCore;
using Shahd_DataAccessL.Repositories.Classes;
using Shahd_DataAccessL.Repositories.Interfaces;
using Shahd_BusniessLL.Services.Classes;
using Shahd_BusniessLL.Services.Interfaces;
namespace Shahd_PresentationL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddScoped<ICategoryRepo,CategoryRepo>();
            builder.Services.AddScoped<ICategoryService,CategoryService>();
            builder.Services.AddScoped<IBrandRepo, BrandRepo>();
            builder.Services.AddScoped<IBrandService, BrandService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
