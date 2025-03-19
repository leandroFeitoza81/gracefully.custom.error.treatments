using CodeMasterDev.Core.Domain.Interfaces.Repositories;
using CodeMasterDev.Core.Domain.Interfaces.Services;
using CodeMasterDev.Core.Infra.DataBase;
using CodeMasterDev.Core.Infra.Repositories;
using CodeMasterDev.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeMasterDev.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // desabilita validação automática do ModelState
        builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

        builder.Services.AddControllers();
        
        var connectionString = builder.Configuration.GetConnectionString(
                                   "SqlConnection") ?? throw new ApplicationException("Connection string not found");

        builder.Services.AddSingleton(new DapperContext(connectionString));
        builder.Services.AddSingleton<IActorRepository, ActorRepository>();
        builder.Services.AddSingleton<IActorService, ActorService>();

       

        var app = builder.Build();
        

        app.MapControllers();
        app.Run();
    }
}