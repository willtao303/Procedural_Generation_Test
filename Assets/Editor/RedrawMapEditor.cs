using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapRenderer))]

public class RedrawMapEditor : Editor
{
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        var script = (MapRenderer) target;

        if (GUILayout.Button("Redraw Map")){
            script.Redraw();
        }
    }
}