namespace TradingBotPrj.Infos
{
    public interface IDynamicInfo
    {
        public string Symbol { get; set; }
        public decimal SellPrice { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal Quantity { get; set; }
    }
    public class DynamicInfo : IDynamicInfo
    {
        public string Symbol { get; set; }
        public decimal SellPrice { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal Quantity { get; set; }
    }
}
