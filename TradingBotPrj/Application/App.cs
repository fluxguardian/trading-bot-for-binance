using System;
using TradingBotPrj.Application.Interfaces;
using TradingBotPrj.Infos;
using TradingBotPrj.Utils;

namespace TradingBotPrj.Application
{
    public class App
    {
        private readonly IOperations operations;
        private readonly DynamicInfo dynamicInfo;

        public App(IOperations operations, DynamicInfo dynamicInfo)
        {
            this.operations = operations;
            this.dynamicInfo = dynamicInfo;
        }

        public void Run()
        {
            Console.WriteLine("Please type a trading pair. Example: XVGBTC");
            string pair = Console.ReadLine();
            dynamicInfo.Symbol = pair.ToUpper();

            while (true)
            {
                Console.WriteLine("Please type buy price. Example: 0.001");
                string buyPrice = Console.ReadLine();
                var buyPriceDecimal = buyPrice.Convert<decimal>();
                if (buyPriceDecimal <= 0) continue;
                dynamicInfo.BuyPrice = buyPriceDecimal;
                break;
            }

            while (true)
            {
                Console.WriteLine("Please type sell price. Example: 0.002");
                string sellPrice = Console.ReadLine();
                var sellPriceDecimal = sellPrice.Convert<decimal>();
                if (sellPriceDecimal <= 0) continue;
                dynamicInfo.SellPrice = sellPriceDecimal;
                break;
            }

            while (true)
            {
                Console.WriteLine("Please type quantity. Example: 314");
                string quantity = Console.ReadLine();
                var quantityDecimal = quantity.Convert<decimal>();
                if (quantityDecimal <= 0) continue;
                dynamicInfo.Quantity = quantityDecimal;
                break;
            }

            Console.WriteLine("Do you confirm that the operations will be started? (y/n)");

            var confirm = Console.ReadKey();

            if (confirm.KeyChar is 'n' or 'N')
            {
                Console.WriteLine();
                Run();
            }
            else if (confirm.KeyChar is 'y' or 'Y')
            {
                Console.WriteLine();
                operations.Buy();
            }
        }
    }
}
