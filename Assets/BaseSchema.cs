using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public abstract class BaseSchema : MonoBehaviour
{
    private Dictionary<PinName, ISignalAcceptor> inputs;
    private Dictionary<PinName, ISignalEmitter> outputs;

    public abstract void ready();
}
