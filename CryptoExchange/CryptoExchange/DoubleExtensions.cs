using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoExchange
{
    public static class DoubleExtensions
    {
        public static decimal AsDecimal(this double value)
        {
            return Convert.ToDecimal(value);
        }
    }
}
