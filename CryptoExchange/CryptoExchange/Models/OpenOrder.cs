using System;

namespace CryptoExchange.Models
{
    public class OpenOrder
    {
        public object Uuid { get; set; }
        public string OrderUuid { get; set; }
        public string Exchange { get; set; }
        public string OrderType { get; set; }
        public double Quantity { get; set; }
        public double QuantityRemaining { get; set; }
        public double Limit { get; set; }
        public double CommissionPaid { get; set; }
        public double Price { get; set; }
        public object PricePerUnit { get; set; }
        public DateTime Opened { get; set; }
        public object Closed { get; set; }
        public bool CancelInitiated { get; set; }
        public bool ImmediateOrCancel { get; set; }
        public bool IsConditional { get; set; }
        public object Condition { get; set; }
        public object ConditionTarget { get; set; }
    }
}
