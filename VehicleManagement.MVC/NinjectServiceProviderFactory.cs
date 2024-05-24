using Ninject.Modules;

namespace VehicleManagement.MVC
{
    public class NinjectServiceProviderFactory : IServiceProviderFactory<NinjectServiceProvider>
    {
        private readonly INinjectModule[] _modules;

        public NinjectServiceProviderFactory(params INinjectModule[] modules)
        {
            _modules = modules;
        }

        public NinjectServiceProvider CreateBuilder(IServiceCollection services)
        {
            return new NinjectServiceProvider(_modules);
        }

        public IServiceProvider CreateServiceProvider(NinjectServiceProvider containerBuilder)
        {
            return containerBuilder;
        }
    }
}
