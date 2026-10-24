using Raylib_cs;
using System.Numerics;
using static System.Console;

namespace tinycube;

public static class OptimFuncs {
	public static Block[,,] world = new Block[512, 512, 512];
	public static int[,,] WorldData = new int[512, 512, 512];

	public static void InitWorld(int maxx, int maxy, int maxz) {
		if (maxx > 512 && maxy > 512 && maxz > 512) {
			WriteLine("WORLD SIZE TOO BIG!\nMax world size: 512x512x512");
			return;	
		}
                for(int x = 0; x < maxx; x++)
                for(int y = 0; y < maxy; y++)
                for(int z = 0; z < maxz; z++) {
			if (y != 69)
                        	WorldData[x, y, z] = 0;
			else
				WorldData[x, y, z] = 1;
	                world[x, y, z] = new Block(new Vector3(x, y, z), WorldData[x, y, z]);
                        world[x, y, z].Init();
		}

	}
	public static void DrawWorld(int maxx, int maxy, int maxz) {
		for(int x = 0; x < maxy; x++)
		for(int y = 0; y < maxy; y++)
		for(int z = 0; z < maxz; z++)
			world[x, y, z].Draw();
	}

	private static void DisableBlock(ref Block blk) {
		blk.visible = false;
	}
}
