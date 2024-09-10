using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR

    [CustomEditor(typeof(GameGridScript))]
    [CanEditMultipleObjects]

public class GridMakerInspector : Editor
{

    SerializedProperty cellPrefab;
    SerializedProperty gridPrefab;
    SerializedProperty width;
    SerializedProperty height;
    SerializedProperty cellSize;
    SerializedProperty originPosition;


    private void OnEnable()
    {

        cellPrefab = serializedObject.FindProperty("cellPrefab");
        gridPrefab = serializedObject.FindProperty("gridPrefab");
        width = serializedObject.FindProperty("width");
        height = serializedObject.FindProperty("height");
        cellSize = serializedObject.FindProperty("cellSize");
        originPosition = serializedObject.FindProperty("originPosition");

    }

    public override void OnInspectorGUI()
    {
        GUILayout.Label("The Grid Maker");
        GUILayout.Label("");

        serializedObject.Update();

        GUILayout.Label("PREFABS");
        EditorGUILayout.PropertyField(cellPrefab);
        EditorGUILayout.PropertyField(gridPrefab);

        GUILayout.Label("");
        GUILayout.Label("SETTINGS");
        EditorGUILayout.PropertyField(width);
        EditorGUILayout.PropertyField(height);
        EditorGUILayout.PropertyField(cellSize);
        EditorGUILayout.PropertyField(originPosition);

        GUILayout.Label("");



        serializedObject.ApplyModifiedProperties();


        GUILayout.Label("");
        GUILayout.Label("");
        GUILayout.Label("");


        GameGridScript gameGrid = (GameGridScript)target;

        if (GUILayout.Button("Create Grid"))
        {
            gameGrid.CreateCells();
        }


    }


}

#endif
