using CryptoExchange.Models;
using System;
using System.Collections.Generic;

namespace CryptoExchange
{
    public interface IExchange
    {
        List<MarketSummary> GetMarketSummaries();
        List<MarketSummary> GetMarketSummaries(Func<MarketSummary, bool> predicate);
        MarketSummary GetMarketSummary(CryptoMarket market);
        MarketSummary GetMarketSummary(string market);           
        double GetBTCUSDValue();
        List<MarketHistory> GetMarketHistory(CryptoMarket market);
        List<MarketHistory> GetMarketHistory(string market);
        Ticker GetTicker(CryptoMarket market);
        Ticker GetTicker(string market);
        List<Buy> GetBuys(CryptoMarket market);
        List<Buy> GetBuys(string market);
        List<Sell> GetSells(CryptoMarket market);
        List<Sell> GetSells(string market);

        List<OpenOrder> GetOpenOrders(CryptoMarket market);
        List<OpenOrder> GetOpenOrders(string market);
        OrderId BuyLimit(CryptoMarket market, double quantity, double rate);
        OrderId BuyLimit(string market, double quantity, double rate);
        OrderId SellLimit(CryptoMarket market, double quantity, double rate);
        OrderId SellLimit(string market, double quantity, double rate);
        bool CancelOrder(OpenOrder order);
        bool CancelOrder(string uuid);

        List<CryptoBalance> GetBalances(Func<CryptoBalance, bool> predicate);
        List<CryptoBalance> GetBalances();
        CryptoBalance GetBalance(CryptoCurrency currency);
        CryptoBalance GetBalance(string currency);
        Order GetOrder(string uuid);
        List<HistoricOrder> GetOrderHistory(CryptoMarket market);
        List<HistoricOrder> GetOrderHistory(string market);
    }
}
