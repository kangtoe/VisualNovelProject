using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SaveDataViewer))]
public class SaveDataViewerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SaveDataViewer viewer = (SaveDataViewer)target;

        if (GUILayout.Button("Get Save"))
        {
            viewer.GetSave();
        }

        if (GUILayout.Button("Set Save"))
        {
            viewer.SetSave();
        }

        if (GUILayout.Button("Clear Save"))
        {
            viewer.ClearSave();
            viewer.GetSave();
        }
    }
}
