using System;

namespace CryptoExchange.Models
{
    public class HistoricOrder
    {
        public string OrderUuid { get; set; }
        public string Exchange { get; set; }
        public DateTime TimeStamp { get; set; }
        public string OrderType { get; set; }
        public double Limit { get; set; }
        public double Quantity { get; set; }
        public double QuantityRemaining { get; set; }
        public double Commission { get; set; }
        public double Price { get; set; }
        public double? PricePerUnit { get; set; }
        public bool IsConditional { get; set; }
        public object Condition { get; set; }
        public object ConditionTarget { get; set; }
        public bool ImmediateOrCancel { get; set; }
    }
}
