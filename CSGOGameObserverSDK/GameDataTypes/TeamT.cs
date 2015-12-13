using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CSGOGameObserverSDK.GameDataTypes
{
    public class TeamT
    {
        public int? Score { get; set; }

        public TeamT(JToken teamTDataJToken)
        {
            Score = teamTDataJToken.Value<int?>("score");
        }
    }
}
