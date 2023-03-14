using Autofac;
using Module = Autofac.Module;

namespace Property.DatabaseEntity.AutofacModule;


public class RepositoryServiceDataAccessModule : Module
{
    protected override void Load(ContainerBuilder containerBuilder)
    {
       containerBuilder.RegisterGeneric(typeof(BaseRepositoryProvider<>)).As(typeof(IBaseRepositoryProvider<>)).InstancePerDependency();
    }
}
