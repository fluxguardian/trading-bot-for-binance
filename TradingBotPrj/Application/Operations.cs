using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TradingBotPrj.ApiRequests.Interface;
using TradingBotPrj.Application.Interfaces;
using TradingBotPrj.Infos;
using TradingBotPrj.Models;

namespace TradingBotPrj.Application
{
    public class Operations : IOperations
    {
        private readonly IBinance binance;
        private readonly IDynamicInfo dynamicInfo;

        public Operations(IBinance binance, IDynamicInfo dynamicInfo)
        {
            this.binance = binance;
            this.dynamicInfo = dynamicInfo;
        }

        public void Buy()
        {
            while (true)
            {
                Thread.Sleep(2000);

                IEnumerable<OpenOrdersResponseModel> openOrdersResponse = binance.OpenOrders(s => s.ClientOrderId.StartsWith("sb_") && s.Symbol == dynamicInfo.Symbol);

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

                    var buyorderResponse = binance.NewOrder(buyorderRequest);

                    if (buyorderResponse is ErrorModel err)
                    {
                        Console.WriteLine($"AN ERROR OCCURRED! Message: ({err.Code}) {err.Msg} => Order Type: BUY => Date: {DateTime.Now}");
                    }
                    else
                    {
                        Console.WriteLine($"Order Type: BUY => Date: {DateTime.Now}");
                        Sell(buyorderResponse);
                    }

                    break;
                }
            }
        }

        public void Sell(OpenOrdersResponseModel buyorderResponse)
        {
            while (true)
            {
                Thread.Sleep(2000);

                IEnumerable<OpenOrdersResponseModel> openOrdersResponse = binance.OpenOrders(s => s.ClientOrderId == buyorderResponse.ClientOrderId);

                if (!openOrdersResponse?.Any() ?? true)
                {
                    var sellorderRequest = new OrderRequestModel
                    {
                        Price = dynamicInfo.SellPrice,
                        Quantity = dynamicInfo.Quantity,
                        Side = Side.SELL.ToString(),
                        Symbol = dynamicInfo.Symbol,
                        Type = OrderType.LIMIT.ToString()
                    };

                    var sellorderResponse = binance.NewOrder(sellorderRequest);

                    if (sellorderResponse is ErrorModel err)
                    {
                        Console.WriteLine($"AN ERROR OCCURRED! Message: ({err.Code}) {err.Msg} => Order Type: BUY => Date: {DateTime.Now}");
                    }
                    else
                    {
                        Console.WriteLine($"Order Type: SELL => Date: {DateTime.Now}");
                        Buy();
                    }

                    break;
                }
            }
        }
    }
}
