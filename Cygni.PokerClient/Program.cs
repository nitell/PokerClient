using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Cygni.PokerClient.Bots;
using Cygni.PokerClient.Communication;
using Cygni.PokerClient.Communication.Requests;
using Cygni.PokerClient.Communication.Responses;
using Cygni.PokerClient.Game;
using NLog;

namespace Cygni.PokerClient
{
    class Program
    {
        private const string serverName = "poker.cygni.se";
        private const int portNumber = 4711;
        private const string roomName = "TRAINING";
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static IPokerBot bot;

        static void Main(string[] args)
        {
            try
            {
                bot = new SimpleBot();
                Console.WriteLine("Cygni .net Client Version {0}", Assembly.GetExecutingAssembly().GetName().Version);
                Console.WriteLine("Bot:{0} {1}", bot.Name, bot.GetType().Name);
                Console.WriteLine("Hit Ctrl+C to quit\n\n");
                using (var socket = new TexasServerSocket(serverName, portNumber))
                {
                    var gameState = new GameState();

                    socket.Connect();
                    Console.WriteLine("Entering {0}, waiting for play to start...", roomName);
                    socket.Send(new RegisterForPlayRequest(bot.Name, roomName));
                    while (true)
                    {
                        foreach (var msg in socket.Receive())
                        {
                            if (msg is ActionRequest)
                            {
                                var request = msg as ActionRequest;
                                var action = bot.Act(request, gameState);
                                var response = new ActionResponse(action, request.RequestId);
                                logger.Log(LogLevel.Info,
                                    String.Format("Bot chose to {0} for {1}$", action.ActionType, action.Amount));
                                socket.Send(response);
                            }

                            else
                            {
                                gameState.UpdateFrom(msg);
                            }
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ooops: " + ex);
                logger.LogException(LogLevel.Fatal, "Catastrophic error", ex);
            }
        }
    }
}
