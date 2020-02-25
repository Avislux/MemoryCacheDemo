using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace MemoryCacheDemo.Library
{
    public class GlobalCache
    {
        public static MemoryCache Cache = MemoryCache.Default;

        public static void Set (string key, object value) {
            Cache.Set(key, value, DateTime.Now.AddMinutes(5));
        }

        public static void IncreaseInt() {
            string key = "Int";
            if (Cache.Contains(key)) {
                int number = (int) Cache.Get(key);
                Cache.Set(key, ++number, DateTime.Now.AddMinutes(5));
            } else {
                Cache.Set(key, 0, DateTime.Now.AddMinutes(5));

            }
        }

        public static void AppendHistory() {
            if (Cache.Contains("History")) {
                var history = (List<object>) Cache.Get("History");
                history.Add(DateTime.Now);
                Cache.Set("History", history, DateTime.Now.AddMinutes(5));
            } else {
                Cache.Set("History", new List<object>() { DateTime.Now }, DateTime.Now.AddMinutes(5));

            }
        }

        public static string ToJson() {

            var dict = new Dictionary<string, object>();
            foreach (var item in Cache) {
                dict.Add(item.Key, item.Value);
            }

            return JsonConvert.SerializeObject(dict);
        }
    }
}