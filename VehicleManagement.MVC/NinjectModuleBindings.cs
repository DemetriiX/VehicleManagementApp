using AutoMapper;
using Ninject.Modules;
using VehicleManagement.Service.Data;
using VehicleManagement.Service.Interfaces;
using VehicleManagement.Service.Mapping;
using VehicleManagement.Service.Services;

namespace VehicleManagement.MVC
{
    public class NinjectModuleBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IVehicleService>().To<VehicleService>();
            Bind<VehicleContext>().ToSelf().InTransientScope();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Bind<IMapper>().ToMethod(ctx => config.CreateMapper()).InSingletonScope();
        }
    }
}
