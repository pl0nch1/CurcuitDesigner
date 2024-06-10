using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Editor : MonoBehaviour
{
    [SerializeField]
    private CircuitContainer loadedContainer;
    [SerializeField]
    private CircuitContainer emptyCircuitContainerPrefab;
    [SerializeField]
    private Text text;
    private CircuitPrefabDAO dao;

    public void Start()
    {
        dao = new CircuitPrefabDAO(StaticConfig.circuitPrefabsPath);
    }

    public CircuitContainer LoadedContainer => loadedContainer;

    private void Valdiate() { }

    public void Save()
    {
        loadedContainer.Info.circuitName = text.text;
        dao.SaveContainer(loadedContainer);
        FindObjectOfType<LibraryListView>().UpdateList();
        Debug.Log($"Saved {loadedContainer.Name} container");
    }

    private void CloseAndSave()
    {
        Valdiate();
        Save();
        Destroy(loadedContainer.gameObject);
        loadedContainer = null;
    }

    public void LoadContainer(string uid) {
        CloseAndSave();
        loadedContainer = Instantiate(dao.LoadContainer(uid));
        text.text = loadedContainer.Name;
    }

    public void CreateEmpty() {
        CloseAndSave();
        loadedContainer = Instantiate(emptyCircuitContainerPrefab);
        loadedContainer.RegenerateUid();
    }
}
