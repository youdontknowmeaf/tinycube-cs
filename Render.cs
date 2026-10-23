using Raylib_cs;
using System.Numerics;

namespace tinycube;

public static class Render {

	public static void DrawBlock(float x, float y, float z, Color color) {
		Raylib.DrawCube(new Vector3(x + 0.5f, y + 0.5f, z + 0.5f), 1.0f, 1.0f, 1.0f, color);
	}
	
	public static void DrawOutline(float x, float y, float z, Color color) {
                Raylib.DrawCubeWires(new Vector3(x + 0.5f, y + 0.5f, z + 0.5f), 1.0f, 1.0f, 1.0f, color);
        }
}

