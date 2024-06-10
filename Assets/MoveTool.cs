using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveTool : MonoBehaviour, Tool
{
    [SerializeField]
    private Grabber grabber;
    [SerializeField]
    private CameraMover mover;
    private bool active = false;
    public void Update()
    {
        if (!active)
            return;

        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(r.origin, r.direction);

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            RaycastHit2D info = Physics2D.Raycast(r.origin, r.direction, 1000);
            if (info.collider) {
                grabber.Grab(info);
            }
            else {
                mover.Enabled = true;
            }
        }

        grabber.Move(Input.mousePosition);
        mover.Move(Input.mousePositionDelta);

        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            grabber.Release();
            mover.Enabled = false;
        }

        mover.Scale(Mouse.current.scroll.value.y);
    }

    public void Deactivate() {
        active = false;
        mover.Enabled = false;
        grabber.Release();
    }

    public void Activate() {
        active = true;
    }
}
