using Account.Api.ServiceCollectionExtension;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Features.Variance;
using BankAccount.CQRS.DataAccess;
using BankAccount.DatabaseEntity.DBContextServiceCollection;
using MediatR;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlConnectionServices(builder.Configuration);
builder.Services.AddHotChocolateServices();

// Call UseServiceProviderFactory on the Host sub property 
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();
    containerBuilder.RegisterSource(new ContravariantRegistrationSource());
    containerBuilder.RegisterModule<CqrsMediatorDataAccessModule>();
});

var app = builder.Build();
app.MapGraphQL("");
app.Run();
