using CorporateClassifieds.Repository;
using CorporateClassifieds.Repository.Dapper;
using CorporateClassifieds.Repository.Interfaces;
using CorporateClassifieds.Services;
using CorporateClassifieds.Services.Interfaces;
using SimpleInjector;
using WebApi.Controllers;

namespace WebApi
{
    public static class SimpleInjectorBootstrap
    {
        public static void InitializeContainer(Container container) 
        {
            container.Register<IDatabase, Database>(Lifestyle.Scoped);
            container.Register<IClassifiedRepository, ClassifiedRepository>(Lifestyle.Scoped);
            container.Register<ClassifiedService>(Lifestyle.Scoped);
            container.Register<IFileRepository, FileRepository>(Lifestyle.Scoped);
            container.Register<IFileService, FileService>(Lifestyle.Scoped);
            
        }
    }
}
