using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class CircuitPrefabDAO
{
    private string containersPath;
    private string shellsPath;
    private string descriptionsPath;
    private string elementaryPath;
    public CircuitPrefabDAO(string storagePath) {
        containersPath = Path.Join(storagePath, "/containers");
        shellsPath = Path.Join(storagePath, "/shells");
        descriptionsPath = Path.Join(storagePath, "/descriptions");
        elementaryPath = Path.Join(storagePath, "/elementary");
    }

    private string resourcePath(string basePath, string resourceId) { 
        return Path.Join(basePath, resourceId + ".prefab"); 
    }

    private string extractUid(string path) {
        return Path.GetFileNameWithoutExtension(path);    
    }

    private List<string> listPrefabsFromPath(string path) {
        List<string> prefabs = AssetDatabase.FindAssets("", new string[] { path }).ToList().Select(
            guid => extractUid(AssetDatabase.GUIDToAssetPath(guid))).ToList();
        return prefabs;
    }

    private void savePrefab(GameObject go, string basePath, string uid, string name, string entity) {
        if (uid == "") {
            throw new RuntimeWrappedException($"UID of {name} {entity} is empty; Not saving");
        }

        if (!Directory.Exists(basePath))
            Directory.CreateDirectory(basePath);
        string localPath = resourcePath(basePath, uid);
        PrefabUtility.SaveAsPrefabAssetAndConnect(go, localPath, InteractionMode.UserAction);
    }

    public List<string> ListContainers() {
        return listPrefabsFromPath(containersPath);
    }

    public List<string> ListElementary()
    {
        return listPrefabsFromPath(elementaryPath);
    }

    public List<string> ListShells()
    {
        return listPrefabsFromPath(shellsPath);
    }

    public void SaveContainer(CircuitContainer container) {
        Debug.Log(container);
        savePrefab(container.gameObject, containersPath, container.Uid, container.Name, "container");
    }

    public void SaveShell(CircuitShell shell)
    {
        savePrefab(shell.gameObject, containersPath, shell.Uid, shell.Name, "shell");
    }
    
    public GameObject LoadElementary(string uid)
    {
        return (GameObject)AssetDatabase.LoadAssetAtPath(resourcePath(elementaryPath, uid), typeof(GameObject));
    }

    public CircuitContainer LoadContainer(string uid) {
        return (CircuitContainer) AssetDatabase.LoadAssetAtPath(resourcePath(containersPath, uid), typeof(CircuitContainer));
    }

    public CircuitShell LoadShell(string uid)
    {
        Debug.Log(uid);
        return (CircuitShell) AssetDatabase.LoadAssetAtPath(resourcePath(shellsPath, uid), typeof(CircuitShell));
    }

    public void SaveDescription(CircuitDescription description)
    {
        string json = JsonUtility.ToJson(description);
        File.WriteAllText(resourcePath(descriptionsPath, description.Info.uid), json);
    }

    public CircuitDescription LoadDescription(string uid)
    {
        string json = File.ReadAllText(resourcePath(descriptionsPath, uid));
        return JsonUtility.FromJson<CircuitDescription>(json);
    }
}
