using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CSGOGameObserverSDK.GameDataTypes
{
    public class Round
    {
        public string Phase { get; set; }
        public string Bomb { get; set; }

        public Round(JToken roundDataJToken)
        {
            Phase = roundDataJToken.Value<string>("phase");
            Bomb = roundDataJToken.Value<string>("bomb");
        }
    }
}
