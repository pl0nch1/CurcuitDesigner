using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CircuitDescription
{
    [SerializeField]
    private VirtualNode info;
    [SerializeField]
    private List<VirtualNode> virtualNodes;
    [SerializeField]
    private List<VirtualConnection> virtualConnections;
    [SerializeField]
    private List<string> inputNodeAddresses;
    [SerializeField]
    private List<string> outputNodeAddresses;

    public VirtualNode Info => info;
    public List<VirtualNode> Nodes => virtualNodes;
    public List<VirtualConnection> Connections => virtualConnections;
    public List<string> InputNodes => inputNodeAddresses;
    public List<string> OutputNodes => outputNodeAddresses;

    public CircuitDescription(
        VirtualNode info,
        List<VirtualNode> internalNodes,
        List<VirtualConnection> internalConnections,
        List<string> inputAddresses,
        List<string> outputAddresses) {
        this.info = info;
        this.virtualNodes = internalNodes;
        this.virtualConnections = internalConnections;
        this.inputNodeAddresses = inputAddresses;
        this.outputNodeAddresses = outputAddresses;
    }
}
