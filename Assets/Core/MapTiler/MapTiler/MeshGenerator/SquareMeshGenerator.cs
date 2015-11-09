using UnityEngine;
using System.Collections;

public class SquareMeshGenerator : MeshGenerator 
{ 
	public int numSquares = 0; 


	public SquareMeshGenerator() : base()
	{
	
	}

	public void CreateSquare(int x, int y, Vector2[] textureUv) 
	{
		vertices.Add( new Vector3 (x  , y  , 0 ));
		vertices.Add( new Vector3 (x + 1f , y  , 0 ));
		vertices.Add( new Vector3 (x + 1f , y-1f , 0 ));
		vertices.Add( new Vector3 (x  , y-1f , 0 ));

		numVertices += 4; 

		triangles.Add((numSquares * 4) + 0);
		triangles.Add((numSquares * 4) + 1);
		triangles.Add((numSquares * 4) + 3);
		triangles.Add((numSquares * 4) + 1);
		triangles.Add((numSquares * 4) + 2);
		triangles.Add((numSquares * 4) + 3);

		colVertices.Add( new Vector3 (x  , y  , 0 ));
		colVertices.Add( new Vector3 (x + 1f , y  , 0 ));
		colVertices.Add( new Vector3 (x + 1f , y-1f , 0 ));
		colVertices.Add( new Vector3 (x  , y-1f , 0 ));

		colTriangles.Add((numSquares * 4) + 0);
		colTriangles.Add((numSquares * 4) + 1);
		colTriangles.Add((numSquares * 4) + 3);
		colTriangles.Add((numSquares * 4) + 1);
		colTriangles.Add((numSquares * 4) + 2);
		colTriangles.Add((numSquares * 4) + 3);

		AddUvMap (textureUv); 
	
		numSquares++; 
		 
		BuildMeshOnCreate ();  
	}
}
