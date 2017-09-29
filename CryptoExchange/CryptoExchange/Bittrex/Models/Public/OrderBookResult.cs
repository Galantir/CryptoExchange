namespace CryptoExchange.Bittrex.Models.Public
{
    public class OrderBookResult
    {
        public bool success { get; set; }
        public string message { get; set; }
        public Result result { get; set; }
    }
}
