using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TiledMapMeshGenerator : SquareMeshGenerator {

	public int tileSizeX, tileSizeY; 
	public int numTilesX, numTilesY; 
	
	public bool addBlankTiles = false; 

	public TiledMapMeshGenerator() : base () 
	{	
		AutoBuildMesh = false;  
	}

	public void CreateTiledMap(int[,] mapArray, Tiles tiles) 
	{
		for (int y = 0; y < numTilesY; y++) {
			for (int x = 0; x < numTilesX; x++) {
				
				if (mapArray[x,y] != 0 || addBlankTiles) {
					CreateSquare(x, y, tiles.GetTileUV(mapArray[x,y])); 
				}
			}
		}
		BuildMesh (); 
	}

	public void CreateTiledMap(int[,] mapArray, Tiles tiles,  bool[,] ownObjs) 
	{
		for (int y = 0; y < numTilesY; y++) {
			for (int x = 0; x < numTilesX; x++) {

				if (mapArray[x,y] != 0 || addBlankTiles) {
					if (!ownObjs[x,y]) {
						CreateSquare(x, y, tiles.GetTileUV(mapArray[x,y])); 
					}
				}
			}
		}

		BuildMesh (); 
	}

	public void CreateTiledMap(int numTilesX, int numTilesY, int[,] mapArray, Tiles tiles) 
	{
		this.numTilesX = numTilesX; 
		this.numTilesY = numTilesY; 

		CreateTiledMap (mapArray, tiles);  
	}
	public void CreateTiledMap(int numTilesX, int numTilesY, int[,] mapArray, Tiles tiles, bool[,] ownObjs) 
	{
		this.numTilesX = numTilesX; 
		this.numTilesY = numTilesY; 
		
		CreateTiledMap (mapArray, tiles, ownObjs);  
	}
	public void CreateTiledMap(int numTilesX, int numTilesY, int tileSizeX, int tileSizeY, int[,] mapArray, Tiles tiles) 
	{
		this.tileSizeX = tileSizeX;
		this.tileSizeY = tileSizeY; 

		CreateTiledMap (numTilesX, numTilesY, mapArray, tiles);  
	}
}
