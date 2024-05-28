using Microsoft.EntityFrameworkCore;
using Ninject.Modules;
using VehicleManagement.Service;
using VehicleManagement.Service.Data;
using VehicleManagement.Service.Interfaces;
using VehicleManagement.Service.Services;

namespace VehicleManagement.MVC
{
    public class NinjectModuleBindings : NinjectModule
    {
        private readonly IConfiguration _configuration;

        public NinjectModuleBindings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override void Load()
        {
            Bind<IVehicleService>().To<VehicleService>();

            var optionsBuilder = new DbContextOptionsBuilder<VehicleContext>();
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));

            Bind<VehicleContext>().ToSelf().WithConstructorArgument("options", optionsBuilder.Options);
        }
    }
}
