using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TiledMapGenerator : MonoBehaviour {

	public int numTilesX, numTilesY = 0;

	public string JsonFilePath = "";

	public bool generateBlankTiles = false;

	protected MapData mapData;
	public Material mat;

	[SerializeField]
	public Tiles tileSheet;
	
	public IMapEditorImporter mapImporter; 

	public IMapDataGenerator mapGenerator;

	public int numVertices = 0;
	public int layerCount = 0; 

	public void Start() 
	{	
	//	SetTileSheetMaterial ();

		mapData = new MapData (numTilesX, numTilesY); 

		if (JsonFilePath != "") {
			mapImporter = new TiledMapEditorImporter (); 
			mapData.AddLayers(mapImporter.ImportMapData(JsonFilePath));
			mapData.createOwnObject = mapImporter.GetNewObjectTiles(); 
			mapData.layerTags = mapImporter.GetLayerTags(); 
		} else {
			mapGenerator = new RandomMapDataGenerator(100, 100); 
			mapData.AddLayer(mapGenerator.GenerateMapData());
		}

		tileSheet.GetUvValuesFromMaterial(); 
		GenerateMap (); 
	}

	public void SetTileSheetMaterial()
	{	
		Material mat = GetComponent<MeshRenderer> ().material;

		if (mat == null) {
		 mat = gameObject.AddComponent<MeshRenderer>().material;	
		} 

		mat.mainTexture = tileSheet.tileSheetMatrial[0].mainTexture;	
	}

	public void GenerateMap()
	{
		layerCount = mapData.layerCount; 

		for (int layer = 0; layer < layerCount; layer++) {

			TiledMapMeshGenerator meshGen = new TiledMapMeshGenerator (); 

			GameObject obj = GameObjectBuilder.MeshObject("Layer"+(layer+1), mat, new Vector3(0, 0, -5f * layer) , this.gameObject.transform, mapData.GetLayerTag(layer)); 
			meshGen.AttachToObject(obj);

			if (layer == 0) {
				meshGen.addBlankTiles = this.generateBlankTiles;
			} else {
				meshGen.addBlankTiles = false;
			}

			meshGen.CreateTiledMap (numTilesX, numTilesY, mapData.layers[layer], tileSheet, mapData.createOwnObject); 

			if (layer == mapImporter.GetOwnObjectLayerIndex()) {
				CreateOwnObjectTiles(layer, obj); 
			}

			numVertices += meshGen.numVertices; 
		}

	}

	public void CreateOwnObjectTiles(int layer, GameObject parent)
	{
		for (int y = 0; y < numTilesY; y++) {
			for (int x = 0; x < numTilesX; x++) {

				if (mapData.createOwnObject[x,y]) {
					SquareMeshGenerator meshGen = new SquareMeshGenerator ();
					GameObject obj = GameObjectBuilder.MeshObject ("new", mat, new Vector3 (x, y, 0), parent.transform); 
					obj.AddComponent<MeshCollider>();
					meshGen.AttachToObject (obj); 
					meshGen.CreateSquare (0, 0, tileSheet.GetTileUV (mapData.layers[layer][x, y])); 
				}
			}
		}
	}

	public void SaveMesh(string name) 
	{	
		for (int layers = 0; layers < layerCount; layers++) {
			Mesh mesh = new Mesh(); 
			mesh = GameObject.Find("Layer"+(layers+1)).GetComponent<MeshFilter>().mesh; 
			UnityEditor.AssetDatabase.CreateAsset (mesh, "Assets/"+name+".asset");
		}
	}

}
