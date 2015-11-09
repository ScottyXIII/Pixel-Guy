using System.Collections;
using System.Collections.Generic;

/*
 * Interface used to create custom classes which reads different data types from our chosen map editor. 
 */

public interface IMapDataImporter {

	List<int[,]> ImportMap(string path);

	bool[,] GetNewObjectTiles(); 
	string[] GetLayerTags(); 
	int GetOwnObjectLayerIndex();
	int[,] mapArray
	{
		get;
		set;
	}

}
