using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(DeletePlayerPrefsScript))]
public class DeletePlayerPrefs : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DeletePlayerPrefsScript myScript = (DeletePlayerPrefsScript)target;
        if (GUILayout.Button("Delete Local Files"))
        {
            myScript.DeleteLocalFiles();
        }
    }
}