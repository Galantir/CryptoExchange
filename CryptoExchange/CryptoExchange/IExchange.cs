using CryptoExchange.Models;
using System;
using System.Collections.Generic;

namespace CryptoExchange
{
    public interface IExchange
    {
        List<MarketSummary> GetMarketSummaries();
        MarketSummary GetMarketSummary(CryptoMarket market);
        List<MarketSummary> GetMarketSummaries(Func<MarketSummary, bool> predicate);


        List<CryptoBalance> GetBalances(Func<CryptoBalance, bool> predicate);
        List<CryptoBalance> GetBalances();
    }
}
