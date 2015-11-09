using System.Collections;
using System.Collections.Generic;
/*
 * Interface used to create custom classes which imports map data from a tiled map editing software. 
 */

public interface IMapEditorImporter {

	List<int[,]> ImportMapData(string path);
	bool[,] GetNewObjectTiles(); 
 	int GetOwnObjectLayerIndex();
	string[] GetLayerTags();

}
