### About ###

* This is a Library (sorry, SDK was aimed a bit too high i guess? :D), for developing .Net compatible Apps/Tools for CSGO
* Version 1.0

## Install/Run Instructions ##

* Place dll in your project and add it as Reference

## Use Instructions ##

* Create a CSGOGameObserver Object (with the CSGOClient Server adress), 
* Subscribe to its messageReceived event
* Start CSGOGameObserver
* You can transform the GamData into a CSGOGameState Model, for easier value access (beware, certain values might be null)

```
#!c#
        public void RunServer()
        {
            CSGOGameObserverServer csgoGameObserverServer = new CSGOGameObserverServer("http://127.0.0.1:3000/");
            csgoGameObserverServer.receivedCSGOServerMessage += OnReceivedCsgoServerMessage;
            csgoGameObserverServer.Start();
        }

        private void OnReceivedCsgoServerMessage(object sender, JObject gameData)
        {
            CSGOGameState csgoGameState = new CSGOGameState(gameData);

            if (csgoGameState.Round.Bomb != null && csgoGameState.Provider.Timestamp != null)
            {
                long currentTime = (long) csgoGameState.Provider.Timestamp;
```

JObject gameData contains a JSON Object that is structured similar to this:


```
#!JSON

{{
  "provider": {
    "name": "Counter-Strike: Global Offensive",
    "appid": 730,
    "version": 13514,
    "steamid": "123456789",
    "timestamp": 1449910114
  },
  "map": {
    "mode": "casual",
    "name": "de_overpass",
    "phase": "live",
    "round": 1,
    "team_ct": {
      "score": 0
    },
    "team_t": {
      "score": 1
    }
  },
  "round": {
    "phase": "live",
    "bomb": "planted"
  },
  "player": {
    "steamid": "123456789",
    "clan": "RWBY",
    "name": "master117 - Yang",
    "team": "T",
    "activity": "playing",
    "state": {
      "health": 28,
      "armor": 62,
      "helmet": true,
      "flashed": 0,
      "smoked": 0,
      "burning": 0,
      "money": 3700,
      "round_kills": 0,
      "round_killhs": 0
    },
    "weapons": {
      "weapon_0": {
        "name": "weapon_knife_tactical",
        "paintkit": "default",
        "type": "Knife",
        "state": "holstered"
      },
      "weapon_1": {
        "name": "weapon_glock",
        "paintkit": "gs_glock18_wrathys",
        "type": "Pistol",
        "ammo_clip": 20,
        "ammo_clip_max": 20,
        "ammo_reserve": 102,
        "state": "active"
      }
    },
    "match_stats": {
      "kills": 0,
      "assists": 1,
      "deaths": 0,
      "mvps": 0,
      "score": 1
    }
  },
  "auth": {
    "token": "abc123"
  }
}}

```

## How can I Contribution? ##

* Write any test you like, Visual Studio tests are preferred
* Audit/Review the Code
* Send Mergerequests with additional features.
* Write a Documentation / Comments

## About me/Contact ##

* Johannes Gocke
* email: johannes_gocke@hotmail.de
* steam: http://steamcommunity.com/id/master117/