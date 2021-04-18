using Newtonsoft.Json;

namespace TradingBotPrj.Models
{
    public partial class OrderRequestModel
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("side")]
        public string Side { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}
