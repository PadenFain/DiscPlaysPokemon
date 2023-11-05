using DiscPlaysPokemon.Commands;
using DiscPlaysPokemon.config;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using System;
using System.Threading.Tasks;

namespace DiscPlaysPokemon
{
    public sealed class Program
    {

        public static DiscordClient Client { get; set; }
        public static CommandsNextExtension Commands { get; set; }

        static async Task Main(string[] args)
        {
            {
                var keyreader = new Keyreader();
                await keyreader.ReadJson();
                var discordConfig = new DiscordConfiguration()
                {
                    Intents = DiscordIntents.All,
                    Token = keyreader.Token,
                    TokenType = TokenType.Bot,
                    AutoReconnect = true,
                };

                Client = new DiscordClient(discordConfig);

                Client.Ready += Client_Ready;
                Client.ComponentInteractionCreated += ComponentInteract.GbaInputs;

                ComponentInteract componentInteract = new ComponentInteract();

                var commandsConfig = new CommandsNextConfiguration()
                {
                    StringPrefixes = new string[] { "!" },
                    EnableMentionPrefix = true,
                    EnableDms = true,
                    EnableDefaultHelp = false,
                };

                Commands = Client.UseCommandsNext(commandsConfig);

                Commands.RegisterCommands<GbaCommands>();

                await Client.ConnectAsync();

                await Task.Delay(-1);
            };
        }



        private static Task Client_Ready(DiscordClient sender, DSharpPlus.EventArgs.ReadyEventArgs args)
        {
            if (args is null)
            {
                throw new System.ArgumentNullException(nameof(args));
            }
            return Task.CompletedTask;
        }
    }
}
