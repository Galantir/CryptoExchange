using CryptoExchange.Models;

namespace CryptoExchange.Bittrex.Models.Account
{
    public class OrderResult
    {
        public bool success { get; set; }
        public string message { get; set; }
        public Order result { get; set; }
    }
}
