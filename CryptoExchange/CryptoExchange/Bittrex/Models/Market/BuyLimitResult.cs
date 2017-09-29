using CryptoExchange.Models;

namespace CryptoExchange.Bittrex.Models.Market
{
    public class BuyLimitResult
    {
        public bool success { get; set; }
        public string message { get; set; }
        public OrderId result { get; set; }
    }
}
