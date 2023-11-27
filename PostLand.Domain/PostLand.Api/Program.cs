
using Microsoft.EntityFrameworkCore;
using PostLand.Application.Contracts;
using PostLand.Persistence.DB;
using PostLand.Persistence.Repositories;

namespace PostLand.Api
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
            builder.Services.AddDbContext<PostDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PostConnectionString")));
            builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped(typeof(IPostRepository), typeof(PostRepository));
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
