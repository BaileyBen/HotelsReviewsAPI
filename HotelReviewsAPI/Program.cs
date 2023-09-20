
using HotelReviewsAPI.Data;
using HotelReviewsAPI.Mappings;
using HotelReviewsAPI.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HotelReviewsAPI
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

            builder.Services.AddDbContext<HotelReviewsDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("HotelsReviewsConnectionString")));

            builder.Services.AddDbContext<HotelReviewsAuthDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("HotelReviewsAuthConnectionString")));

            builder.Services.AddScoped<IHotelsRepository, SQLHotelRepository>();
            builder.Services.AddScoped<IReviewsRepository, SQLReviewRepository>();

            builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));


            builder.Services.AddIdentityCore<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("HotelReviews")
                .AddEntityFrameworkStores<HotelReviewsDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}