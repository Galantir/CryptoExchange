using CryptoExchange.Models;
using System.Collections.Generic;

namespace CryptoExchange.Bittrex.Models.Public
{
    public class MarketSummaryResult
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<MarketSummary> result { get; set; }
    }
}
