using Discord;
using Discord.Commands;
using System;

namespace DiscordBot
{
    public class Magic8BallBot
    {
        DiscordClient client;
        CommandService commands;
        Random rand;

        public Magic8BallBot()
        {
            client = new DiscordClient(input =>
            {
                input.LogLevel = LogSeverity.Info;
                input.LogHandler = Log;
            } );

            client.UsingCommands(input =>
            {
                input.PrefixChar = '?';
                input.AllowMentionPrefix = true;
            });

            commands = client.GetService<CommandService>();

            // Commands
            commands.CreateCommand("#")
                .Parameter("question", ParameterType.Unparsed)
                .Do(async (e) =>
                {
                    await (e.Channel.SendMessage(getResponse(e.User.Name, getRand())));
                });

            client.ExecuteAndWait(async () =>
            {
                await (client.Connect("MzA3NTQ1MjgzMjIxNTIwMzg0.C-T3dw.JpyCX1gE7HhmHKtxqpkWeRt5QL8", TokenType.Bot));
            });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private int getRand()
        {
            rand = new Random(DateTime.Now.Millisecond);
            return rand.Next(1, 21);
        }

        private string getResponse(string username, int randomNumber)
        {
            switch (randomNumber)
            {
                case 1:
                    return "Very doubtful " + username;
                case 2:
                    return "Sorry " + username + " Outlook not so good.";
                case 3:
                    return "My sources say no " + username;
                case 4:
                    return "My reply is no " + username;
                case 5:
                    return "Don't count on it " + username;
                case 6:
                    return "Hey there, " + username + " Concentrate and ask again";
                case 7:
                    return "Cannot predict now";
                case 8:
                    return "Better not tell you now " + username;
                case 9:
                    return "Hah, " + username + " ask again later..";
                case 10:
                    return "Reply hazy try again";
                case 11:
                    return "Signs point to yes";
                case 12:
                    return "Yes " + username + ", yes...";
                case 13:
                    return "Outlook good";
                case 14:
                    return "Most likely " + username;
                case 15:
                    return "As I see it, yes " + username;
                case 16:
                    return username + " you may rely on it";
                case 17:
                    return "Yes definitely " + username;
                case 18:
                    return "Without a doubt " + username;
                case 19:
                    return "It is decidedly so";
                case 20:
                    return "It is certain";
                default:
                    return "Something went horribly wrong... please re-check the code";
            }
        }
    }
}
