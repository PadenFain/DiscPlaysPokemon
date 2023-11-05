using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.IO;
using System.Threading.Tasks;
using WindowsInput;



namespace DiscPlaysPokemon.Commands
{
    public class GbaCommands : BaseCommandModule
    {
        [Command("init")]
        public async Task GbaWindow(CommandContext ctx)
        {
            await Task.Delay(500);
            var inputSim = new InputSimulator();
            string rootDir = Path.GetFullPath(Environment.CurrentDirectory);
            string screenshotDir = rootDir + "\\Screenshots\\";
            DiscordButtonComponent buttonUp = new DiscordButtonComponent(DSharpPlus.ButtonStyle.Primary, "1", "^");
            DiscordButtonComponent buttonDown = new DiscordButtonComponent(DSharpPlus.ButtonStyle.Primary, "2", "v");
            DiscordButtonComponent buttonLeft = new DiscordButtonComponent(DSharpPlus.ButtonStyle.Primary, "3", "<");
            DiscordButtonComponent buttonRight = new DiscordButtonComponent(DSharpPlus.ButtonStyle.Primary, "4", ">");
            DiscordButtonComponent buttonA = new DiscordButtonComponent(DSharpPlus.ButtonStyle.Primary, "5", "A");
            DiscordButtonComponent buttonB = new DiscordButtonComponent(DSharpPlus.ButtonStyle.Primary, "6", "B");
            DiscordButtonComponent buttonStart = new DiscordButtonComponent(DSharpPlus.ButtonStyle.Primary, "7", "Start");
            DiscordButtonComponent buttonSelect = new DiscordButtonComponent(DSharpPlus.ButtonStyle.Primary, "8", "Select");
            DiscordButtonComponent buttonL = new DiscordButtonComponent(DSharpPlus.ButtonStyle.Primary, "9", "L");
            DiscordButtonComponent buttonR = new DiscordButtonComponent(DSharpPlus.ButtonStyle.Primary, "10", "R");
            try
            {
                DirectoryInfo di = new DirectoryInfo(screenshotDir);
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
            }
            catch (Exception)
            {
                Directory.CreateDirectory(rootDir + "\\Screenshots\\");
            }
            inputSim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.F12);
            inputSim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.F12);
            await Task.Delay(200);
            string screenShot = screenshotDir + "\\Pokemon - Emerald Version (USA, Europe)-0.png";
            FileStream fs = new FileStream(screenShot, FileMode.Open, FileAccess.Read);
            var msg = new DiscordMessageBuilder()
                .AddFile(fs)
                .AddEmbed(new DiscordEmbedBuilder()
                .WithTitle("Controls")
                )
                .AddComponents(buttonUp, buttonDown, buttonLeft, buttonRight, buttonL)
                .AddComponents(buttonA, buttonB, buttonStart, buttonSelect, buttonR);
            await ctx.Channel.SendMessageAsync(msg);
            fs.Close();
        }
    } 
    
}
