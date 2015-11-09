using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TiledMapEditorImporter : IMapEditorImporter 
{	
	public IMapDataImporter importer{get; set;}

	public TiledMapEditorImporter () 
	{
		importer = new JsonTiledMapImporter(); 
	}
	
	public List<int[,]> ImportMapData(string filePath)
	{
		return importer.ImportMap (filePath); 
	}
	
	public void ImportMapData(string filePath, IMapDataImporter imoprter)
	{
		this.importer = importer; 
		ImportMapData (filePath); 	
	}

	public bool[,] GetNewObjectTiles()
	{
		return importer.GetNewObjectTiles();
	}

	
	public int GetOwnObjectLayerIndex()
	{
		return importer.GetOwnObjectLayerIndex();
	}

	public string[] GetLayerTags() 
	{
		return importer.GetLayerTags (); 
	}

}
