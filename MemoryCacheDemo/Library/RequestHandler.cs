using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Runtime.Caching;
using MemoryCacheDemo.Library;

namespace MemoryCacheDemo
{
    public class RequestHandler
    {
        public static string Handle( HttpRequest request ) {
            
            try {
                //MemoryCache cache = MemoryCache.Default;
                GlobalCache.IncreaseInt();
                GlobalCache.AppendHistory();
                GlobalCache.Set("RequestType", request.RequestType);
                // var dict = cache.ToDictionary<string, object>(z => z); //Someone tell me how to use this properly.
                string cacheJson = GlobalCache.ToJson();
                string action = "write";
                if (request.QueryString.AllKeys.Contains("action")) {
                    action = request.QueryString["action"];
                }
                if (action == "break") {
                    Logger.WriteButBreakCache(cacheJson);
                } else {
                    Logger.Write(cacheJson);
                }
                
                //Logger.WriteV2(cacheJson);
                return cacheJson;
               
               
            } catch (Exception e) {
                Dictionary<string, string> returnDict = new Dictionary<string, string> {
                    { "error", "Woops" },
                    { "Exception", e.ToString() }
                };
                return JsonConvert.SerializeObject(returnDict);
                
            }
           
        }
    }
}