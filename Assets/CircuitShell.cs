using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CircuitShell : MonoBehaviour, Addresable, Identifiable, Grabable
{
    [SerializeField]
    private VirtualNode info;
    [SerializeField]
    private TextMeshProUGUI textMeshPro;
    public string Address => info.localAddress;
    public string Uid => info.uid;
    public string Name => info.circuitName;
    public VirtualNode Info => info;

    void OnValidate()
    {
        if (info == null)
            info = new VirtualNode();
        if ((Address == null) || (Address == ""))
        {
            info.localAddress = Guid.NewGuid().ToString();
            Debug.Log($"Generated new Local Address for {Name}: {Address}");
        }
        if (Uid == null)
        {
            info.uid = Guid.NewGuid().ToString();
            Debug.Log($"Generated new GUID for {Name}: {Uid}");
        }
        if ((Name != null) && (textMeshPro != null)) {  
            textMeshPro.SetText(Name);
        }
    }

    public void Move(Vector3 mousePosition)
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(mousePosition);
        position.z = transform.position.z;
        transform.position = position;
    }

    public void Grab(){ }
    public void Release(){ }
}
