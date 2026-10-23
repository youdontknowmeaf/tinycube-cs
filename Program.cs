using Raylib_cs;
using System.Numerics;

namespace tinycube;

public static class Program {
	public static void Main() {
		
		Raylib.InitWindow(1280, 720, "TinyCube");
		Raylib.SetTargetFPS(60);

		Texture.Init();
		Block.InitDefaultCubeModel();
		
		//Texture2D exampletxt = Raylib.LoadTexture("./bricks.png");
               	int test = 5;
		int maxy = test;
		int miny = test;
		int minz = test;

		Block[,,] world = new Block[maxy, miny, minz];

		for(int x = 0; x < maxy; x++)
			for(int y = 0; y < miny; y++)
				for(int z = 0; z < minz; z++) {
					world[x, y, z] = new Block(new Vector3(x, y, z), 0);
					world[x, y, z].Init();
			}

		//Block example = new Block(new Vector3(0.0f, 0.0f, 0.0f), exampletxt);

		Player.Init();
		//example.Init();

		while (!Raylib.WindowShouldClose()) {
			Raylib.BeginDrawing();
			Raylib.ClearBackground(Color.RayWhite);

			Raylib.BeginMode3D(Player.Camera);
				//example.Draw();
				//Render.DrawBlock(0.0f, 0.0f, 0.0f, Color.Red);
				OptimFuncs.DrawWorld();

				Render.DrawOutline(0.0f, 0.0f, 0.0f, Color.DarkGray);
				Raylib.DrawGrid(10, 1.0f);

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
