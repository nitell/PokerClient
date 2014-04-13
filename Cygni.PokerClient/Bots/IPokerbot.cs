using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cygni.PokerClient.Communication.Requests;
using Cygni.PokerClient.Game;
using Action = System.Action;

namespace Cygni.PokerClient.Bots
{
    public interface IPokerBot
    {
        string Name { get; }
        Game.Action Act(ActionRequest request, GameState gameState);
    }
}
