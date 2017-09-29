namespace CryptoExchange.Models
{
    public class CryptoBalance
    {
        public string Currency { get; set; }
        public double Balance { get; set; }
        public double Available { get; set; }
        public double Pending { get; set; }
        public string CryptoAddress { get; set; }
        public bool Requested { get; set; }
        public object Uuid { get; set; }
        public double BTCValue { get; set; }
        public double USDValue { get; set; }
        public double ETHValue { get; set; }
    }
}
