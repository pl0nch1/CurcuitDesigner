using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class CircuitExecutor
{
    // Every complex (non-elementary) circuit instance is under a service of executor it's own executor
    private Dictionary<string,CircuitExecutor> localAddressToExecutors = new Dictionary<string,CircuitExecutor>();
    private Dictionary<string,List<VirtualConnection>> localAddressToConnections = new Dictionary<string,List<VirtualConnection>>();
    private CircuitDescription circuitDescription;

    public VirtualInput Input { get; set; }
    public VirtualOutput Output{ get; }
    public VirtualNode CircuitInfo { get; }

    /// <summary>
    /// Executor loads circuit graph from description dictionary by provided uid and pass dictionary to inner executors
    /// </summary>
    /// <param name="descriptionsByUid"></param>
    /// <param name="uid"></param>
    public CircuitExecutor(Dictionary<string,CircuitDescription> descriptionsByUid, string uid) {
        if (!descriptionsByUid.TryGetValue(uid, out circuitDescription)) {
            throw new Exception($"Failed to find ciruit description for {uid}");
        }

        foreach (VirtualNode node in circuitDescription.Nodes) {
            localAddressToExecutors.Add(node.localAddress, new CircuitExecutor(descriptionsByUid, node.uid));
            localAddressToConnections.Add(node.localAddress, new List<VirtualConnection>());
        }
        foreach (VirtualConnection connection in circuitDescription.Connections){
            localAddressToConnections[connection.localAddressFrom].Add(connection);
        }
        Input = new VirtualInput(circuitDescription.InputNodes.Count);
        Output = new VirtualOutput(circuitDescription.OutputNodes.Count);
    }

    private void runGraph() {
        HashSet<CircuitExecutor> fullReadyQueue = new HashSet<CircuitExecutor>();
        HashSet<CircuitExecutor> semiReadyQueue = new HashSet<CircuitExecutor>();

        foreach (string nodeUid in circuitDescription.InputNodes) {
            fullReadyQueue.Add(localAddressToExecutors[nodeUid]);
        }

        while (true) {
            // Hope that loaded description is valid and full or else...
            while (fullReadyQueue.Count > 0) {
                CircuitExecutor ready = fullReadyQueue.GetEnumerator().Current;
                fullReadyQueue.Remove(ready);
                ready.Tick();
                for (int i = 0; i < ready.Output.count(); i++) {
                    VirtualConnection connection = localAddressToConnections[ready.CircuitInfo.localAddress][i];
                    CircuitExecutor target = localAddressToExecutors[connection.localAddressTo];
                    target.Input.set(connection.portTo, ready.Output.get(i));
                    semiReadyQueue.Add(target);
                }
            }
            foreach (CircuitExecutor executor in semiReadyQueue) {
                if (executor.Input.isFullyUpdated) {
                    fullReadyQueue.Add(executor);
                }
                semiReadyQueue.RemoveWhere((CircuitExecutor executor) => fullReadyQueue.Contains(executor));
            }
        }
    }

    /// <summary>
    /// Call this method to process input and update outputs
    /// </summary>
    public void Tick() {
        if (Input.wasModified) {
            runGraph();
            Input.resetUpdateState();
        }
    }
}
