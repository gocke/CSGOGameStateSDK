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
    public class Weapon
    {
        public string Name { get; set; }
        public string PaintKit { get; set; }
        public string Type { get; set; }
        public int? AmmoClip { get; set; }
        public int? AmmoClipMax { get; set; }
        public int? AmmoReserve { get; set; }
        public string State { get; set; }


        public Weapon(JToken weaponDataJToken)
        {
            Name = weaponDataJToken.Value<string>("name");
            PaintKit = weaponDataJToken.Value<string>("paintkit");
            Type = weaponDataJToken.Value<string>("type");
            AmmoClip = weaponDataJToken.Value<int?>("ammo_clip");
            AmmoClipMax = weaponDataJToken.Value<int?>("ammo_clip_max");
            AmmoReserve = weaponDataJToken.Value<int?>("ammo_reserve");
            State = weaponDataJToken.Value<string>("state");
        }
    }
}
