////////////////////
// 
// This Code Listens to the CSGO GameState API and provides feedback
// 
// Author: Johannes Gocke, johannes_gocke@hotmail.de
// 
///////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CSGOGameObserverSDK.GameDataTypes
{
    public class Player
    {
        public long? Steamid { get; set; }
        public string Clan { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
        public string Activity { get; set; }
        public State State { get; set; }
        public Weapons Weapons { get; set; }

        public Player(JToken playerDataJToken)
        {
            Steamid = playerDataJToken.Value<long?>("steamid");
            Clan = playerDataJToken.Value<string>("clan");
            Name = playerDataJToken.Value<string>("name");
            Team = playerDataJToken.Value<string>("team");
            Activity = playerDataJToken.Value<string>("activity");

            if (playerDataJToken["state"] != null)
                State = new State(playerDataJToken["state"]);
            if (playerDataJToken["weapons"] != null)
                Weapons = new Weapons(playerDataJToken["weapons"]);
        }
    }
}
