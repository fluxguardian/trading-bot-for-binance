using TradingBotPrj.Models;

namespace TradingBotPrj.Application.Interfaces
{
    public interface IOperations
    {
        void Buy();
        void Sell(OpenOrdersResponseModel buyorderResponse);
    }
}
