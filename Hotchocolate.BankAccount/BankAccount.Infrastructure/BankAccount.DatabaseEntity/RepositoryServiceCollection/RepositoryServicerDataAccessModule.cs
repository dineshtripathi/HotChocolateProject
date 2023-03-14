﻿using Autofac;
using BankAccount.DatabaseEntity.DBContext.BaseRepositoryProvider;

namespace BankAccount.DatabaseEntity.RepositoryServiceCollection;


public class RepositoryServiceDataAccessModule : Module
{
    protected override void Load(ContainerBuilder containerBuilder)
    {
       containerBuilder.RegisterGeneric(typeof(BaseRepositoryProvider<>)).As(typeof(IBaseRepositoryProvider<>)).InstancePerDependency();
    }
}
