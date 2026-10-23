using Raylib_cs;
using System.Numerics;

namespace tinycube;

public static class Texture {
	public static Texture2D[] map = new Texture2D[10]; // max txts for testing
	
	public static void Init() {
		map[0] = Raylib.LoadTexture("./bricks.png");
	}

	public static void Uninit() {
		for(int i = 0; i < map.Length; i++)
			Raylib.UnloadTexture(map[i]);
	}
}
