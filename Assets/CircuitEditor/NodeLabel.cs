using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NodeLabel : MonoBehaviour
{
    [SerializeField]
    private InputField text;

    public void Activate() {
        text.interactable = true;
    }

    public void Deactivate() {
        text.interactable = false;
    }

    public string Text { get { return text.text; } set { text.text = value; } }
}
