using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class TinyURL
    {
        Dictionary<string, string> hash = new Dictionary<string, string>();
        string charSet = "abcdefghijklmnokprstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        string baseUrl = "http://tinyUrl.com/";
        int STRINGlEN = 6;

        public string Encode(string url)
        {
            if (hash.ContainsValue(url))
            {
                foreach (var pair in hash)
                {
                    if (pair.Value.Equals(url))
                    {
                        return pair.Key;
                    }
                }
            }

            StringBuilder builder;
            Random random = new Random();
            var newUrl = string.Empty;
            while (newUrl == string.Empty || hash.ContainsKey(newUrl))
            {
                builder = new StringBuilder();
                for (int i = 0; i < STRINGlEN; i++)
                {
                    var val = random.Next(charSet.Length);
                    builder.Append(charSet[val]);
                }
                newUrl = baseUrl + builder.ToString();
            }
            hash.Add(newUrl, url);
            return newUrl;
        }

        public string Decode(string tinyURL)
        {
            if (hash.ContainsKey(tinyURL))
            {
                return hash[tinyURL];
            }

            return null;
        }
    }
}
