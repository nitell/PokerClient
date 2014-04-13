using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Cygni.PokerClient.Communication.Requests;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NLog;

namespace Cygni.PokerClient.Communication
{
    internal class TexasServerSocket : IDisposable
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private const string delimiter = "_-^emil^-_";

        private Socket socket;
        private string serverName;
        private int portNumber;
        private MessageFactory messageFactory;
        private MessageBuffer messageBuffer;

        public TexasServerSocket(string serverName, int portNumber)
        {
            this.serverName = serverName;
            this.portNumber = portNumber;
        }


        public void Connect()
        {
            logger.Log(LogLevel.Info, String.Format("Connecting to {0}:{1}", serverName, portNumber));
            socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(serverName, portNumber);
            messageFactory = new MessageFactory();
            messageBuffer = new MessageBuffer(delimiter);
        }

        public void Send(TexasMessage msg)
        {
            var json =
                JsonConvert.SerializeObject(msg, Formatting.None,
                    new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }) +
                delimiter;
            logger.Log(LogLevel.Trace, "Sending " + json);
            var bytes = Encoding.ASCII.GetBytes(json);
            socket.Send(bytes);
        }

        public IEnumerable<TexasMessage> Receive()
        {

            var buffer = new byte[1000];
            int i = socket.Receive(buffer);
            messageBuffer.Input(Encoding.ASCII.GetString(buffer, 0, i));
            foreach (var msg in messageBuffer.ReadMessages())
            {
                logger.Log(LogLevel.Trace, "Received " + msg);
                yield return messageFactory.CreateMessage(msg);
            }
        }

        public void Dispose()
        {
            ((IDisposable) socket).Dispose();
        }
    }
}
