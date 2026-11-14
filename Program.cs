using Raylib_cs;
using System.Numerics;

namespace tinycube;

public static class Program {
	private const int WORLD_SIZE = 10;

	public static void Main() {
		
		Raylib.InitWindow(1280, 720, "TinyCube");
		Raylib.SetTargetFPS(1024);

		Texture.Init();
		Block.InitDefaultCubeModel();
		
		OptimFuncs.InitWorld(WORLD_SIZE, WORLD_SIZE, WORLD_SIZE);
		OptimFuncs.ScanAllWorld(WORLD_SIZE, WORLD_SIZE, WORLD_SIZE);
		Player.Init();

		while (!Raylib.WindowShouldClose()) {
			Raylib.BeginDrawing();
			Raylib.ClearBackground(Color.RayWhite);
			Player.Update();
			Raylib.BeginMode3D(Player.Camera);
				OptimFuncs.DrawWorld(128, 128, 128);

				Render.DrawOutline(0.0f, 0.0f, 0.0f, Color.DarkGray);
				Raylib.DrawGrid(WORLD_SIZE, 1.0f);

			Raylib.EndMode3D();

			Raylib.DrawText("Hi!", 10, 10, 20, Color.Black);
			Raylib.DrawFPS(10, 30);
			Raylib.EndDrawing();
		}
                Block.Unload();
		Texture.Uninit();
		Raylib.CloseWindow();
	}
}
