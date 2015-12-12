////////////////////
// 
// This Code Listens to the CSGO GameState API and provides feedback
// 
// Author: Johannes Gocke, johannes_gocke@hotmail.de
// 
///////////////////

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CSGOGameObserverSDK
{
    //<summary>
    // This class provides easy access to the CSGOServer created by a CSGOClient with matching config. 
    //</summary>



    public class CSGOGameObserverServer
    {
        private string GameServerAdress;
        private HttpListener CSGOGameListener;

        //Delegate to enable Subscription to the event of MessageReceived
        public delegate void receiveCSGOServerMessage(object sender, JObject gameData);
        public event receiveCSGOServerMessage receivedCSGOServerMessage;
        
        //Constructor, this version only accepts the direct adress, no auth, no parameter
        public CSGOGameObserverServer(string tempGameServerAdress)
        {
            GameServerAdress = tempGameServerAdress;
        }

        //Starts the Server, starts Listening
        public void Start()
        {
            ConfigureServer();
            RunServer();
        }

        private void ConfigureServer()
        {
            //Create Local Server, Listening to CSGO Client
            CSGOGameListener = new HttpListener();
            CSGOGameListener.Prefixes.Add(GameServerAdress);
        }

        private async void RunServer()
        {
            CSGOGameListener.Start();

            //Catches all requests by the CSGOClient, startes a new Task for each Message, async
            while (true)
            {
                var httpListenerContext = await CSGOGameListener.GetContextAsync();

                //messages may arrive early/late
                #pragma warning disable 4014
                Task.Factory.StartNew(() => ProcessRequest(httpListenerContext));
                #pragma warning restore 4014
            }
        }

        private void ProcessRequest(HttpListenerContext httpListenerContext)
        {
            //Receive request and transform in JSON
            HttpListenerRequest httpListenerRequest = httpListenerContext.Request;

            try
            {
                JObject gameData = (JObject)DeserializeFromStream(httpListenerRequest.InputStream);

                //respond to the CSGOClient in a timely fashion.
                httpListenerContext.Response.StatusCode = 200;
                httpListenerContext.Response.StatusDescription = "OK";
                httpListenerContext.Response.Close();

                //call the MessageReceived Event
                receivedCSGOServerMessage?.Invoke(this, gameData);
            }
            catch (Exception)
            {
                //respond to the CSGOClient with an error.
                httpListenerContext.Response.StatusCode = 400;
                httpListenerContext.Response.StatusDescription = "ERROR";
                httpListenerContext.Response.Close();
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
