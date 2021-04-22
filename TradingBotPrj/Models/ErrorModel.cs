using Newtonsoft.Json;

namespace TradingBotPrj.Models
{
    public partial class ErrorModel
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }
    }
}
