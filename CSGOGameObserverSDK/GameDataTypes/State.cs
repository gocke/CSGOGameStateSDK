using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CSGOGameObserverSDK.GameDataTypes
{
    public class State
    {
        public int? Health { get; set; }
        public int? Armor { get; set; }
        public bool? Helmet { get; set; }
        public int? Flashed { get; set; }
        public int? Smoked { get; set; }
        public int? Burning { get; set; }
        public int? Money { get; set; }
        public int? RoundKills { get; set; }
        public int? RoundKillHs { get; set; }

        public State(JToken stateDataJToken)
        {
            Health = stateDataJToken.Value<int?>("health");
            Armor = stateDataJToken.Value<int?>("armor");
            Helmet = stateDataJToken.Value<bool?>("helmet");
            Flashed = stateDataJToken.Value<int?>("flashed");
            Smoked = stateDataJToken.Value<int?>("smoked");
            Burning = stateDataJToken.Value<int?>("burning");
            Money = stateDataJToken.Value<int?>("money");
            RoundKills = stateDataJToken.Value<int?>("round_kills");
            RoundKillHs = stateDataJToken.Value<int?>("round_killhs");
        }
    }
}
