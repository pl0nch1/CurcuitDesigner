using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEditor;
using UnityEngine;

public class Playground: MonoBehaviour
{
}


[CustomEditor(typeof(Playground))]
public class PlaygroundEditor : UnityEditor.Editor
{
    CircuitContainer circuitContainerToSave;
    private void run()
    {
        CircuitPrefabDAO dao = new CircuitPrefabDAO(StaticConfig.circuitPrefabsPath);
        dao.SaveContainer(circuitContainerToSave);
        // 
        /* GameObject.Instantiate(dao.load("49f822ac-8744-4489-b5fa-fc301149910d"));
        foreach (string prefab in dao.list())
        {
            Debug.Log(prefab);
        }*/
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Run"))
            run();
        circuitContainerToSave = (CircuitContainer)EditorGUILayout.ObjectField(circuitContainerToSave, typeof(CircuitContainer));
    }
}
