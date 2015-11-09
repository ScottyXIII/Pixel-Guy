using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class MapData 
{	
	protected int width, height; 

	public int[,] mapData; 
	public bool[,] createOwnObject;
	public string[] layerTags;
	
	public List<int[,]> layers = new List<int[,]>(); 
	public Dictionary<string, string> layerProperties = new Dictionary<string, string>(); 
	
	public int layerCount {
		get ;
		private set; 
	}
	
	public IMapDataGenerator mapGenerator{get; set;} 
	
	public MapData(int sizeX, int sizeY) 
	{
		ClearMapData (sizeX, sizeY); 
	}
	
	public void ClearMapData(int sizeX, int sizeY) 
	{
		width = sizeX; 
		height = sizeY;

		mapData = new int[sizeX,sizeY];
		createOwnObject = new bool[sizeX, sizeY];

		for (int y = 0; y < height; y++) {
			for (int x = 0; x < width; x++) {
				mapData[x,y] = 0;
				createOwnObject[x,y] = false;
			}
		}
	}

	public void GenerateMapData()
	{	
		mapData = mapGenerator.GenerateMapData(); 
	}

	public void GenerateMapData(int sizeX, int sizeY)
	{
		ClearMapData (sizeX, sizeY); 
	
		GenerateMapData(); 
	}

	public void AddLayer(int[,] newMapData) 
	{
		layers.Add (newMapData);
		layerCount++;
	}

	public void AddLayers(List<int[,]> layers) 
	{
		this.layers = layers;
		layerCount = layers.Count; 
	}

	public string GetLayerTag(int layer) 
	{
		if (layerTags[layer] != null) {
			return layerTags[layer];
		} 

		return "Untagged";
	}
	 
}
