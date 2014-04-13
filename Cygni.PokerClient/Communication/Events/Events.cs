using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cygni.PokerClient.Game;

namespace Cygni.PokerClient.Communication.Events
{

    class PlayIsStartedEvent : TexasEvent
    {
        public List<GamePlayer> Players { get; set; }
        public long SmallBlindAmount { get; set; }
        public long BigBlindAmount { get; set; }
        public GamePlayer Dealer { get; set; }
        public GamePlayer SmallBlindPlayer { get; set; }
        public GamePlayer BigBlindPlayer { get; set; }
        public long TableId { get; set; }
    }

    class CommunityHasBeenDealtACardEvent : TexasEvent
    {
        public Card Card { get; set; }
    }

    class PlayerBetBigBlindEvent : TexasEvent
    {
        public GamePlayer Player { get; set; }
        public long BigBlind { get; set; }
    }

    class PlayerBetSmallBlindEvent : TexasEvent
    {
        public GamePlayer Player { get; set; }
        public long SmallBlind { get; set; }
    }

    class PlayerCalledEvent : TexasEvent
    {
        public GamePlayer Player { get; set; }
        public long CallBet { get; set; }
    }

    class PlayerCheckedEvent : TexasEvent
    {
        public GamePlayer Player { get; set; }
    }

    class PlayerFoldedEvent : TexasEvent
    {
        public GamePlayer Player { get; set; }
        public long InvestmentInPot { get; set; }
    }

    class PlayerForceFoldedEvent : TexasEvent
    {
        public GamePlayer Player { get; set; }
        public long InvestmentInPot { get; set; }
    }

    class PlayerQuitEvent : TexasEvent
    {
        public GamePlayer Player { get; set; }
    }

    class PlayerRaisedEvent : TexasEvent
    {
        public GamePlayer Player { get; set; }

        public long RaiseBet { get; set; }

    }

    class PlayerWentAllInEvent : TexasEvent
    {
        public GamePlayer Player { get; set; }
        public long AllInAmount { get; set; }       
    }

    class ServerIsShuttingDownEvent : TexasEvent
    {
        public string Message { get; set; }       
    }

    class ShowDownEvent : TexasEvent
    {
        public List<PlayerShowDown> PlayersShowDown { get; set; }
    }

    public class TableChangedStateEvent : TexasEvent
    {
        public PlayState State { get; set; }
    }

    class TableIsDoneEvent : TexasEvent
    {
        public List<GamePlayer> Players { get; set; }
    }


    class YouHaveBeenDealtACardEvent : TexasEvent
    {
        public Card Card { get; set; }   
    }

    public class YouWonAmountEvent : TexasEvent
    {
        public long WonAmount { get; set; }
        public long YourChipAmount { get; set; }

      
    }


}
