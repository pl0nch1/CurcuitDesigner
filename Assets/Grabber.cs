using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class Grabber : MonoBehaviour
{
    private Grabable target;
    public void Grab(RaycastHit2D collision)
    {
        target = collision.collider.gameObject.GetComponent<Grabable>();
        if (target != null)
            target.Grab();
    }

    public void Release() {
        if (target != null) {
            target.Release();
            target = null;
        }
    }

    public void Move(Vector2 mousePosition) {
        if (target != null)
            target.Move(mousePosition);
    }
}
