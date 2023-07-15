using Microsoft.EntityFrameworkCore;
using ToDoList.DataAccess;
using ToDoList.Services;

namespace ToDoList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            string connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<ITasksService, TasksService>();
            builder.Services.AddScoped<ITaskStorage, TasksStorage>();

            var app = builder.Build();

            app.MapGet("/", (ApplicationContext db) => db.Tasks.ToList());

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.Use(async (context, next) =>
            {
                try
                {
                    Console.WriteLine("Something logic BEFORE action");
                    await next();
                    Console.WriteLine("Something logic AFTER action");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }           
            });

            app.MapControllers();

            app.Run();
        }
    }
}