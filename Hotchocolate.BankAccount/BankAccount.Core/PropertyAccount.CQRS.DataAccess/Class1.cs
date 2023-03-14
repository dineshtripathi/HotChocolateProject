using System.Diagnostics;
using System.Reflection;
using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;
using Property.DatabaseEntity.AutofacModule;
using PropertyAccount.CQRS.DataAccess.CQRSQuery.Handler;

namespace PropertyAccount.CQRS.DataAccess;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public class CqrsMediatorDataAccessModule : Autofac.Module
{

    protected override void Load(ContainerBuilder containerBuilder)
    {

        containerBuilder.RegisterGeneric(typeof(QueryRequestHandler<>)).AsImplementedInterfaces();
        var configuration = MediatRConfigurationBuilder.Create(typeof(QueryRequestHandler<>).GetTypeInfo().Assembly)
            .WithAllOpenGenericHandlerTypesRegistered()
            .Build();
        containerBuilder.RegisterMediatR(configuration);
        containerBuilder.RegisterModule<RepositoryServiceDataAccessModule>();
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}