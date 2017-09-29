using CryptoExchange.Models;
using System.Collections.Generic;

namespace CryptoExchange.Bittrex.Models.Public
{
    public class CurrencyResult
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<CryptoCurrency> result { get; set; }
    }
}
