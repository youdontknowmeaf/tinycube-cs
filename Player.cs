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
public static Camera3D Camera; // Nvm
private static float cspeed = 2.0f;

private static float reach = 10.0f; // self explanatory tbh
private static float raystep = 0.2f;

	public static void Init() {
		Raylib.DisableCursor();
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
		Raylib.UpdateCamera(ref Camera, CameraMode.FirstPerson);
		float speed = cspeed * Raylib.GetFrameTime();	
		if (Raylib.IsKeyDown(KeyboardKey.Space)) {
			Camera.Position = new Vector3(Camera.Position.X, Camera.Position.Y + speed, Camera.Position.Z);
			Camera.Target = new Vector3(Camera.Target.X, Camera.Target.Y + speed, Camera.Target.Z);
		}
		if (Raylib.IsKeyDown(KeyboardKey.LeftShift)) {
			Camera.Position = new Vector3(Camera.Position.X, Camera.Position.Y - speed, Camera.Position.Z);
			Camera.Target = new Vector3(Camera.Target.X, Camera.Target.Y - speed, Camera.Target.Z);
		}

		Raylib.SetMousePosition(Raylib.GetScreenWidth()/2, Raylib.GetScreenHeight()/2);

		Ray ray = Raylib.GetMouseRay(Raylib.GetMousePosition(), Camera);
		
		Vector3 RayPos = ray.Position;
		Vector3 RayDir = Vector3.Normalize(ray.Direction);
		float traveled = 0.0f;
		bool hit = false;
		int hitX = 0, hitY = 0, hitZ = 0;
		int placeX = -1, placeY = -1, placeZ = -1;
		int lastX = -999, lastY = -999, lastZ = -999;

		while (traveled < reach) {
			int x = (int)MathF.Floor(RayPos.X);
			int y = (int)MathF.Floor(RayPos.Y);
			int z = (int)MathF.Floor(RayPos.Z);

			if (x != lastX || y != lastY || z != lastZ) {
				if (x >= 0 && x < 128 && y >= 0 && y < 128 && z >= 0 && z < 128) {
					if (OptimFuncs.WorldData[x, y, z] != 69) {
						hit = true;
						hitX = x; hitY = y; hitZ = z;
						placeX = lastX; placeY = lastY; placeZ = lastZ;
						break;
					}
				} else {
					break;
			}
				lastX = x; lastY = y; lastZ = z;	
			}
			RayPos += RayDir * raystep;
			traveled += raystep;
		}

		if (hit) {
			Actions.scan_actions(hitX, hitY, hitZ, placeX, placeY, placeZ);
		}

		//Camera.Position = new Vector3(posx, posy, posz);
		//Camera.Target = new Vector3(targetx, targety, targetz);
	}
}
