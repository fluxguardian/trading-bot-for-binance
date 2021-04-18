using TradingBotPrj.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TradingBotPrj.ApiRequests.Interface
{
    public interface IBinance
    {
        Task<OpenOrdersResponseModel> NewOrder(OrderRequestModel orderParamater);
        Task<IEnumerable<OpenOrdersResponseModel>> OpenOrders(Expression<Func<OpenOrdersResponseModel, bool>> query = null);
    }
}
