using System.Reflection;
using thekumral.Caching;
using thekumral.Core.Repositories;
using thekumral.Core.Services;
using thekumral.Core.UnitOfWork;
using thekumral.Repository.Repositories;
using thekumral.Repository.UnitOfWork;
using thekumral.Repository;
using thekumral.Service.Mapping;
using thekumral.Service.Services;
using Module = Autofac.Module ;
using Autofac;

namespace thekumral.Api.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Genel IRepository ve IService arabirimlerine karşılık gelen GenericRepository ve Service sınıflarını kaydeder.
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            // UnitOfWork sınıfını IUnitOfWork arabirimiyle kaydeder.
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            // Assembly'leri alır.
            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            // Repository sınıflarını tanımlar ve arabirimlerine kaydeder.
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            // Service sınıflarını tanımlar ve arabirimlerine kaydeder.
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            // PostServiceWithCaching sınıfını IPostService arabirimiyle kaydeder.
            builder.RegisterType<PostServiceWithCaching>().As<IPostService>();

            //base.Load(builder);
        }
    }
}
