# TwitchBot Queue System

![](http://bytevaultstudio.se/ShareX/chrome_PHcT1UvggU2.png)

## The idea
This would be perfect for when you are making gathers or simply was challanged by one of your viewers.
Run the application, set it up and watch the list expand with users who wants to match against or with you.
You control the queue, you control everything.
   
This is a twitch bot application which connects to a channel-chat.
It looks for specific commands like "!join" and executes commands depending on the chat message.
It has an easy to understand UI and should be pretty straight forward on how to use.

### Chat commands
> "!cmds", "!cmd" - Shows the commands list.   
> "join", "enter", "queue" - These will put the user who wrote the command in the queue list.   
> "leave", "quit", "exit" - These will remove the user from the queue list.

# Setup steps:
1. (Optional) My recommendation is to create a new twitch account and name it something like "QueueBot". Witty, right?
2. Sign in to the account you want the bot to operate from and request an oAuth key from https://twitchapps.com/tmi/

### NOTE:
You must verify if the bot writes anything to the chat once it has been started. If it doesn't, please verify settings and try again. There is no way to know if the bot was successful.
