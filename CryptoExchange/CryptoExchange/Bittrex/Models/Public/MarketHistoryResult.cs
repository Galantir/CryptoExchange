using CryptoExchange.Models;
using System.Collections.Generic;

namespace CryptoExchange.Bittrex.Models.Public
{
    public class MarketHistoryResult
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<MarketHistory> result { get; set; }
    }
}
