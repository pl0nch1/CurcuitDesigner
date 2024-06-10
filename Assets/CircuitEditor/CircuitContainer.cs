using System;
using UnityEngine;

public class CircuitContainer : MonoBehaviour, Identifiable
{
    [SerializeField]
    private VirtualNode info;

    public string Uid => info.uid;
    public string Name => info.circuitName;

    public VirtualNode Info => info;

    public void RegenerateUid() {
        info.uid = Guid.NewGuid().ToString();
        Debug.Log($"Regenerated new GUID for {Name}: {Uid}");
    }

    private void OnValidate()
    {
        if (Uid == null || Uid == "") {
            info.uid = Guid.NewGuid().ToString();
            Debug.Log($"Generated new GUID for {Name}: {Uid}");
        }
    }
}
