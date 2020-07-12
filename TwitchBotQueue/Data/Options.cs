using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchBotQueue.Data
{
    public class Options
    {
        // Bot Information
        public string botName = "";
        public string password = "";
        public string channelName = "";

        // Connection data
        public string host = "irc.chat.twitch.tv";
        public int port = 6667;
    }
}