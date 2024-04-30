
using EmployeeApp.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using EmployeeApp.Presentation;
using System.Configuration;
using EmployeeApp.Services;
using EmployeeApp.Data;
using Microsoft.EntityFrameworkCore;
namespace EmployeeApp.Hello
{
    class HelloWorld
    {
        private readonly Mainmenu _mainmenu;
        public HelloWorld(Mainmenu mainmenu)
        {
            _mainmenu = mainmenu;
        }
        public static async Task Main()
        {

            var serviceProvider = new ServiceCollection()
                .AddSingleton<IValidation, Validation>()
                .AddDbContext<MyDBContext>(options=>options.UseSqlServer(GetConnectionString()))
                .AddSingleton<IRoleRepo, RoleRepo>()
                .AddSingleton<IEmployeeRepo, EmployeeRepo>()
                .AddAutoMapper(typeof(MapperService))
                .AddSingleton<IEmployeeServices, EmployeeServices>()
                .AddSingleton<IRoleServices, RoleServices>()
                .AddSingleton<IEmployeeManager, EmployeeManager>()
                .AddSingleton<IRoleManager, RoleManager>()
                .AddSingleton<IMainmenu, Mainmenu>()
                .BuildServiceProvider();
            var consolePresentation = serviceProvider.GetRequiredService<IMainmenu>();
            await consolePresentation.EntryAsync();

        }
        public static string GetConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString;
            return connectionString;
        }
    }
    
}

