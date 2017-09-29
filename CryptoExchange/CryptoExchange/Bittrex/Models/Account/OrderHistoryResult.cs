using CryptoExchange.Models;
using System.Collections.Generic;

namespace CryptoExchange.Bittrex.Models.Account
{
    public class OrderHistoryResult
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<HistoricOrder> result { get; set; }
    }
}
