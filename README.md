# tinycube-cs
A spiritual successor to tinycube-py, rewritting in C# with RayLib.

TinyCube (C#) aims to be a pixel engine for creating Minecraft-like games.
The engine is **NOT** finished, nor close to being finished. So this repo is primarily for me right now.
Expect a lot of changes if you decide to use it.
**Not Vibe-Coded**

# Dependencies
- Microsoft C#, [.NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Raylib-cs](https://github.com/raylib-cs/raylib-cs)

# How to run
- Download .NET SDK (8.0<=) & .NET Runtime (8.0)
- Clone the repo
- Enter the folder with the files
- Open it with your terminal
- Run: ``dotnet run`` and it should automatically install all depencencies and run it
(Tested on: Ubuntu 25.04, Windows (shitdows) 11)

# Explaining the engine
The engine works by wrapping Raylib's functions into helpers and adding things like texture management by myself so I don't want to call it just a wrapper.
- **World gen** > Places blocks from 0 to X/Y/Z and then runs a scan to find blocks that are invisible and hides them.
- **Entity culling** > Scans nearby blocks to see if they are visible or not. If not - stops drawing them, if they are visible they are drawn. Simple but works.
- **Player** > W.I.P just RayLib's free camera movement
- **Textures** > All textures are loaded on start in a array called map and checks their 'loaded' bool to true. (I plan to make the textures not mandatory)
- **Cubes** > Cubes are models. One model is loaded on start and reused for each cube with a diffrent texture. Cubes hold a number telling them which texture they are. eg. if their number is 0 - they will use map[0] or if their number is 1 their texture will be map[1].

That's about it for now, I want to add more functions like simple GUI interface, f3 debug menu (X, Y, Z, CurrentBlock, WorldSize). I also want to add the ability to edit the game's/engine's settings with a .yaml so creating games is easier + modding and user's customisation should be easier (no need to recompile). I try to make the engine as modular as possible so you can replace some files 'n' shit to kinda have modding support but I work on this in my free time so the progress goes like blood from nose lol.
