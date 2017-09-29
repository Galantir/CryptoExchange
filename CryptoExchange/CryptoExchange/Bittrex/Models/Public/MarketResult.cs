using CryptoExchange.Models;
using System.Collections.Generic;

namespace CryptoExchange.Bittrex.Models.Public
{
    public class MarketResult
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<Market> result { get; set; }
    }
}
