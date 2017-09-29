using CryptoExchange.Models;
using System.Collections.Generic;

namespace CryptoExchange.Bittrex.Models.Market
{
    public class OpenOrdersResult
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<OpenOrder> result { get; set; }
    }
}
