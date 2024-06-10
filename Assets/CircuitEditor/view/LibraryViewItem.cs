using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LibraryViewItem : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI circuitTitle;

    private SpawnTool spawnTool;
    private GameObject prefab;
    private void Start() {
        spawnTool = FindFirstObjectByType<SpawnTool>();
    }

    public void SetInfo(GameObject prefab, VirtualNode info) {
        circuitTitle.text = info.circuitName;
        this.prefab = prefab;
    }

    public void HandleClick() {
        spawnTool.SetSpawnablePrefab(prefab);
    }
}
