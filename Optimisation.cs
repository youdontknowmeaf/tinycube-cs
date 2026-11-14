using Raylib_cs;
using System.Numerics;
using static System.Console;

namespace tinycube;
// I need to rename this class and file lol
public static class OptimFuncs {
	public static Block?[,,] world = new Block[128, 128, 128];
	public static int[,,] WorldData = new int[128, 128, 128];

	public static void InitWorld(int maxx, int maxy, int maxz) {
		if (maxx > 64 && maxy > 64 && maxz > 64) {
			WriteLine("WORLD SIZE TOO BIG!\nMax world size: 64x64x64");
			return;
		}
		for(int x = 0; x < 128; x++)
                for(int y = 0; y < 128; y++)
                for(int z = 0; z < 128; z++) {
                        WorldData[x, y, z] = 69;
                }

                for(int x = 0; x < maxx; x++)
                for(int y = 0; y < maxy; y++)
                for(int z = 0; z < maxz; z++) {
			if (y > maxy -2) // a neat layer of grass indeed
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
		if (world[x, y, z] != null)
			world[x, y, z].Draw();
	}

	private static void DisableBlock(ref Block blk) {
		blk.visible = false;
	}

	private static void EnableBlock(ref Block blk) {
		blk.visible = true;
	}

	public static void UpdateSingle(int ax, int ay, int az, int maxx, int maxy, int maxz) {
	if (ax < 0 || ax >= 128 || ay < 0 || ay >= 128 || az < 0 || az >= 128) return;
	if (WorldData[ax, ay, az] == 69) return; // empty cell, nothing to show

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

	public static void ScanNeighbours(int x, int y, int z, int maxx, int maxy, int maxz) {
		UpdateSingle(x - 1, y, z, maxx, maxy, maxz);
    		UpdateSingle(x + 1, y, z, maxx, maxy, maxz);
    		UpdateSingle(x, y - 1, z, maxx, maxy, maxz);
    		UpdateSingle(x, y + 1, z, maxx, maxy, maxz);
    		UpdateSingle(x, y, z - 1, maxx, maxy, maxz);
    		UpdateSingle(x, y, z + 1, maxx, maxy, maxz);
	}
}
