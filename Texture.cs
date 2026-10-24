using Raylib_cs;
using System.Numerics;

namespace tinycube;

public static class Texture {
	public static Texture2D[] map = new Texture2D[69]; // max txts for testing
	private static bool[] loaded = new bool[69];
	
	public static void Init() {
		map[0] = Raylib.LoadTexture("./txt/grass.png"); loaded[0] = true;
		map[1] = Raylib.LoadTexture("./txt/cobblestone.png"); loaded[1] = true;
	}

	public static void Uninit() {
		for(int i = 0; i < map.Length; i++)
			if (loaded[i])
				Raylib.UnloadTexture(map[i]);
	}
}
