using UnityEngine;
using UnityEditor;
using System.Collections.Generic;


public class MiToolPrueba : EditorWindow 
{
    string TrackName = "Track";
    Vector2 scrollPos;

    Vector3 SpawnPosition = new Vector3(0,0,0);

    [MenuItem("Tools/Track Level Generator Tool/Mi Tool De Pruebas")]
	private static void showEditor()
	{
		EditorWindow.GetWindow<MiToolPrueba>(false,"Mi Tool De Pruebas");
	} 


    void OnGUI()
	{	
		EditorGUILayout.BeginVertical();
		scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
		GUILayout.Label("Track Name", EditorStyles.boldLabel);

        EditorGUI.BeginChangeCheck();
		TrackName = EditorGUILayout.TextField(TrackName);
		EditorGUILayout.Separator();

        GUILayout.Label("Main Containers", EditorStyles.boldLabel);
		
		if(GUILayout.Button("Generate Cube")){
			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube.transform.position = SpawnPosition;
			cube.name = TrackName;
            SpawnPosition.x += 1f;
		}

        EditorGUILayout.EndScrollView();
		EditorGUILayout.EndVertical();
		
    }
}