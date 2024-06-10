using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatefulSignalAcceptor : ISignalAcceptor
{
    public SignalInfo signalInfo { get; private set; }
    public void accept(SignalInfo info) {
        signalInfo = info;
    }
}
