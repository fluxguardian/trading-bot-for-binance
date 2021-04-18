using System;
using System.ComponentModel;

namespace TradingBotPrj.Utils
{
    public static class Extentions
    {
        public static T Convert<T>(this string input)
        {
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter != null)
                {
                    return (T)converter.ConvertFromString(input);
                }
                return default(T);
            }
            catch
            {
                return default(T);
            }
        }
    }
}
