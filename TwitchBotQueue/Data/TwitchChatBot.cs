using TwitchBot.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Diagnostics;
using System.Windows.Forms;
using TwitchBotQueue;

namespace TwitchBot.Object
{
    public class TwitchChatBot {
        public ConnectionData connectionData;

        MainForm mainRef;
        public TcpClient twitchChat;
        StreamReader reader;
        StreamWriter writer;
        Thread commandSender;
        Thread commandReader;
        bool runCommandSender = true;

        bool reconnect = true;

        public Queue<string> messageQueue = new Queue<string>();

        /// <summary>
        /// This will read the chat and put the thread in sleep.
        /// </summary>
        public void Update()
        {
            while(true)
            {
                //Does this trigger an error since it is running on a different thread? Probably, commenting out.
                //if (twitchChat == null || !twitchChat.Connected && reconnect) Connect();

                ReadChat();
                Thread.Sleep(50);
            }
        }

        /// <summary>
        /// Kills both threads.
        /// </summary>
        public void KillThreads() {
            commandSender.Abort();
            commandReader.Abort();
            twitchChat.Close();
        }

        /// <summary>
        /// Creates an object of the twitchChatBot.
        /// </summary>
        /// <param name="host">string ip/address</param>
        /// <param name="port">int port address</param>
        /// <param name="username">string botname</param>
        /// <param name="password">string oAuthPassword</param>
        /// <param name="channelName">string channelname to join</param>
        /// <param name="reConnect">bool reconnect feature</param>
        public TwitchChatBot(MainForm _ref, string host, int port, string username, string password, string channelName, bool reConnect) {

            mainRef = _ref;

            connectionData = new ConnectionData();
            connectionData.host = host;
            connectionData.port = port;

            connectionData.botName = username;
            connectionData.password = password;
            connectionData.channelName = channelName;

            reconnect = reConnect;

            Connect();
        }

        /// <summary>
        /// Creates the connection to the chat server.
        /// </summary>
        private void Connect()
        {
            try
            {
                twitchChat = new TcpClient(connectionData.host, connectionData.port);
            }
            catch(SocketException e) 
            {
                MessageBox.Show("Message: " + e.Message);
                Thread.Sleep(8000);
                Application.Exit();
            }

            reader = new StreamReader(twitchChat.GetStream());
            writer = new StreamWriter(twitchChat.GetStream());

            ConnectToChannel(connectionData.botName, connectionData.password, connectionData.channelName);

            if (twitchChat.Connected)
            {
                commandSender = new Thread(() => runQueue(writer));
                commandSender.Start();
                commandReader = new Thread(() => Update());
                commandReader.Start();
                SendMsg("QueueSytem Active. !cmd");
            }
        }

        /// <summary>
        /// Connects the user to the channel.
        /// </summary>
        /// <param name="username">string botname</param>
        /// <param name="password">string oAuthPassword</param>
        /// <param name="channelName">string channelname</param>
        private void ConnectToChannel(string username, string password, string channelName)
        {
            writer.WriteLine("PASS " + password);
            writer.WriteLine("NICK " + username.ToLower());
            writer.WriteLine("USER " + username.ToLower() + " 8 * :" + username.ToLower());
            writer.WriteLine("JOIN #" + channelName);
            writer.Flush();
        }

        /// <summary>
        /// Runs the commandqueue and executes commands if ther are any.
        /// </summary>
        /// <param name="writer">twitch chat</param>
        void runQueue(StreamWriter writer)
        {
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            while (runCommandSender) {
                if (messageQueue.Count > 0 && twitchChat.Connected) {
                    if (stopWatch.ElapsedMilliseconds > 1750) { // Check so that enough time has passed.
                        writer.WriteLine(messageQueue.Peek());
                        writer.Flush();

                        messageQueue.Dequeue();

                        stopWatch.Reset();
                        stopWatch.Start();
                    }
                }
                else
                    Thread.Sleep(50); // Stop overflow.
            }
        }

        /// <summary>
        /// Reads the twitch chat
        /// </summary>
        void ReadChat()
        {
            if (twitchChat.Available > 0) {
                string message = reader.ReadLine();

                if (message.Contains("PING"))
                {
                    message = message.Replace("PING", "PONG");
                    writer.WriteLine(message);
                    writer.Flush();
                    return;
                }

                if (message.Contains("PRIVMSG"))
                {
                    string user, msg;

                    user = message.Split('!')[0].Trim(':');
                    msg = message.Split(':')[2];

                    UseInformation(user, msg);
                }
            }
        }

        /// <summary>
        /// Use the information from the chat.
        /// </summary>
        /// <param name="usr">string username of sender</param>
        /// <param name="msg">string message</param>
        void UseInformation(string usr, string msg)
        {
            msg = msg.ToLower();

            //DO switch case
            switch (msg)
            {
                case "!cmds":
                case "!cmd":
                    SendMsg("!cmd(s) will show this help message. !join, !enter, !queue will put you in the queue list. !leave, !quit, !exit will remove you from the queue.");
                    break;
                case "!join":
                case "!enter":
                case "!queue":
                    mainRef.AddPlayerToQueue(usr);
                    break;
                case "!leave":
                case "!quit":
                case "!exit":
                    mainRef.RemovePlayerFromQueue(usr);
                    break;
            }
        }

        /// <summary>
        /// Sends the message to the chat
        /// </summary>
        /// <param name="msg"></param>
        public void SendMsg(string msg) => messageQueue.Enqueue("PRIVMSG #" + connectionData.channelName + " :" + msg);
    }
}
