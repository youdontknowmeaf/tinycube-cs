using Raylib_cs;
using System.Numerics;
using static System.Console;

namespace tinycube;

public static class OptimFuncs {
	public static Block[,,] world = new Block[128, 128, 128];
	public static int[,,] WorldData = new int[128, 128, 128];

	public static void InitWorld(int maxx, int maxy, int maxz) {
		if (maxx > 100 && maxy > 100 && maxz > 100) {
			WriteLine("WORLD SIZE TOO BIG!\nMax world size: 128x128x128");
			return;	
		}
                for(int x = 0; x < maxx; x++)
                for(int y = 0; y < maxy; y++)
                for(int z = 0; z < maxz; z++) {
			if (y % 2 == 0)
                        	WorldData[x, y, z] = 0;
			else
				WorldData[x, y, z] = 1;
	                world[x, y, z] = new Block(new Vector3(x, y, z), WorldData[x, y, z]);
                        world[x, y, z].Init();
		}

	}
	public static void DrawWorld(int maxx, int maxy, int maxz) {
		for(int x = 0; x < maxx; x++)
		for(int y = 0; y < maxy; y++)
		for(int z = 0; z < maxz; z++)
			world[x, y, z].Draw();
	}

	private static void DisableBlock(ref Block blk) {
		blk.visible = false;
	}

	private static void EnableBlock(ref Block blk) {
		blk.visible = true;
	}

	public static void UpdateSingle(int ax, int ay, int az, int maxx, int maxy, int maxz) {
 	int left  = (ax - 1 >= 0) ? WorldData[ax - 1, ay, az] : 69;
 	int right = (ax + 1 < maxx) ? WorldData[ax + 1, ay, az] : 69;
 	int down  = (ay - 1 >= 0) ? WorldData[ax, ay - 1, az] : 69;
 	int up    = (ay + 1 < maxy) ? WorldData[ax, ay + 1, az] : 69;
 	int back  = (az - 1 >= 0) ? WorldData[ax, ay, az - 1] : 69;
 	int fwd   = (az + 1 < maxz) ? WorldData[ax, ay, az + 1] : 69;
	
	bool Worse = new int[] { left, right, down, up, back, fwd }.Contains(69);

	Block tmp = world[ax, ay, az];
	if(tmp != null) {
		if(!Worse)
			DisableBlock(ref world[ax, ay, az]);
		else
			EnableBlock(ref world[ax, ay, az]);
	}
	}

	public static void ScanAllWorld(int maxx, int maxy, int maxz) {
                for(int x = 0; x < maxx; x++)
                for(int y = 0; y < maxy; y++)
                for(int z = 0; z < maxz; z++)
			UpdateSingle(x, y, z, maxx, maxy, maxz);
	}
}
