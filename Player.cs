using Raylib_cs;
using System.Numerics;

namespace tinycube;

public static class Player {

public static float posx = 0.0f;
public static float posy = 10.0f;
public static float posz = 10.0f;
public static float FOV = 45.0f;
public static float targetx = 0;
public static float targety = 0;
public static float targetz = 0;

public static Camera3D Camera;

	public static void Init() {
		Camera = new Camera3D {
                        Position = new Vector3(posx, posy, posz), // pos
                        Target = new Vector3(targetx, targety, targetz), // look @
                        Up = new Vector3(0.0f, 1.0f, 0.0f),
                        FovY = FOV,
                        Projection = CameraProjection.Perspective
                };
	}

	public static void Update() {
		
		Camera.Position = new Vector3(posx, posy, posz);
		Camera.Target = new Vector3(targetx, targety, targetz);
	}
}
