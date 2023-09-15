
using HotelReviewsAPI.Data;
using HotelReviewsAPI.Mappings;
using HotelReviewsAPI.Repositories;
using Microsoft.EntityFrameworkCore;

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

            builder.Services.AddScoped<IHotelsRepository, SQLHotelRepository>();
            builder.Services.AddScoped<IReviewsRepository, SQLReviewRepository>();

            builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

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
    }
}