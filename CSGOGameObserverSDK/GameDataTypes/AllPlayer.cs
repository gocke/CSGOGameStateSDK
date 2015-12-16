using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CSGOGameObserverSDK.GameDataTypes
{
    public class AllPlayer
    {
        public long? Steamid { get; set; }
        public string Clan { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
        public string Activity { get; set; }
        public State State { get; set; }
        public MatchStats MatchStats { get; set; }

        public AllPlayer(JToken allPlayerDataJToken)
        {
            //SteamId is the name of the parent Node
            long tempSteamid;
            if (long.TryParse(((JProperty) allPlayerDataJToken.Parent).Name, out tempSteamid))
                Steamid = tempSteamid;     

            Clan = allPlayerDataJToken.Value<string>("clan");
            Name = allPlayerDataJToken.Value<string>("name");
            Team = allPlayerDataJToken.Value<string>("team");

            if (allPlayerDataJToken["state"] != null)
                State = new State(allPlayerDataJToken["state"]);
            if (allPlayerDataJToken["match_stats"] != null)
                MatchStats = new MatchStats(allPlayerDataJToken["match_stats"]);
        }
    }
}
