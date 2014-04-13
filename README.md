PokerClient
===========

A C# client for Cygnis texas hold'em at poker.cygni.se

To get started, clone this repository, build and run using Visual Studio 2013.
The project includes a fully functional bot (Cygni.PokerClient.Bots.SimpleBot) that will connect
to the training room at poker.cygni.se and play to its best ability.
The bot will use your hostname as its player name.

Typical output of a run:

Cygni .net Client Version 1.0.0.0
Bot:SKYNET01 SimpleBot
Hit Ctrl+C to quit

20:04:05 Cygni.PokerClient.Communication.TexasServerSocket: Connecting to poker.
cygni.se:4711
Entering TRAINING, waiting for play to start...
20:04:06 Cygni.PokerClient.Game.GameState: Play started
20:04:06 Cygni.PokerClient.Game.GameState: You won been dealt a card SIX of CLUB
S
20:04:06 Cygni.PokerClient.Game.GameState: You won been dealt a card ACE of HEAR
TS
20:04:06 Cygni.PokerClient.Game.GameState: Weighted bet small blind 5$
20:04:06 Cygni.PokerClient.Game.GameState: Raiser bet big blind 10$
20:04:06 Cygni.PokerClient.Game.GameState: Sensible raised 20$
20:04:06 Cygni.PokerClient.Game.GameState: Cautious folded
20:04:06 Cygni.PokerClient.Game.GameState: Hellmuth folded
20:04:06 Cygni.PokerClient.Program: Bot chose to CALL for 20$
20:04:06 Cygni.PokerClient.Game.GameState: SKYNET01 called for 20$
20:04:06 Cygni.PokerClient.Game.GameState: Weighted raised 25$
20:04:06 Cygni.PokerClient.Game.GameState: Raiser raised 30$
20:04:06 Cygni.PokerClient.Game.GameState: Weighted called for 10$
