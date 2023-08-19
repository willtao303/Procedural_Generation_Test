using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapGenerator))]

public class MapGeneratorEditor : Editor
{
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        var script = (MapGenerator) target;

        if (GUILayout.Button("Generate New Map")){
            script.generateNewMap();
        }
    }
}
