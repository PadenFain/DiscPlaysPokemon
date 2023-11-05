using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using System;
using System.IO;
using System.Threading.Tasks;
using WindowsInput;

namespace DiscPlaysPokemon.Commands
{
    public class ComponentInteract
    {
        public async static Task GbaInputs(DiscordClient sender, ComponentInteractionCreateEventArgs e)

        {   //refreshes the "player" and controls, called at the end of every input script //
            async Task Refresh(ComponentInteractionCreateEventArgs args) 
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
                await e.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder()
                    .AddFile(fs)
                    .AddEmbed(new DiscordEmbedBuilder()
                    .WithTitle("Controls")
                    )
                    .AddComponents(buttonUp, buttonDown, buttonLeft, buttonRight, buttonL)
                    .AddComponents(buttonA, buttonB, buttonStart, buttonSelect, buttonR));
                fs.Close();

            }
            if (e.Interaction.Data.CustomId == "1")
            {
                var inputSim = new InputSimulator();
                inputSim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_W);
                await Task.Delay(50);
                inputSim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_W);
                await Refresh(e);
            }
            else if (e.Interaction.Data.CustomId == "2")
            {
                var inputSim = new InputSimulator();
                inputSim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_S);
                await Task.Delay(50);
                inputSim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_S);
                await Refresh(e);
            }
            else if (e.Interaction.Data.CustomId == "3")
            {
                var inputSim = new InputSimulator();
                inputSim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_A);
                await Task.Delay(50);
                inputSim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_A);
                await Refresh(e);
            }
            else if (e.Interaction.Data.CustomId == "4")
            {
                var inputSim = new InputSimulator();
                inputSim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_D);
                await Task.Delay(50);
                inputSim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_D);
                await Refresh(e);
            }
            else if (e.Interaction.Data.CustomId == "5")
            {
                var inputSim = new InputSimulator();
                inputSim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_X);
                await Task.Delay(50);
                inputSim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_X);
                await Refresh(e);
            }
            else if (e.Interaction.Data.CustomId == "6")
            {
                var inputSim = new InputSimulator();
                inputSim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_Z);
                await Task.Delay(50);
                inputSim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_Z);
                await Refresh(e);
            }
            else if (e.Interaction.Data.CustomId == "7")
            {
                var inputSim = new InputSimulator();
                inputSim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.RETURN);
                await Task.Delay(50);
                inputSim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.RETURN);
                await Refresh(e);
            }
            else if (e.Interaction.Data.CustomId == "8")
            {
                var inputSim = new InputSimulator();
                inputSim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.BACK);
                await Task.Delay(50);
                inputSim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.BACK);
                await Refresh(e);
            }
            else if (e.Interaction.Data.CustomId == "9")
            {
                var inputSim = new InputSimulator();
                inputSim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_Q);
                await Task.Delay(50);
                inputSim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_Q);
                await Refresh(e);
            }
            else if (e.Interaction.Data.CustomId == "10")
            {
                var inputSim = new InputSimulator();
                inputSim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_E);
                await Task.Delay(50);
                inputSim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_E);
                await Refresh(e);
            }
        }
    }
}
