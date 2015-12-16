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
    public class Weapons
    {
        public List<Weapon> WeaponList { get; set; } = new List<Weapon>();  

        public Weapons(JToken weaponsDataJToken)
        {
            //To get all weapons we iterate over the values
            foreach (var weaponDataJToken in weaponsDataJToken.Values())
            {
                WeaponList.Add(new Weapon(weaponDataJToken));
            }       
        }
    }
}
