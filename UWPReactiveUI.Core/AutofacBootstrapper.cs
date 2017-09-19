using Autofac;
using UWPReactiveUI.Services.Interfaces;
using UWPReactiveUI.Services.Impl;

namespace UWPReactiveUI.Core
{
    public static class AutofacBootstrapper
    {
        public static IContainer Start()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<HipsterViewModel>().AsSelf();
            builder.RegisterType<HipsterService>().As<IHipsterService>().SingleInstance();

            return builder.Build();
        }
    }
}
