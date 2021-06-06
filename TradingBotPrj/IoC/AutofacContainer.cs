using TradingBotPrj.Application;
using Autofac;
using System.Net.Http;
using TradingBotPrj.Application.Interfaces;
using TradingBotPrj.ApiRequests.Interface;
using TradingBotPrj.ApiRequests;
using TradingBotPrj.Infos;

namespace TradingBotPrj.IoC
{
    public static class AutofacContainer
    {
        public static IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();
            builder.Register(c => new HttpClient()).As<HttpClient>();
            builder.RegisterType<DynamicInfo>().As<IDynamicInfo>().InstancePerLifetimeScope();
            builder.RegisterType<Binance>().As<IBinance>().InstancePerLifetimeScope();
            builder.RegisterType<Operations>().As<IOperations>().InstancePerLifetimeScope();
            builder.RegisterType<App>().InstancePerLifetimeScope();
            return builder.Build();
        }
    }
}
