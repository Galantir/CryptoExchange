using CryptoExchange.Models;

namespace CryptoExchange.Bittrex.Models.Public
{
    public class TickerResult
    {
        public bool success { get; set; }
        public string message { get; set; }
        public Ticker result { get; set; }
    }
}
