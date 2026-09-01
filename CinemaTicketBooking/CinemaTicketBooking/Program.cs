using Asp.Versioning;
using CinemaTicketBooking.Data;
using CinemaTicketBooking.Exceptions;
using CinemaTicketBooking.Mapping;
using CinemaTicketBooking.Repository;
using CinemaTicketBooking.Repository.Interface;
using CinemaTicketBooking.Services;
using CinemaTicketBooking.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CinemaTicketBooking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            // Swagger Setup for Multiple API Versions
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Cinema API - v1 (Compact)", Version = "v1" });
                options.SwaggerDoc("v2", new OpenApiInfo { Title = "Cinema API - v2 (Detailed)", Version = "v2" });
            });

            // Repositories
            builder.Services.AddScoped<IMovieRepository, MovieRepository>();
            builder.Services.AddScoped<IAuditoriumRepository, AuditoriumRepository>();
            builder.Services.AddScoped<IShowTimeRepository, ShowTimeRepository>();
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

            // Services
            builder.Services.AddScoped<IMovieService, MovieService>();
            builder.Services.AddScoped<IAuditoriumService, AuditoriumService>();
            builder.Services.AddScoped<IBookingService, BookingService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IShowTimeService, ShowTimeService>();

            // DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });

            // AutoMapper Registration
            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            // API Versioning
            builder.Services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(2, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            var app = builder.Build();

            // Pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Cinema API v1 ");
                    options.SwaggerEndpoint("/swagger/v2/swagger.json", "Cinema API v2 ");
                });
            }

            app.UseMiddleware<GlobalException>();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}