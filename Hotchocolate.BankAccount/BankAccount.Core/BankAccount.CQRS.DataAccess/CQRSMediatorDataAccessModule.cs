using Autofac;
using BankAccount.DatabaseEntity.RepositoryServiceCollection;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;
using System.Diagnostics;
using System.Reflection;
using BankAccount.CQRS.DataAccess.CQRSQuery.Handler;

namespace BankAccount.CQRS.DataAccess;

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
        containerBuilder.RegisterModule<RepositoryServicerDataAccessModule>();
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
