using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwitchBotQueue
{
    public class Queue
    {
        MainForm mainRef;
        List<Player> players = new List<Player>();

        public Queue(MainForm _mainRef) => mainRef = _mainRef;

        public Player GetPlayer(string playername) {
            playername = string.Concat(playername.Where(char.IsLetterOrDigit));
            foreach (Player player in players)
            {
                if(player.playerName == playername)
                {
                    return player;
                }
            }
            return new Player();
        }

        public void DeQueuePlayer(string playername)  {
            playername = string.Concat(playername.Where(char.IsLetterOrDigit));
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].playerName == playername)
                {
                    players[i].unQueuedTime = DateTime.Now;
                    break;
                }
            }
        }

        public Player QueuePlayer(string playername) {
            playername = string.Concat(playername.Where(char.IsLetterOrDigit));
            foreach (Player p in players)
            {
                if (p.playerName == playername)
                {
                    if(mainRef.twitchBot != null && mainRef.twitchBot.twitchChat != null)
                        if (mainRef.twitchBot.twitchChat.Connected)
                            mainRef.twitchBot.SendMsg("@" + playername + ": You are already in the queue, or your name is invalid.");
                    return new Player();
                }
            }

            Player player = new Player();
            player.playerName = playername;
            player.queueTime = DateTime.Now;
            players.Add(player);
            return player;
        }
    }
}
