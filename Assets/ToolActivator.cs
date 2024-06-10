using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolActivator : MonoBehaviour
{
    [SerializeField]
    private MonoBehaviour toolScript;
    private Tool tool;

    public void Start()
    {
        tool = (Tool) toolScript;
        Toggle(GetComponent<Toggle>().isOn);
        Debug.Log(gameObject.ToString() + GetComponent<Toggle>().isOn);
    }

    public void Toggle(bool activated) {
        if (activated)
            tool.Activate();
        else
            tool.Deactivate();
    }
}
