using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cygni.PokerClient.Game;
using Action = System.Action;

namespace Cygni.PokerClient.Communication.Requests
{
    public class ActionRequest : TexasRequest
    {
        public List<Game.Action> PossibleActions { get; set; }

        public Game.Action Check
        {
            get { return PossibleActions.FirstOrDefault(a => a.ActionType == ActionType.CHECK); }
        }

        public Game.Action Fold
        {
            get { return PossibleActions.FirstOrDefault(a => a.ActionType == ActionType.FOLD); }
        }

        public Game.Action Raise
        {
            get { return PossibleActions.FirstOrDefault(a => a.ActionType == ActionType.RAISE); }
        }

        public Game.Action Call
        {
            get { return PossibleActions.FirstOrDefault(a => a.ActionType == ActionType.CALL); }
        }

        public Cygni.PokerClient.Game.Action AllIn
        {
            get { return PossibleActions.FirstOrDefault(a => a.ActionType == ActionType.ALL_IN); }
        }

    }
}
