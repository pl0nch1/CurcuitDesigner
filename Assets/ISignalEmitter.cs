using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.Events;

public interface ISignalEmitter
{
    public void unlink(ISignalAcceptor signalAcceptor);
    public void link(ISignalAcceptor signalAcceptor);
    public void emit(SignalInfo signal);
}
