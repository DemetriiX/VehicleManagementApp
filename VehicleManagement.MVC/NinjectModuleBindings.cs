using Ninject.Modules;
using VehicleManagement.Service;
using VehicleManagement.Service.Interfaces;
using VehicleManagement.Service.Services;

namespace VehicleManagement.MVC
{
    public class NinjectModuleBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IVehicleService>().To<VehicleService>().InSingletonScope();
        }
    }
}
