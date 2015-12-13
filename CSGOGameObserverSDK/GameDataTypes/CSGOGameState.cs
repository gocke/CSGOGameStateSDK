using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CSGOGameObserverSDK.GameDataTypes
{
    // The CSGOGameDataTypes are for easier access to the GameState variables if wanted.
    // Capitalizing and Spelling bozh class and Object the same is horribly, but this code is straightforward, so i guess it's ok
    public class CSGOGameState
    {
        public Provider Provider { get; set; }
        public Map Map { get; set; }
        public Round Round { get; set; }
        public Player Player { get; set; }
        public MatchStats MatchStats { get; set; }

        public CSGOGameState(JObject gameDataJObject)
        {
            if(gameDataJObject["provider"] != null)
                Provider = new Provider(gameDataJObject["provider"]);

            if (gameDataJObject["map"] != null)
                Map = new Map(gameDataJObject["map"]);

            if (gameDataJObject["round"] != null)
                Round = new Round(gameDataJObject["round"]);

            if (gameDataJObject["player"] != null)
                Player = new Player(gameDataJObject["player"]);

            if (gameDataJObject["match_stats"] != null)
                MatchStats = new MatchStats(gameDataJObject["match_stats"]);
        }

    }
}
