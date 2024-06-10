using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterSocket : MonoBehaviour, Socket
{
    private SocketConnection connection;
    public void Connect(SocketConnection connection)
    {
        this.connection = connection;
        Debug.Log("Connected to emitter socket");
    }

    public void Disconnect()
    {
        Debug.Log("Disconnected from emitter socket");
    }
}
