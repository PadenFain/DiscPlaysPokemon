DiscPlaysPokemon Setup:

This is a very rough version that will eventually be improved upon. 

Prereqs: GBA Emulator(preferably mGBA) and your Discord bot token.  You will also need your discord bot account in your discord server channel with permissions to read message and send and edit messages with files.   

Step 1: Unzip DiscPlaysPokemon.zip 
Step 2: Open a GBA emulator.  I highly suggest using mGBA as this application was written using it.
Step 3: REQUIRED EMULATOR BINDINGS THE PROGRAM WILL NOT FUNCTION PROPERLY IF THIS IS NOT FOLLOWED
	Up: "w"
	Down: "s"
	Left: "a"
	Right: "d"
	A button: "x"
	B button: "z"
	Start button: "return" (Enter)
	Select button: "backspace"
	L Button: "q"
	R button: "e"
	Screenshot button: "F12"

Step 4: Set your screenshot directory within mGBA to ...\DiscPlaysPokemon\Release\Screenshots
Step 5: Open "key.json" FROM THE RELEASE FOLDER (not the one in Bin) in any text editor, notepad is more than fine, and replace "Token" with your discord bot token, keeping it within the quotation marks.
Step 6: With the mGBA emulator running and your rom loaded (I do not assist in providing roms) run either the shortcut from the main folder or DiscPlaysPokemon.exe from the Release folder.
Step 7: This is where it gets even more awkward, because in this program's current state you need to always have the emulator as a focused window or the bot will just be sending random keypresses to whatever window is in focus.
Step 8: The base command to start the bot is "!init".  This will take a screenshot, and assuming you did everything right you will now have a game window displayed as well as a set of "controls" that are interactable discord buttons.  Any interaction with the buttons in the text channel will send the input through to the emulator (assuming it's focused!), screenshot after a short ~half-second delay, and edit the displayed screenshot in the "player"

Yes, this all requires the emulator to be focused at ALL times.  And yes, I am working on getting around that but I am still very new to c# and this has been a learning experience for me.  

Massive thanks to SamJesus on youtube, I followed his excellent tutorial to get started with this and with programming the buttons.  Sam is not responsible for any of my messy code. https://www.youtube.com/@samjesus8
	