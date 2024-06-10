using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiverSocket : MonoBehaviour, Socket
{
    public void Connect(SocketConnection connection)
    {
        Debug.Log("Receiver socket connected");
    }

    public void Disconnect()
    {
        Debug.Log("Receiver socket disconnected");
    }
}
