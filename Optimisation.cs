using Raylib_cs;

namespace tinycube;

public static class OptimFuncs {
	public static Block[,,] world;

	public static void InitWorld(int maxx, int maxy, int maxz) {
		world = new Block[maxy, miny, minz];
                for(int x = 0; x < maxx; x++)
                for(int y = 0; y < maxy; y++)
                for(int z = 0; z < maxz; z++) {
	                world[x, y, z] = new Block(new Vector3(x, y, z), 0);
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
