### About ###

* This is a Library (sorry, SDK was aimed a bit too high i guess? :D), for developing .Net compatible Apps/Tools for CSGO
* Version 1.0

## Install/Run Instructions ##

* Place dll in your project and add it as Reference

## Use Instructions ##

Just create a CSGOGameObserver Object (with the CSGOClient Server adress), 
subcribe to its messageReceived event and start.


```
#!c#
            CSGOGameObserverServer csgoGameObserverServer = new CSGOGameObserverServer("http://127.0.0.1:3000/");
            csgoGameObserverServer.receivedCSGOServerMessage += OnReceivedCsgoServerMessage;
            csgoGameObserverServer.Start();

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