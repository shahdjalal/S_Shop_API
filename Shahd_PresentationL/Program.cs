
using Microsoft.EntityFrameworkCore;
using Shahd_DataAccessL.Data;
using Scalar;
using Scalar.AspNetCore;
using Shahd_DataAccessL.Repositories.Classes;
using Shahd_DataAccessL.Repositories.Interfaces;
using Shahd_BusniessLL.Services.Classes;
using Shahd_BusniessLL.Services.Interfaces;
using Shahd_DataAccessL.Utils;
using Shahd_DataAccessL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Shahd_PresentationL.Utils;
using Microsoft.AspNetCore.Identity.UI.Services;
namespace Shahd_PresentationL
{
    public class Program
    {
        public static async Task Main(string[] args)
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
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IProductRepo, ProductRepo>();
            builder.Services.AddScoped<IFileService, FileService>();
            builder.Services.AddScoped<IBrandRepo, BrandRepo>();
            builder.Services.AddScoped<IBrandService, BrandService>();
            builder.Services.AddScoped<ISeedData, SeedData>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddScoped<IEmailSender, EmailSetting>();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 7;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })

        .AddJwtBearer(options =>
        {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("jwtOptions")["secretKey"]))
            };
        });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }
           var scope= app.Services.CreateScope();
          
            var objectOfSeedData =   scope.ServiceProvider.GetRequiredService<ISeedData>();
           await objectOfSeedData.DataSeedingAsync(); 
            await objectOfSeedData.IdentityDataSeedingAsync();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
