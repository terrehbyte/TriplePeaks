using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(LevelSystem))]
public class LevelSystemEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LevelSystem lvlSystem = (LevelSystem)target;

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Prev Level"))
        {
            lvlSystem.LoadPrevLevel();
        }

        if (GUILayout.Button("Next Level"))
        {
            lvlSystem.LoadNextLevel();
        }

        GUILayout.EndHorizontal();
    }
}
