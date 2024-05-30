
using Microsoft.EntityFrameworkCore;
using PetoStore.Domain.Repositories;
using PetStore.Application.Pets;
using PetStore.Infrastructure.Database;
using PetStore.Infrastructure.Database.Repositories;

namespace PetStore.WebApi
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
            builder.Services.AddDbContext<PetStoreContext>(opt =>
            {
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                opt.UseSqlServer(connectionString);
            });
            builder.Services.AddScoped<IPetRepository, PetRepository>();
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetPetByIdHandler).Assembly));

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
