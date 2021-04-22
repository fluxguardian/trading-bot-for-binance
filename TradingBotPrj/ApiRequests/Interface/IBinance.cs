using TradingBotPrj.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TradingBotPrj.ApiRequests.Interface
{
    public interface IBinance
    {
        Task<dynamic> NewOrder(OrderRequestModel orderParamater);
        Task<dynamic> OpenOrders(Expression<Func<OpenOrdersResponseModel, bool>> query = null);
    }
}
