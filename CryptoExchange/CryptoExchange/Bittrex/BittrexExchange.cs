using CryptoExchange.Bittrex.Models.Account;
using CryptoExchange.Bittrex.Models.Market;
using CryptoExchange.Bittrex.Models.Public;
using CryptoExchange.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoExchange.Bittrex
{
    public class BittrexExchange : IExchange
    {
        private const string BASE_URL = "https://bittrex.com/api/v1.1/";

        private string _apiKey { get; set; }
        private string _apiSecret { get; set; }
        private IRestClient _client { get; set; }

        public BittrexExchange(string apiKey, string apiSecret)
        {
            _apiKey = apiKey;
            _apiSecret = apiSecret;
        }

        #region public

        public List<Market> GetMarkets()
        {
            IRestRequest request = new RestRequest("public/getmarkets", Method.GET);
            IRestResponse response = _client.Execute(request);
            return JsonConvert.DeserializeObject<MarketResult>(response.Content).result;
        }

        public List<Market> GetMarkets(Func<Market, bool> predicate)
        {
            IRestRequest request = new RestRequest("public/getmarkets", Method.GET);
            IRestResponse response = _client.Execute(request);
            return JsonConvert.DeserializeObject<MarketResult>(response.Content).result.Where(predicate).ToList();
        }

        public List<CryptoCurrency> GetCurrencies()
        {
            IRestRequest request = new RestRequest("public/getcurrencies", Method.GET);
            IRestResponse response = _client.Execute(request);
            return JsonConvert.DeserializeObject<CurrencyResult>(response.Content).result;
        }

        public List<CryptoCurrency> GetCurrencies(Func<CryptoCurrency, bool> predicate)
        {
            IRestRequest request = new RestRequest("public/getcurrencies", Method.GET);
            IRestResponse response = _client.Execute(request);
            return JsonConvert.DeserializeObject<CurrencyResult>(response.Content).result.Where(predicate).ToList();
        }

        public List<MarketSummary> GetMarketSummaries()
        {
            IRestRequest request = new RestRequest("public/getmarketsummaries", Method.GET);
            IRestResponse response = _client.Execute(request);
            return JsonConvert.DeserializeObject<MarketSummaryResult>(response.Content).result;
        }

        public MarketSummary GetMarketSummary(Market market)
        {
            return GetMarketSummary(market.MarketName);
        }

        public MarketSummary GetMarketSummary(string market)
        {
            IRestRequest request = new RestRequest("public/getmarketsummary", Method.GET);
            request.AddQueryParameter("market", market);
            IRestResponse response = _client.Execute(request);
            return JsonConvert.DeserializeObject<MarketSummaryResult>(response.Content).result[0];
        }

        public List<Buy> GetBuys(Market market)
        {
            return GetBuys(market.MarketName);
        }

        public List<Buy> GetBuys(string market)
        {
            IRestRequest request = new RestRequest("public/getorderbook", Method.GET);
            request.AddQueryParameter("market", market);
            request.AddQueryParameter("type", "both");
            IRestResponse response = _client.Execute(request);
            return JsonConvert.DeserializeObject<OrderBookResult>(response.Content).result.buy;
        }

        public List<Sell> GetSells(Market market)
        {
            return GetSells(market.MarketName);
        }

        public List<Sell> GetSells(string market)
        {
            IRestRequest request = new RestRequest("public/getorderbook", Method.GET);
            request.AddQueryParameter("market", market);
            request.AddQueryParameter("type", "both");
            IRestResponse response = _client.Execute(request);
            return JsonConvert.DeserializeObject<OrderBookResult>(response.Content).result.sell;
        }

        public List<MarketHistory> GetMarketHistory(Market market)
        {
            return GetMarketHistory(market.MarketName);
        }

        public List<MarketHistory> GetMarketHistory(string market)
        {
            IRestRequest request = new RestRequest("public/getmarkethistory", Method.GET);
            request.AddQueryParameter("market", market);
            IRestResponse response = _client.Execute(request);
            return JsonConvert.DeserializeObject<MarketHistoryResult>(response.Content).result;
        }

        public Ticker GetTicker(Market market)
        {
            return GetTicker(market.MarketName);
        }

        public Ticker GetTicker(string market)
        {
            IRestRequest request = new RestRequest("public/getticker", Method.GET);
            request.AddQueryParameter("market", market);
            IRestResponse response = _client.Execute(request);
            return JsonConvert.DeserializeObject<TickerResult>(response.Content).result;
        }

        #endregion

        #region market

        public OrderId BuyLimit(Market market, double quantity, double rate)
        {
            return BuyLimit(market.MarketName, quantity, rate);
        }

        public OrderId BuyLimit(string market, double quantity, double rate)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("market", market);
            parameters.Add("quantity", quantity.ToString());
            parameters.Add("rate", rate.ToString());

            Auth auth = Auth.Authenticate(_apiKey, _apiSecret, string.Format("https://bittrex.com/api/v1.1/market/buylimit"), parameters);

            IRestRequest request = new RestRequest("market/buylimit", Method.GET);
            request.AddQueryParameter("apikey", _apiKey);
            request.AddQueryParameter("nonce", auth.Nonce.ToString());
            request.AddQueryParameter("market", market);
            request.AddQueryParameter("quantity", quantity.ToString());
            request.AddQueryParameter("rate", rate.ToString());
            request.AddHeader("apisign", auth.Sign);

            IRestResponse response = _client.Execute(request);
            return JsonConvert.DeserializeObject<BuyLimitResult>(response.Content).result;
        }

        public SellLimitResult SellLimit(Market market, double quantity, double rate)
        {
            return SellLimit(market.MarketName, quantity, rate);
        }

        public SellLimitResult SellLimit(string market, double quantity, double rate)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("market", market);
            parameters.Add("quantity", quantity.ToString());
            parameters.Add("rate", rate.ToString());

            Auth auth = Auth.Authenticate(_apiKey, _apiSecret, string.Format("https://bittrex.com/api/v1.1/market/selllimit"), parameters);

            IRestRequest request = new RestRequest("market/selllimit", Method.GET);
            request.AddQueryParameter("apikey", _apiKey);
            request.AddQueryParameter("nonce", auth.Nonce.ToString());
            request.AddQueryParameter("market", market);
            request.AddQueryParameter("quantity", quantity.ToString());
            request.AddQueryParameter("rate", rate.ToString());
            request.AddHeader("apisign", auth.Sign);

            IRestResponse response = _client.Execute(request);
            return JsonConvert.DeserializeObject<SellLimitResult>(response.Content);
        }

        public bool CancelOrder(OpenOrder order)
        {
            return CancelOrder(order.OrderUuid);
        }

        public bool CancelOrder(string uuid)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("uuid", uuid);

            Auth auth = Auth.Authenticate(_apiKey, _apiSecret, string.Format("https://bittrex.com/api/v1.1/market/cancel"), parameters);

            IRestRequest request = new RestRequest("market/cancel", Method.GET);
            request.AddQueryParameter("apikey", _apiKey);
            request.AddQueryParameter("nonce", auth.Nonce.ToString());
            request.AddQueryParameter("uuid", uuid);
            request.AddHeader("apisign", auth.Sign);

            IRestResponse response = _client.Execute(request);
            return JsonConvert.DeserializeObject<CancelResult>(response.Content).success;
        }

        public List<OpenOrder> GetOpenOrders(Market market)
        {
            return GetOpenOrders(market.MarketName);
        }

        public List<OpenOrder> GetOpenOrders(string market)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("market", market);

            Auth auth = Auth.Authenticate(_apiKey, _apiSecret, string.Format("https://bittrex.com/api/v1.1/market/getopenorders"), parameters);

            IRestRequest request = new RestRequest("market/getopenorders", Method.GET);
            request.AddQueryParameter("apikey", _apiKey);
            request.AddQueryParameter("nonce", auth.Nonce.ToString());
            request.AddQueryParameter("market", market);
            request.AddHeader("apisign", auth.Sign);

            IRestResponse response = _client.Execute(request);
            return JsonConvert.DeserializeObject<OpenOrdersResult>(response.Content).result;
        }

        #endregion

        #region account

        public List<CryptoBalance> GetBalances()
        {
            Auth auth = Auth.Authenticate(_apiKey, _apiSecret, string.Format("https://bittrex.com/api/v1.1/market/getbalances"), null);

            IRestRequest request = new RestRequest("account/getbalances", Method.GET);
            request.AddQueryParameter("apikey", _apiKey);
            request.AddQueryParameter("nonce", auth.Nonce.ToString());
            request.AddHeader("apisign", auth.Sign);

            IRestResponse response = _client.Execute(request);
            return JsonConvert.DeserializeObject<BalancesResult>(response.Content).result;
        }

        public CryptoBalance GetBalance(CryptoCurrency currency)
        {
            return GetBalance(currency.Currency);
        }

        public CryptoBalance GetBalance(string currency)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("currency", currency);

            Auth auth = Auth.Authenticate(_apiKey, _apiSecret, string.Format("https://bittrex.com/api/v1.1/market/getbalance"), parameters);

            IRestRequest request = new RestRequest("account/getbalance", Method.GET);
            request.AddQueryParameter("apikey", _apiKey);
            request.AddQueryParameter("nonce", auth.Nonce.ToString());
            request.AddQueryParameter("currency", currency);
            request.AddHeader("apisign", auth.Sign);

            IRestResponse response = _client.Execute(request);
            return JsonConvert.DeserializeObject<BalanceResult>(response.Content).result;
        }

        public List<HistoricOrder> GetOrderHistory(string market)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("market", market);

            Auth auth = Auth.Authenticate(_apiKey, _apiSecret, string.Format("https://bittrex.com/api/v1.1/market/getorderhistory"), parameters);

            IRestRequest request = new RestRequest("account/getorderhistory", Method.GET);
            request.AddQueryParameter("apikey", _apiKey);
            request.AddQueryParameter("nonce", auth.Nonce.ToString());
            request.AddQueryParameter("market", market);
            request.AddHeader("apisign", auth.Sign);

            IRestResponse response = _client.Execute(request);
            return JsonConvert.DeserializeObject<OrderHistoryResult>(response.Content).result;
        }

        public Order GetOrder(string uuid)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("uuid", uuid);

            Auth auth = Auth.Authenticate(_apiKey, _apiSecret, string.Format("https://bittrex.com/api/v1.1/account/getorder"), parameters);

            IRestRequest request = new RestRequest("account/getorder", Method.GET);
            request.AddQueryParameter("apikey", _apiKey);
            request.AddQueryParameter("nonce", auth.Nonce.ToString());
            request.AddQueryParameter("uuid", uuid);
            request.AddHeader("apisign", auth.Sign);

            IRestResponse response = _client.Execute(request);
            return JsonConvert.DeserializeObject<OrderResult>(response.Content).result;
        }

        #endregion

    }
}
