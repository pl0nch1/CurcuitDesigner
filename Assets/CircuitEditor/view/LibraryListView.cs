using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LibraryListView : MonoBehaviour
{
    [SerializeField]
    private GridLayoutGroup grid;
    [SerializeField]
    private LibraryViewItem itemPrefab;

    private CircuitPrefabDAO dao;
    
    private void Start()
    {
        dao = new CircuitPrefabDAO(StaticConfig.circuitPrefabsPath);
        UpdateList();
    }

    public void UpdateList() {
        List<string> libraryItems = dao.ListContainers();
        for (int i = 0; i < grid.transform.childCount; i++)
        {
            Destroy(grid.transform.GetChild(i).gameObject);
        }
        foreach (string foundItem in libraryItems)
        {
            LibraryViewItem item = Instantiate(itemPrefab, grid.transform);
            CircuitShell shell = dao.LoadShell(foundItem);
            item.SetInfo(shell.gameObject, shell.Info);
        }
    }
}
