using CryptoExchange.Models;
using System.Collections.Generic;

namespace CryptoExchange.Bittrex.Models.Public
{
    public class Result
    {
        public List<Buy> buy { get; set; }
        public List<Sell> sell { get; set; }
    }
}
