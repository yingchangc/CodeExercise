using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.SystemDesign
{
    /// <summary>
    /// lint 232 TinyURL
    /// http://www.lintcode.com/en/problem/tiny-url/
    /// Given a long url, make it shorter. To make it simpler, let's ignore the domain name.
    /// You should implement two methods:
    /// 
    /// longToShort(url). Convert a long url to a short url.
    /// shortToLong(url). Convert a short url to a long url starts with http://tiny.url/.
    /// You can design any shorten algorithm, the judge only cares about two things:
    /// 
    /// The short key's length should equal to 6 (without domain and slash). And the acceptable characters are [a-zA-Z0-9]. For example: abcD9E
    /// No two long urls mapping to the same short url and no two short urls mapping to the same long url.
    /// 
    /// 
    ///  [Example]
    ///  
    /// Given url = http://www.lintcode.com/faq/?id=10, run the following code (or something similar):
    /// 
    /// short_url = longToShort(url) // may return http://tiny.url/abcD9E
    /// long_url = shortToLong(short_url) // return http://www.lintcode.com/faq/?id=10
    /// The short_url you return should be unique short url and start with http://tiny.url/ and 6 acceptable characters. For example "http://tiny.url/abcD9E" or something else.
    /// 
    /// The long_url should be http://www.lintcode.com/faq/?id=10 in this case
    /// 
    /// 
    /// createCustom("http://www.lintcode.com/", "lccode")
    /// >> http://tiny.url/lccode
    /// createCustom("http://www.lintcode.com/", "lc")
    /// >> error
    /// longToShort("http://www.lintcode.com/problem/")
    /// >> http://tiny.url/1Ab38c   // this is just an example, you can have you own 6 characters.
    /// shortToLong("http://tiny.url/lccode")
    /// >> http://www.lintcode.com/
    /// shortToLong("http://tiny.url/1Ab38c")
    /// >> http://www.lintcode.com/problem/
    /// shortToLong("http://tiny.url/1Ab38d")
    /// >> null
    /// 
    /// 
    /// </summary>
    class TinyUrl
    {
        private Dictionary<string, string> Short2Long;
        private Dictionary<string, string> Long2Short;
        private Dictionary<string, string> CustomShort2Long;
        private Dictionary<string, string> CustomLong2Short;
        private static string sLookup = "abcdefghijklmnopqrstuvwxzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"; // a-zA-Z0-9  62items
        private static int sShortCount = 6;

        public TinyUrl()
        {
            Short2Long = new Dictionary<string, string>();
            Long2Short = new Dictionary<string, string>();

            CustomShort2Long = new Dictionary<string, string>();
            CustomLong2Short = new Dictionary<string, string>();
        }

        public String createCustom(String long_url, String key)
        {
            // short key not vlaid from a-zA-Z0-9
            if (!IsCustomKeyValid(key))
            {
                return "error";
            }

            string customTiny = "http://tiny.url/" + key;

            // exist
            if (CustomShort2Long.ContainsKey(customTiny))
            {
                if (CustomShort2Long[customTiny] == long_url)
                {
                    return customTiny;
                }
                return "error";
            }

            CustomLong2Short.Add(long_url, customTiny);
            CustomShort2Long.Add(customTiny, long_url);

            return customTiny;
        }

        private bool IsCustomKeyValid(string key)
        {
            int N = key.Length;

            if (N != 6)
            {
                return false;
            }

            for (int i=0; i < N; i++)
            {
                if (!sLookup.Contains(key[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public String LongToShort(String url)
        {
            if (CustomLong2Short.ContainsKey(url))
            {
                return CustomLong2Short[url];
            }
            else if (Long2Short.ContainsKey(url))
            {
                return Long2Short[url];
            }

            while(true)
            {
                string tiny = "http://tiny.url/" + GenerateRandomShortURL(url);
                if (Short2Long.ContainsKey(tiny))
                {
                    // the random url has been used.
                    continue;
                }

                Long2Short.Add(url, tiny);
                Short2Long.Add(tiny, url);
                return tiny;
            }
        }

        private string GenerateRandomShortURL(String url)
        {
            int count = sShortCount - 1;
            int shardingKey = Math.Abs(url.GetHashCode()) % 62;
            string tiny = "" + sLookup[shardingKey];

            Random r = new Random();
            while (count > 0)
            {
                tiny += sLookup[r.Next(0,62)];  // 0-61
                count--;
            }

            return tiny;
        }

        /*
         * @param url: a short url starts with http://tiny.url/
         * @return: a long url
         */
        public String ShortToLong(String url)
        {
            if (CustomShort2Long.ContainsKey(url))
            {
                return CustomShort2Long[url];
            }
            else if (Short2Long.ContainsKey(url))
            {
                return Short2Long[url];
            }
            return string.Empty;
        }

    }
}
