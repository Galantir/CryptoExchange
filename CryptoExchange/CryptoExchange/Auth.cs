using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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
            long nonce = DateTime.Now.Ticks;
            Auth result = new Auth
            {
                Nonce = DateTime.Now.Ticks,
                Uri = $"{uri}?apikey={apiKey}&nonce={nonce}"
            };
           
            if (parameters != null)
            {
                foreach (KeyValuePair<string, string> pair in parameters)
                {
                    result.Uri = $"{result.Uri}&{pair.Key}={pair.Value}";
                }
            }
            result.Sign = GenHMAC(apiSecret, result.Uri);
            return result;
        }

        private static string GenHMAC(string secret, string url)
        {
            var hmac = new HMACSHA512(Encoding.ASCII.GetBytes(secret));
            var messagebyte = Encoding.ASCII.GetBytes(url);
            var hashmessage = hmac.ComputeHash(messagebyte);
            var sign = BitConverter.ToString(hashmessage).Replace("-", "");
            hmac.Dispose();
            return sign;
        }
    }
}
