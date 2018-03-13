using Autofac;
using Passenger.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Passenger.Infrastructure.IoC.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(RepositoryModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IServices>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<Encrypter>()
                   .As<IEncrypter>()
                   .SingleInstance();
        }
    }
}
