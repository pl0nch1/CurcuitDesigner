using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface ISignalAcceptor
{
    public void accept(SignalInfo info);
}
