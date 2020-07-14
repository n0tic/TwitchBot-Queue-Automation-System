using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TwitchBotQueue.Data
{
    [Serializable]
    public class Automation
    {
        public string automationName = "";
        public int interval = 0;
        public string message = "";
        public int threadIndex = -1;
        public bool active = false;
        public bool running = false;

        public Automation(string name, int _interval, string _message, int _threadIndex, bool _active) {
            automationName = name;
            interval = _interval;
            message = _message;
            threadIndex = _threadIndex;
            active = _active;
        }
    }
}
