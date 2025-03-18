using CodeMasterDev.Core.DataBase;
using CodeMasterDev.Core.Interfaces.Repositories;
using CodeMasterDev.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CodeMasterDev.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();

        var connectionString = builder.Configuration.GetConnectionString("SqlConnection") ??
                               throw new ApplicationException("Connection string not found");
        builder.Services.AddSingleton(new DapperContext(connectionString));
        builder.Services.AddSingleton<IActorRepository, ActorRepository>();

        // desabilita validação automática do ModelState
        builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

        var app = builder.Build();
        

        app.MapControllers();
        app.Run();
    }
}