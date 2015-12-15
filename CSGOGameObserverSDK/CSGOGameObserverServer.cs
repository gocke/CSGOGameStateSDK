////////////////////
// 
// This Code Listens to the CSGO GameState API and provides feedback
// 
// Author: Johannes Gocke, johannes_gocke@hotmail.de
// 
///////////////////

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CSGOGameObserverSDK
{
    //<summary>
    // This class provides easy access to the CSGOServer created by a CSGOClient with matching config. 
    // Place gamestate_integration_master117.cfg at steamapps\common\Counter-Strike Global Offensive\csgo\cfg\ (Restart CSGO)
    // Alternatively: Create your own config according to: https://developer.valvesoftware.com/wiki/Counter-Strike:_Global_Offensive_Game_State_Integration
    //</summary>



    public class CSGOGameObserverServer
    {
        private string GameServerAdressString;
        private HttpListener CSGOGameHttpListener;

        //Delegate to enable Subscription to the event of MessageReceived
        public delegate void receiveCSGOServerMessage(object sender, JObject gameData);
        public event receiveCSGOServerMessage receivedCSGOServerMessage;
        
        //Constructor, this version only accepts the direct adress, no auth, no parameter
        public CSGOGameObserverServer(string tempGameServerAdressString)
        {
            GameServerAdressString = tempGameServerAdressString;
        }

        //Starts the Server, starts Listening
        public void Start()
        {
            ConfigureServer();
            RunServer();
        }

        private void ConfigureServer()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            //Create Local Server, Listening to CSGO Client
            CSGOGameHttpListener = new HttpListener();
            CSGOGameHttpListener.Prefixes.Add(GameServerAdressString);
        }

        private async void RunServer()
        {
            CSGOGameHttpListener.Start();

            //Catches all requests by the CSGOClient, startes a new Task for each Message, async
            while (true)
            {
                var httpListenerContext = await CSGOGameHttpListener.GetContextAsync();

                //messages may arrive early/late
                #pragma warning disable 4014
                Task.Factory.StartNew(() => ProcessRequest(httpListenerContext));
                #pragma warning restore 4014
            }
        }

        private void ProcessRequest(HttpListenerContext tempHttpListenerContext)
        {
            //Receive request and transform in JSON
            HttpListenerRequest httpListenerRequest = tempHttpListenerContext.Request;

            try
            {
                JObject gameDataJObject = (JObject)DeserializeFromStream(httpListenerRequest.InputStream);

                //respond to the CSGOClient in a timely fashion.
                tempHttpListenerContext.Response.StatusCode = 200;
                tempHttpListenerContext.Response.StatusDescription = "OK";
                tempHttpListenerContext.Response.Close();

                //call the MessageReceived Event
                receivedCSGOServerMessage?.Invoke(this, gameDataJObject);
            }
            catch (Exception)
            {
                //respond to the CSGOClient with an error.
                tempHttpListenerContext.Response.StatusCode = 400;
                tempHttpListenerContext.Response.StatusDescription = "ERROR";
                tempHttpListenerContext.Response.Close();
            }        
        }

        private static object DeserializeFromStream(Stream stream)
        {
            var serializer = new JsonSerializer();

            using (var sr = new StreamReader(stream))
            using (var jsonTextReader = new JsonTextReader(sr))
            {
                return serializer.Deserialize(jsonTextReader);
            }
        }
    }

    
}
