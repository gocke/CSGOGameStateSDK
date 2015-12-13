////////////////////
// 
// This Code Listens to the CSGO GameState API and provides feedback
// 
// Author: Johannes Gocke, johannes_gocke@hotmail.de
// 
///////////////////

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
    public class TeamCT
    {
        public int? Score { get; set; }

        public TeamCT(JToken teamCTDataJToken)
        {
            Score = teamCTDataJToken.Value<int?>("score");
        }
    }
}
