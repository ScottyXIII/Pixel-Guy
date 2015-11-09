using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

/*
 * Reads JSON data of a map from the Tiled Map editing software. 
 */

public class JsonTiledMapImporter : IMapDataImporter {
	
	public int[,] mapArray {
		get {
			return null;
		}
		set {
			//this.mapArray = value;
		}
	}

	public JsonTiledMapImporter() 
	{
		this.mapArray = new int[10, 10];
	}

	public bool[,] newObjects;
	public string[] layerTags; 
	public int ownObjectLayerIndex;
	public int index = 0; 
	public int indexY = 0; 

	private JSONNode data; 

	private JSONNode OpenFile(string path) 
	{
		path = Application.dataPath + "/" + path + ".json"; 

		try {

			string JsonData = System.IO.File.ReadAllText (path);
			JSONNode data = JSON.Parse (JsonData); 
			this.data = data;
			return data; 

		} catch {

			Debug.Log("No JSON file found at " + path +"." + this);
			return null; 

		}

	}

	private int [,] GetMapData(int layer) 
	{	
		int width = data ["layers"] [layer] ["width"].AsInt; 
		int height = data ["layers"] [layer] ["height"].AsInt; 
		newObjects = new bool[width, height]; 

		int [,] array = new int[width, height];

		for(int y = 0; y < height; y++) {
			for(int x = 0; x < width; x++) {
				
				// data as 1d array
				int t = x + (width * y);
				int tileIndex = data["layers"][layer][0][t].AsInt;
				
				// We're offsetting the tileIndex here as TiledMap Json data adds 1 to the array for some reason. 
				if (tileIndex != 0) {
					tileIndex--;
				}

				if (data ["layers"] [layer] ["name"].Value == "NewObjects" && tileIndex != 0) {
					ownObjectLayerIndex = layer; 
					newObjects[index,indexY] = true; 
				} 

				array[index,indexY] = tileIndex; 
				index++;
			}
			
			index = 0; 
			indexY++; 
		}

		Reverse2DimArray (newObjects);
		indexY = 0; 
		return array; 
	}

	private List<int [,]> GetLayers() 
	{	
		List<int [,]> list = new List<int [,]>();
		layerTags = new string[100]; 

		for (int layer = 0; layer < data ["layers"].Count; layer++) {
			int [,] array = GetMapData (layer);

			 
			if (data ["layers"] [layer] ["properties"]["Tag"].Value.Length > 0) {
				layerTags[layer] = data ["layers"] [layer] ["properties"]["Tag"];
			}
		
			Reverse2DimArray (array);
			list.Add(array); 
		}	

		return list; 
	}

	public bool[,] GetNewObjectTiles() 
	{
		return newObjects; 
	}

	public List<int[,]> ImportMap (string path) {

		OpenFile (path); 

		return GetLayers();
	}

	private static void Reverse2DimArray(int[,] theArray)
	{
		for (int rowIndex = 0; rowIndex <= (theArray.GetUpperBound(0)); rowIndex++) {
			for (int colIndex = 0; colIndex <= (theArray.GetUpperBound(1) / 2); colIndex++) {
				int tempHolder = theArray[rowIndex, colIndex];                        
				theArray[rowIndex, colIndex] = 
					theArray[rowIndex, theArray.GetUpperBound(1) - colIndex];   
				theArray[rowIndex, theArray.GetUpperBound(1) - colIndex] = 
					tempHolder;      
			}
		}
	}
	private static void Reverse2DimArray(bool[,] theArray)
	{
		for (int rowIndex = 0; rowIndex <= (theArray.GetUpperBound(0)); rowIndex++) {
			for (int colIndex = 0; colIndex <= (theArray.GetUpperBound(1) / 2); colIndex++) {
				bool tempHolder = theArray[rowIndex, colIndex];                        
				theArray[rowIndex, colIndex] = theArray[rowIndex, theArray.GetUpperBound(1) - colIndex];   
				theArray[rowIndex, theArray.GetUpperBound(1) - colIndex] = tempHolder;      
			}
		}
	}

	public int GetOwnObjectLayerIndex() 
	{
		return ownObjectLayerIndex; 
	}

	public string[] GetLayerTags() 
	{
		return this.layerTags;
	}
}
