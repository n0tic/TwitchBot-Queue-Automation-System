using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchBotQueue
{
    public class Player
    {
        public string playerName = "";
        public DateTime queueTime = DateTime.Now;
        public DateTime unQueuedTime;
    }
}
