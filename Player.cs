using Raylib_cs;
using System.Numerics;

namespace tinycube;

public static class Player {

public static float posx = 0.0f;
public static float posy = 10.0f;
public static float posz = 10.0f;
public static float FOV = 45.0f;
private static float targetx = 0;
private static float targety = 0;
private static float targetz = 0;
private static Vector2 MouseDelta = Raylib.GetMouseDelta();
public static Camera3D Camera; // Just for loop.
private static float speed = 1.0f;

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
		MouseDelta = Raylib.GetMouseDelta();
		Raylib.UpdateCamera(ref Camera, CameraMode.Free);
		/*
		speed = 1.0f * Raylib.GetFrameTime();	
		if (Raylib.IsKeyDown(KeyboardKey.Space)) {
			Camera.Position = new Vector3(Camera.Position.X, Camera.Position.Y + speed, Camera.Position.Z);
			Camera.Target = new Vector3(Camera.Position.X, Camera.Position.Y + speed, Camera.Position.Z);
		}
		if (Raylib.IsKeyDown(KeyboardKey.LeftShift)) {
			Camera.Position = new Vector3(Camera.Position.X, Camera.Position.Y - speed, Camera.Position.Z);
			Camera.Target = new Vector3(Camera.Position.X, Camera.Position.Y - speed, Camera.Position.Z);
		}
	*/
		//Camera.Position = new Vector3(posx, posy, posz);
		//Camera.Target = new Vector3(targetx, targety, targetz);
	}
}
