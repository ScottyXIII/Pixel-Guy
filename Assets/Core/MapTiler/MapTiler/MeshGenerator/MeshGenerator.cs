using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeshGenerator {
	
	public bool AutoBuildMesh = true; 
	public bool BuildMeshColision = false; 
	public bool BuildNewObject = false; 

	public GameObject obj; 
	// Mesh 
	public List<Vector3> vertices = new List<Vector3>();
	public List<int> triangles = new List<int>();
	public List<Vector2> uv = new List<Vector2>();

	public Mesh mesh;
	public int numVertices = 0;

	// Mesh Collider
	public List<Vector3> colVertices = new List<Vector3>();
	public List<int> colTriangles = new List<int>();
	public List<Vector2> colUv = new List<Vector2>();

	public MeshCollider colMesh;
	public int numColVertices = 0;

	public MeshGenerator() 
	{
	 
	}

	public void SetMeshColider(MeshCollider meshCol) 
	{
		colMesh = meshCol; 
	}

	public bool AttachToObject(GameObject obj) 
	{	
		this.obj = obj; 
		MeshCollider meshCol = obj.GetComponent<MeshCollider> (); 

		Mesh mesh = obj.GetComponent<MeshFilter> ().mesh; 

		if (BuildMeshColision && meshCol == null) {
			Debug.Log ("Error, there is no Mesh collider attached to obj = " + obj + ". There will be no Mes collidier. MeshGenerator line 40.");
		} else {
			this.colMesh = meshCol; 
		}

		if (mesh == null) {
			Debug.Log ("Error, there is no Mesh attached to obj " + obj + "MeshGenerator line 49");
		} else {
			this.mesh = mesh; 
		}


		return false; 
	}

	public Mesh BuildMesh () {

		mesh.Clear ();
		mesh.vertices = vertices.ToArray();
		mesh.triangles = triangles.ToArray();
		mesh.uv = uv.ToArray();

		if (BuildMeshColision) {
			BuildMeshCollision ();	
			obj.GetComponent<MeshCollider> ().sharedMesh = obj.GetComponent<MeshFilter> ().sharedMesh; 
		}

		mesh.Optimize ();
		mesh.RecalculateNormals ();



		return mesh;
	}

	public Mesh BuildMesh (int subMesh) {
		
		mesh.Clear ();

		mesh.vertices = vertices.ToArray();
		mesh.SetTriangles(triangles.ToArray(), subMesh);
		mesh.uv = uv.ToArray();
	
		if (BuildMeshColision) {
			BuildMeshCollision ();	
		}
		
		mesh.Optimize ();
		mesh.RecalculateNormals ();
		
		return mesh;
	}

	public void AddUvMap(Vector2[] textureUv)
	{
		for (int x = 0; x < 4; x++) {
			uv.Add (textureUv [x]);
		}
	}

	public void BuildMeshCollision() 
	{
		Mesh mesh = new Mesh (); 
		mesh.vertices = colVertices.ToArray();
		mesh.triangles = colTriangles.ToArray();

		colMesh.sharedMesh = mesh; 

		colVertices.Clear();
		colTriangles.Clear(); 
	}

	protected void BuildMeshOnCreate()
	{
		if (AutoBuildMesh) {
			BuildMesh(); 
		}
	}
	protected void BuildMeshOnCreate(int subMesh)
	{
		if (AutoBuildMesh) {
			BuildMesh(subMesh); 
		}
	}


}
