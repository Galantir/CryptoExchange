using CryptoExchange.Models;

namespace CryptoExchange.Bittrex.Models.Account
{
    public class BalanceResult
    {
        public bool success { get; set; }
        public string message { get; set; }
        public CryptoBalance result { get; set; }
    }    
}
