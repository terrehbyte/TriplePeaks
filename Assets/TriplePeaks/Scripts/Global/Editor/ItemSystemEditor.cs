using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(ItemSystem))]
public class ItemSystemEditor : Editor{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ItemSystem items = (ItemSystem)target;

        GUILayout.BeginHorizontal();


        GUILayout.EndHorizontal();
    }
}
