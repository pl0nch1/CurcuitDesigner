using System.Net.Sockets;
using UnityEngine;

public class WireConnector : MonoBehaviour, Grabable
{
    private Socket attachedSocket;
    [SerializeField]
    private Transform originalParent;

    public void Move(Vector3 mousePosition)
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(mousePosition);
        position.z = transform.position.z;
    
        Ray r = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit2D info = Physics2D.Raycast(r.origin, r.direction, 1000, LayerMask.GetMask("Collider"));

        if (info.collider) {
            attachedSocket = info.collider.GetComponent<Socket>();
            transform.position = info.collider.transform.position;
        }
        else
        {
            attachedSocket = null;
            transform.position = position;
        }
    }

    public void Grab() {
        if (attachedSocket != null) {
            attachedSocket.Disconnect();
            transform.parent = originalParent;
        }
    }
    public void Release() {
        if (attachedSocket != null)
        {
            transform.parent = ((MonoBehaviour) attachedSocket).transform;
            attachedSocket.Connect(new SocketConnection());
        };
    }

    public void Update()
    {

    }
}
