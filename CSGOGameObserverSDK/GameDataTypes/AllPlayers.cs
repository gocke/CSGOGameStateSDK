using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CSGOGameObserverSDK.GameDataTypes
{
    public class AllPlayers
    {
        public List<AllPlayer> AllPlayerList { get; set; } = new List<AllPlayer>();

        public AllPlayers(JToken allPlayersDataJToken)
        {
            //To get all Players we iterate over the values
            foreach (var allPlayerDataJToken in allPlayersDataJToken.Values())
            {
                AllPlayerList.Add(new AllPlayer(allPlayerDataJToken));
            }
        }
    }
}
