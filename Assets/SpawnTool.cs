using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnTool : MonoBehaviour, Tool
{
    private GameObject prefab;
    private Editor m_Editor;
    private CircuitPrefabDAO dao;
    private bool Enabled { get; set; }
    private void Start()
    {
        dao = new CircuitPrefabDAO(StaticConfig.circuitPrefabsPath);
        m_Editor = FindFirstObjectByType<Editor>();
    }

    public void Activate()
    {
        Enabled = true;
    }

    public void Deactivate()
    {
        Enabled = false;
    }

    public void Update()
    {
        if (!Enabled)
            return;
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (prefab)
            {
                Instantiate(prefab, m_Editor.LoadedContainer.transform);
            }
        }
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D info = Physics2D.Raycast(r.origin, r.direction, 1000);
            if (info.collider) {
                Destroy(info.collider.gameObject);
            }
        }
    }

    public void SetSpawnablePrefab(GameObject prefab) {
        this.prefab = prefab;
    }
}
