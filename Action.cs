using Raylib_cs;
using System.Numerics;

namespace tinycube;

public static class Actions {

public static void scan_actions(int hitX, int hitY, int hitZ, int placeX, int placeY, int placeZ) {
	if (Raylib.IsMouseButtonPressed(MouseButton.Left)) {
                                OptimFuncs.WorldData[hitX, hitY, hitZ] = 69;
                                if (OptimFuncs.world[hitX, hitY, hitZ] != null) {
                                        OptimFuncs.world[hitX, hitY, hitZ].visible = false;
                                }
                                OptimFuncs.ScanNeighbours(hitX, hitY, hitZ, 128, 128, 128);
				OptimFuncs.world[hitX, hitY, hitZ] = null;
                        }
        if (Raylib.IsMouseButtonPressed(MouseButton.Right)) {
				if (placeX >= 0 && placeX < 128 && placeY >= 0 && placeY < 128 && placeZ >= 0 && placeZ < 128) {
					OptimFuncs.WorldData[placeX, placeY, placeZ] = 1;
					if (OptimFuncs.world[placeX, placeY, placeZ] == null) {
						OptimFuncs.world[placeX, placeY, placeZ] = new Block(
								new Vector3(placeX, placeY, placeZ),
								OptimFuncs.WorldData[placeX, placeY, placeZ]);
						OptimFuncs.world[placeX, placeY, placeZ]!.Init();
					}
					OptimFuncs.world[placeX, placeY, placeZ]!.visible = true;
					OptimFuncs.ScanNeighbours(placeX, placeY, placeZ, 128, 128, 128);
				}
                        }
	}
}
