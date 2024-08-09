
using Core.Services;
using Core.UnitOfWork;
using Library_Management_System.Helper;
using Library_Management_System.MiddleWare;
using Microsoft.EntityFrameworkCore;
using Reposiatry.Context;
using Reposiatry.UnitOfWork;
using Services;

namespace Library_Management_System
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<LibraryDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddScoped<IBookServices, BookServices>();
            IdentityServises.IdentityExctions.AddIdentity(builder.Services, builder.Configuration);


            var app = builder.Build();
            #region Update Database
            var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var logger = services.GetRequiredService<ILoggerFactory>();
            try
            {
                var context =  services.GetRequiredService<LibraryDbContext>();
                await context.Database.MigrateAsync();

            }
            catch (Exception ex)
            {
                var loggeer = logger.CreateLogger<Program>();
                loggeer.LogError(ex, "An error occurred while migrating or seeding the database.");

            }

            #endregion

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //app.UseMiddleware<MiddleWareExceptions>();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
