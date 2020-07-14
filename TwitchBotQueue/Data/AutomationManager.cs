using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwitchBotQueue.Data
{
    [Serializable]
    public class AutomationManager
    {
        MainForm mainRef;

        public Automations automations = new Automations();
        //public List<Thread> automationThreads = new List<Thread>(); // Index 0 should never be used.
        public List<System.Timers.Timer> timers = new List<System.Timers.Timer>();

        public enum AutomationController
        {
            Start,
            Stop
        }

        public AutomationManager(MainForm _mainRef) {
            mainRef = _mainRef;
            if(SaveLoad.DoesSaveExist(null))
            {
                Automations tmpAuto = (Automations)SaveLoad.LoadFromFile<Automations>(null);
                if(tmpAuto != null && tmpAuto.automation.Count > 0) FixThreads(tmpAuto);
            }
        }

        void FixThreads(Automations tmpAuto) {
            foreach (Automation auto in tmpAuto.automation) AddAutomation(auto.automationName, auto.interval, auto.message, auto.active);
        }

        public bool AddAutomation(string name, int minutes, string message, bool active) {
            if (name.Length > 20) name = name.Substring(0, 20);

            if (DoesNameAlreadyExist(name))
            {
                MessageBox.Show("This name does already exist. Try again.", "Name already exist!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            mainRef.autoList.Items.Add(name);

            automations.automation.Add(new Automation(name, minutes, message, timers.Count, active));
            timers.Add(CreateTimer(automations.automation[automations.automation.Count - 1]));

            if(mainRef != null && mainRef.twitchBot != null && mainRef.twitchBot.twitchChat != null && mainRef.twitchBot.twitchChat.Connected && active) {
                timers[automations.automation.Count - 1].Enabled = true;
                automations.automation[automations.automation.Count - 1].running = true;
            }
            SaveLoad.SaveDataToFile(automations, null);
            return true;
        }

        System.Timers.Timer CreateTimer(Automation auto) {
            System.Timers.Timer Timer = new System.Timers.Timer();
            Timer.Elapsed += (sender, e) => ATimer_Elapsed(sender, e, auto);
            Timer.Interval = TimeSpan.FromMinutes(auto.interval).TotalMilliseconds;
            return Timer;
        }

        private void ATimer_Elapsed(object sender, ElapsedEventArgs e, Automation auto) => mainRef.RunAutomation(auto);

        public void Automation(AutomationController controller, string name) {
            foreach (Automation auto in automations.automation)
            {
                string tmpString = "";

                if (auto.automationName.Length > 20) tmpString = auto.automationName.Substring(0, 20);
                else tmpString = auto.automationName;

                if (name == tmpString) 
                {
                    if (controller == AutomationController.Start) {
                        if (timers[auto.threadIndex] != null && !auto.running && !timers[auto.threadIndex].Enabled) {
                            timers[auto.threadIndex].Enabled = true;
                            auto.running = true;
                        }
                    }
                    else {
                        if (timers[auto.threadIndex] != null && auto.running && timers[auto.threadIndex].Enabled) {
                            timers[auto.threadIndex].Enabled = false;
                            auto.running = false;
                        }
                    }
                    break;
                }
            }
        }

        public Automation GetAutomation(string name) {
            foreach (Automation auto in automations.automation)
            {
                string tmpString = "";
                if (auto.automationName.Length > 20) tmpString = auto.automationName.Substring(0, 20);
                else tmpString = auto.automationName;

                if (name == tmpString)
                {
                    return auto;
                }
            }
            return null;
        }

        public void DeleteAutomation(string name)  {
            string tmpString = "";
            if (name.Length > 20) tmpString = name.Substring(0, 20);
            else tmpString = name;

            int tmpInt = -1;
            for(int i = 0; i < automations.automation.Count; i++)
            {
                if(automations.automation[i].automationName == tmpString)
                {
                    tmpInt = i;
                    break;
                }
            }

            if(tmpInt != -1)
            {
                if(automations.automation[tmpInt].running)
                {
                    timers[automations.automation[tmpInt].threadIndex].Enabled = false;
                    automations.automation[tmpInt].running = false;
                }

                mainRef.autoList.Items.Remove(automations.automation[tmpInt].automationName);
                timers[automations.automation[tmpInt].threadIndex] = null;
                automations.automation.RemoveAt(tmpInt);
            }

            SaveLoad.SaveDataToFile(automations, null);
            GC.Collect();
        }

        public void KillThreads() {
            try
            {
                foreach (System.Timers.Timer timer in timers)
                {
                    timer.Enabled = false;
                }
                foreach (Automation auto in automations.automation)
                {
                    auto.running = false;
                }
            }
            catch(Exception)
            {
                //Do nothing...
            }
        }

        public void StartThreads() {
            foreach(Automation auto in automations.automation) {
                if(auto.active) Automation(AutomationController.Start, auto.automationName);
            }
        }

        public bool DoesNameAlreadyExist(string name) {
            foreach(Automation auto in automations.automation) { 
                if (auto.automationName == name) return true; 
            }
            return false;
        }
    }
}
