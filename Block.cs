using Raylib_cs;
using System.Numerics;

namespace tinycube;

public class Block {
	private Vector3 pos;
    	private static float size = 1.0f;
    	private int texture;

    	public bool visible;
	private const int NOTEXTURE = 69;

	private static Model cubemodel;
	private static Mesh mesh;


	public Block(Vector3 position, int texture = NOTEXTURE) {
		pos = position;
		this.texture = texture;
		visible = true;
	}

	public static void InitDefaultCubeModel() {
		mesh = Raylib.GenMeshCube(size, size, size);
                cubemodel = Raylib.LoadModelFromMesh(mesh);
	}

	public void Init() {
		pos += new Vector3(0.5f, 0.5f, 0.5f);
		if (texture != NOTEXTURE)
			Raylib.SetTextureFilter(Texture.map[texture], TextureFilter.Point);
	}

	public void Draw() {
		if (visible && texture != NOTEXTURE) {
			unsafe {
				cubemodel.Materials[0].Maps[(int)MaterialMapIndex.Diffuse].Texture = Texture.map[texture];
			}
			Raylib.DrawModel(cubemodel, pos, 1.0f, Color.White);
		}
	}

	public static void Unload() {
		// NOTE: LoadModelFromMesh copies the mesh and deletes the original VAO,
		// so only the model needs unloading (unloading mesh too = double free)
		Raylib.UnloadModel(cubemodel);
	}

	public BoundingBox GetBoundingBox() {
		float half = size / 2.0f;
		return new BoundingBox(pos - new Vector3(half, half, half),
					pos + new Vector3(half, half, half));
}
}
