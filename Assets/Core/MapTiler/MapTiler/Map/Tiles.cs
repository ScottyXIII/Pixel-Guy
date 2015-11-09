using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Tiles {

	public Material[] tileSheetMatrial;
	public int numTiles = 0;
	public List<Vector2> textureUVs = new List<Vector2>();
	
	public int numTilesX, numTilesY; 

	public void AddTileUV(Vector2 newUV)
	{
		//textureUVs.Add(newUV); 
	}

	public Vector2[] GetTileUV(int tileIndex) 
	{
		Vector2[] uvs = new Vector2[4]; 
		int count = 0; 
		for (int x = tileIndex * 4; x <(tileIndex *4 + 4); x++) {

			uvs[count] = textureUVs[x];
			count++;
		}

		return uvs; 
	}

	public void GetUvValuesFromMaterial() 
	{
		float width = tileSheetMatrial[0].mainTexture.width;
		float height = tileSheetMatrial[0].mainTexture.height;

		float tileWidth = width / numTilesX; 
		float tileHeight = height / numTilesY; 

		float tUnitX = (float)1/numTilesX; 
		float tUnitY = (float)1/numTilesY;

		for (int y = numTilesY; y > 0; y--) {
			for (int x = 0; x < numTilesX; x++) {

				textureUVs.Add(new Vector2(tUnitX * x, tUnitY * y)); 
				textureUVs.Add(new Vector2(tUnitX * x + tUnitX, tUnitY * y)); 
				textureUVs.Add(new Vector2(tUnitX * x + tUnitX, tUnitY * y - tUnitY)); 
				textureUVs.Add(new Vector2(tUnitX * x, tUnitY * y - tUnitY));

				numTiles++; 
			}
		}

	}
}
