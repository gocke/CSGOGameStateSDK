using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CSGOGameObserverSDK.GameDataTypes
{
    public class MatchStats
    {
        public int? Kills { get; set; }
        public int? Assists { get; set; }
        public int? Deaths { get; set; }
        public int? MVPs { get; set; }
        public int? Score { get; set; }


        public MatchStats(JToken matchStatsDataJToken)
        {
            Kills = matchStatsDataJToken.Value<int?>("kills");
            Assists = matchStatsDataJToken.Value<int?>("assists");
            Deaths = matchStatsDataJToken.Value<int?>("deaths");
            MVPs = matchStatsDataJToken.Value<int?>("mvps");
            Score = matchStatsDataJToken.Value<int?>("score");
        }
    }
}
