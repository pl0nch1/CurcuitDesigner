
using System;
using System.Collections.Generic;

public class VirtualInput
{
    private List<float> levels;

    public VirtualInput(int length) { 
        levels = new List<float>();
        for (int i = 0; i < length; i++) {
            levels.Add(VirtualLevel.LOW);
        }
    }

    private HashSet<int> updatedLevels = new HashSet<int>();

    /// <summary>
    /// Returns has any level been changed since last state reset
    /// </summary>
    public bool wasModified { get; private set; }
    /// <summary>
    /// Returns have all levels been updated
    /// </summary>
    public bool isFullyUpdated { get { return updatedLevels.Count == levels.Count; } }
    public float get(int inputNumber) {  return levels[inputNumber]; }
    public void set(int inputNumber, float value) {
        updatedLevels.Add(inputNumber);
        if (levels[inputNumber] != value) {
            wasModified = true;
            levels[inputNumber] = value;
        }
    }
    public void resetUpdateState() { 
        updatedLevels.Clear();
        wasModified = false;
    }
}
