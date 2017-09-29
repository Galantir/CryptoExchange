using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoExchange
{
    public class Auth
    {
        public long Nonce { get; set; }
        public string Uri { get; set; }
        public string Sign { get; set; }

        public static Auth Authenticate(string apiKey, string apiSecret, string uri, Dictionary<string, string> parameters)
        {
            Auth result = new Auth();
            result.Nonce = DateTime.Now.Ticks;
            result.Uri = string.Format("{0}?apikey={1}&nonce={2}", uri, apiKey, result.Nonce);
            if (parameters != null)
            {
                foreach (KeyValuePair<string, string> pair in parameters)
                {
                    result.Uri = string.Format("{0}&{1}={2}", result.Uri, pair.Key, pair.Value);
                }
            }
            result.Sign = genHMAC(apiSecret, result.Uri);
            return result;
        }

        private static string genHMAC(string secret, string url)
        {
            var hmac = new HMACSHA512(Encoding.ASCII.GetBytes(secret));
            var messagebyte = Encoding.ASCII.GetBytes(url);
            var hashmessage = hmac.ComputeHash(messagebyte);
            var sign = BitConverter.ToString(hashmessage).Replace("-", "");

            return sign;
        }
    }
}
