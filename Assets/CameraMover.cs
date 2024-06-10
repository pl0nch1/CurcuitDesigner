using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    private Camera m_Camera;
    private void Start()
    {
        m_Camera = GetComponent<Camera>();
    }
    public bool Enabled { get; set; }
    public void Scale(float scale) {
        m_Camera.orthographicSize *= (1 - scale / 5);
    }
    public void Move(Vector3 mouseDelta) {
        if (Enabled && mouseDelta.magnitude > 0) {
            transform.position -= (mouseDelta / Mathf.Sqrt(mouseDelta.magnitude)) * Time.deltaTime * m_Camera.orthographicSize;
        }
    }
}
