using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CSGOGameObserverSDK.GameDataTypes
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class Map
    {
        public string Mode { get; set; }
        public string Name { get; set; }
        public string Phase { get; set; }
        public int? Round { get; set; }
        public TeamCT TeamCT { get; set; }
        public TeamT TeamT { get; set; }

        public Map(JToken mapDataJToken)
        {
            Mode = mapDataJToken.Value<string>("mode");
            Name = mapDataJToken.Value<string>("name");
            Phase = mapDataJToken.Value<string>("phase");
            Round = mapDataJToken.Value<int?>("round");

            if (mapDataJToken["team_ct"] != null)
                TeamCT = new TeamCT(mapDataJToken["team_ct"]);
            if (mapDataJToken["team_t"] != null)
                TeamT = new TeamT(mapDataJToken["team_t"]);

        }
    }
}
