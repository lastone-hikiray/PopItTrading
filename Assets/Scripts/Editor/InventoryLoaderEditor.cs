using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InventoryLoader))]
public class InventoryLoaderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Reset"))
        {
            InventoryLoader loader = target as InventoryLoader;
            loader.Clear();
            loader.Apply();
        }

        base.OnInspectorGUI();
    }
}
