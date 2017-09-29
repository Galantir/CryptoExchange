using CryptoExchange.Models;

namespace CryptoExchange.Bittrex.Models.Market
{
    public class SellLimitResult
    {
        public bool success { get; set; }
        public string message { get; set; }
        public OrderId result { get; set; }
    }
}
