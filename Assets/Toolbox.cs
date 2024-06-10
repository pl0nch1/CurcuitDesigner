using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Toolbox : MonoBehaviour
{
    [SerializeField]
    private Toggle moveToggle;
    [SerializeField]
    private Toggle spawnToggle;

    public void ForcePickSpawner() {
        spawnToggle.Select();
    }

    public void ForcePickMover()
    {
        moveToggle.Select();
    }
}
