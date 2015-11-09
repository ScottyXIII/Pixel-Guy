using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(TiledMapGenerator))]
public class TiledMapGeneratorEditor : Editor
{	
	private string saveNameInput = Selection.activeGameObject.name;

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		
		TiledMapGenerator script = (TiledMapGenerator)target;
		if(GUILayout.Button("Save Mesh"))
		{
			script.SaveMesh(saveNameInput); 
		}

		saveNameInput = EditorGUILayout.TextField("Save Name: ", saveNameInput);

	}
}