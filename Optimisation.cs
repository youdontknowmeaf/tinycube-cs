using Raylib_cs;

namespace tinycube;

public static class OptimFuncs {

	public static void DrawWorld(int maxy, int maxy, int maxz) {
		for(int x = 0; x < maxy; x++)
		for(int y = 0; y < maxy; y++)
		for(int z = 0; z < maxz; z++)
			world[x, y, z].Draw();
	}

	public static void DisableBlock(ref Block blk) {
		blk.visible = false;
	}
}
