using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(StartServerProcessAndScan))]
public class StartServerProcessAndScanEditor : Editor
{
    private StartServerProcessAndScan Target { get; set; }

    private void OnEnable()
    {
        Target = (StartServerProcessAndScan) target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (Application.isPlaying) {
            EditorGUILayout.Space();
            GUILayout.Label("Connected Devices", EditorStyles.boldLabel);
            Target.Devices.ForEach(d => GUILayout.Label(d.Name));
        }
    }
}