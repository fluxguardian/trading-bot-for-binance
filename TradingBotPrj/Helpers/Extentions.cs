using System.ComponentModel;

namespace TradingBotPrj.Helpers
{
    public static class Extentions
    {
        public static T Convert<T>(this string input)
        {
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                return (T)converter.ConvertFromString(input);
            }
            catch
            {
                return default;
            }
        }
    }
}
