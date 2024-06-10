using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Socket
{
    public void Connect(SocketConnection connection);
    public void Disconnect();
}
