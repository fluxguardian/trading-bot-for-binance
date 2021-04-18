using TradingBotPrj.Infos;
using TradingBotPrj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TradingBotPrj.Application.Interfaces;
using TradingBotPrj.ApiRequests.Interface;

namespace TradingBotPrj.Application
{
    public class Operations : IOperations
    {
        private readonly IBinance binance;
        private readonly DynamicInfo dynamicInfo;

        public Operations(IBinance binance, DynamicInfo dynamicInfo)
        {
            this.binance = binance;
            this.dynamicInfo = dynamicInfo;
        }

        public void Buy()
        {
            while (true)
            {
                IEnumerable<OpenOrdersResponseModel> openOrdersResponse = binance.OpenOrders(s => s.ClientOrderId.StartsWith("sb_") && s.Symbol == dynamicInfo.Symbol).Result;

                if (!openOrdersResponse?.Any() ?? true)
                {
                    var buyorderRequest = new OrderRequestModel
                    {
                        Price = dynamicInfo.BuyPrice,
                        Quantity = dynamicInfo.Quantity,
                        Side = Side.BUY.ToString(),
                        Symbol = dynamicInfo.Symbol,
                        Type = OrderType.LIMIT.ToString()
                    };

                    var buyorderResponse = binance.NewOrder(buyorderRequest).Result;

                    if (buyorderResponse?.OrderId > 0)
                    {
                        Console.WriteLine($"Order Type: BUY => Pair: {dynamicInfo.Symbol} => Price: {dynamicInfo.BuyPrice} => Quantity: {dynamicInfo.Quantity} => Date: {DateTime.Now}");
                        Sell(buyorderResponse);
                        break;
                    }
                }

                Thread.Sleep(2000);
            }
        }

        public void Sell(OpenOrdersResponseModel buyorderResponse)
        {
            while (true)
            {
                IEnumerable<OpenOrdersResponseModel> openOrdersResponse = binance.OpenOrders(s => s.ClientOrderId == buyorderResponse.ClientOrderId).Result;

                if (openOrdersResponse?.Any() ?? false)
                {
                    var sellorderRequest = new OrderRequestModel
                    {
                        Price = dynamicInfo.SellPrice,
                        Quantity = dynamicInfo.Quantity,
                        Side = Side.SELL.ToString(),
                        Symbol = dynamicInfo.Symbol,
                        Type = OrderType.LIMIT.ToString()
                    };

                    var sellorderResponse = binance.NewOrder(sellorderRequest).Result;

                    if (sellorderResponse?.OrderId > 0)
                    {
                        Console.WriteLine($"Order Type: SELL => Pair: {dynamicInfo.Symbol} => Price: {dynamicInfo.SellPrice} => Quantity: {dynamicInfo.Quantity} => Date: {DateTime.Now}");
                        Thread.Sleep(2000);
                        Buy();
                        break;
                    }
                }

                Thread.Sleep(2000);
            }
        }
    }
}
