using System.Collections;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraBounds))]
public class CameraBoundsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CameraBounds cf = (CameraBounds)target;
        if (GUILayout.Button("Set Min Cam Pos"))
        {
            cf.SetMinCamPos();
        }
        if (GUILayout.Button("Set Max Cam Pos"))
        {
            cf.SetMaxCamPos();
        }
    }
}
