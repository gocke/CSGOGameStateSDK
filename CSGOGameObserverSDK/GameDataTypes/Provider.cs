using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CSGOGameObserverSDK.GameDataTypes
{
    public class Provider
    {
        public string Name { get; set; }
        public int? Appid { get; set; }
        public long? Version { get; set; }
        public long? Steamid { get; set; }
        public long? Timestamp { get; set; }

        public Provider(JToken providerData)
        {
            Name = providerData.Value<string>("name");
            Appid = providerData.Value<int?>("appid");
            Version = providerData.Value<long?>("version");
            Steamid = providerData.Value<long?>("steamid");
            Timestamp = providerData.Value<long?>("timestamp");
        }
    }
}
