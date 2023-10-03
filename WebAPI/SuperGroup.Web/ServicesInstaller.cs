using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SuperGroup.Data.IContractRepositories;
using SuperGroup.Data.Repositories;
using SuperGroup.Domain.IContractManagers;
using SuperGroup.Domain.Managers;

namespace SuperGroup.Web
{
    public class ServicesInstaller
    {
        private readonly IServiceCollection _serviceCollection;

        public ServicesInstaller(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }


        public void installServices()
        {
            InstallAutoMapper();
            InstallManagers();
            InstallRepositories();
        }

        private void InstallManagers()
        {
            _serviceCollection.AddScoped<IProductManager, ProductManager>();
        }

        private void InstallRepositories()
        {
            _serviceCollection.AddScoped<IProductRepository, ProductRepository>();

        }

        private void InstallHandlers()
        {
        }

        private void InstallAutoMapper()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            _serviceCollection.AddSingleton(mapper);
        }

    }
}