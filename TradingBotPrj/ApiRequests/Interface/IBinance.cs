using TradingBotPrj.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TradingBotPrj.ApiRequests.Interface
{
    public interface IBinance
    {
        dynamic NewOrder(OrderRequestModel orderParamater);
        dynamic OpenOrders(Expression<Func<OpenOrdersResponseModel, bool>> query = null);
        Task<dynamic> NewOrderAsync(OrderRequestModel orderParamater);
        Task<dynamic> OpenOrdersAsync(Expression<Func<OpenOrdersResponseModel, bool>> query = null);
    }
}
