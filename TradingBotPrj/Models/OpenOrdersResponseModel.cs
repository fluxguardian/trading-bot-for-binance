using Newtonsoft.Json;

namespace TradingBotPrj.Models
{
    public class OpenOrdersResponseModel
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("orderId")]
        public long OrderId { get; set; }

        [JsonProperty("orderListId")]
        public long OrderListId { get; set; }

        [JsonProperty("clientOrderId")]
        public string ClientOrderId { get; set; }

        [JsonProperty("transactTime")]
        public long TransactTime { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("origQty")]
        public string OrigQty { get; set; }

        [JsonProperty("executedQty")]
        public string ExecutedQty { get; set; }

        [JsonProperty("cummulativeQuoteQty")]
        public string CummulativeQuoteQty { get; set; }

        [JsonProperty("status")]
        public OrderStatus Status { get; set; }

        [JsonProperty("timeInForce")]
        public TimeInForce TimeInForce { get; set; }

        [JsonProperty("type")]
        public OrderType Type { get; set; }

        [JsonProperty("side")]
        public Side Side { get; set; }

        [JsonProperty("fills")]
        public object[] Fills { get; set; }
    }
    public enum Side
    {
        BUY,
        SELL
    }

    public enum TimeInForce
    {
        GTC,
        IOC,
        FOK
    }

    public enum OrderType
    {
        LIMIT,
        MARKET,
        STOP_LOSS,
        STOP_LOSS_LIMIT,
        TAKE_PROFIT,
        TAKE_PROFIT_LIMIT,
        LIMIT_MAKER
    }

    public enum OrderStatus
    {
        NEW,
        PARTIALLY_FILLED,
        FILLED,
        CANCELED,
        REJECTED,
        EXPIRED
    }
}
