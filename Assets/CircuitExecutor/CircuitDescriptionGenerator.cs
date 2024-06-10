using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CircuitDescriptionGenerator
{
    public static CircuitDescription FromCircuitContainer(CircuitContainer container) {
        List<VirtualNode> nodes;
        List<VirtualConnection> connections = new List<VirtualConnection>();
        List<string> inputs = new List<string>();
        List<string> outputs = new List<string>();

        CircuitShell[] shells = container.transform.GetComponentsInChildren<CircuitShell>();

        nodes = shells.Select((CircuitShell shell) => shell.Info).ToList();


        return new CircuitDescription(container.Info, nodes, connections, inputs, outputs);
    }
}
