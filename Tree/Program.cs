using Microsoft.EntityFrameworkCore;
using Tree.Data;
using Tree.Interfaces;
using Tree.Repositories;

namespace Tree;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddScoped<ITreeRepository, TreeRepository>();
        builder.Services.AddScoped<INodeRepository, NodeRepository>();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddEntityFrameworkNpgsql()
           .AddDbContext<TreeDbContext>(opt =>
               opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        var app = builder.Build();

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
