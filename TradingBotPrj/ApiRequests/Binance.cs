using Newtonsoft.Json;
using TradingBotPrj.ApiRequests.Interface;
using TradingBotPrj.Infos;
using TradingBotPrj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Tasks;

namespace TradingBotPrj.ApiRequests
{
    public class Binance : BinanceBase, IBinance
    {
        private readonly HttpClient httpClient;

        public Binance(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.httpClient.BaseAddress = new Uri(Settings.BaseEndpoint);
        }

        public async Task<OpenOrdersResponseModel> NewOrder(OrderRequestModel orderParamater)
        {
            var Parameters = new List<string>
            {
                $"symbol={orderParamater.Symbol}",
                $"side={orderParamater.Side}",
                $"type={orderParamater.Type}",
                $"newClientOrderId=sb_{Guid.NewGuid():N}"
            };

            OrderType orderType = (OrderType)Enum.Parse(typeof(OrderType), orderParamater.Type);

            Parameters.Add($"timeInForce={TimeInForce.GTC.ToString()}");

            Parameters.Add($"quantity={orderParamater.Quantity.ToString()}");
            Parameters.Add($"price={orderParamater.Price.ToString()}");

            var responseMessage = await CallAsync(httpClient, HttpMethod.Post, BinanceApiEndpoints.NewOrder, Parameters, true);

            if (responseMessage.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<OpenOrdersResponseModel>(await responseMessage.Content.ReadAsStringAsync());

            return null;
        }

        public async Task<IEnumerable<OpenOrdersResponseModel>> OpenOrders(Expression<Func<OpenOrdersResponseModel, bool>> query = null)
        {
            var responseMessage = await CallAsync(httpClient, HttpMethod.Get, BinanceApiEndpoints.OpenOrders, null, true);

            if (responseMessage.IsSuccessStatusCode)
            {
                var openOrders = JsonConvert.DeserializeObject<List<OpenOrdersResponseModel>>(await responseMessage.Content.ReadAsStringAsync());

                if (query != null)
                    return openOrders.AsQueryable().Where(query).ToList();
                
                return openOrders;
            }

            return null;
        }
    }
}
