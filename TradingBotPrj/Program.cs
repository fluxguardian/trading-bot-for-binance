using TradingBotPrj.Application;
using Autofac;
using TradingBotPrj.IoC;
using System.Threading;
using System.Globalization;

namespace TradingBotPrj
{
    class Program
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            AutofacContainer.CompositionRoot().Resolve<App>().Run();
        }
    }
}