using CryptoExchange.Models;
using System.Collections.Generic;

namespace CryptoExchange.Bittrex.Models.Account
{
    public class BalancesResult
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<CryptoBalance> result { get; set; }
    }
}
