using System.Collections;
using System.Collections.Generic;
using System.Numerics;

public struct VirtualOutput
{
    private List<float> levels;

    public VirtualOutput(int length)
    {
        levels = new List<float>();
        for (int i = 0; i < length; i++)
        {
            levels.Add(VirtualLevel.LOW);
        }
    }

    public float get(int inputNumber) { return levels[inputNumber]; }
    public int count() { return levels.Count; }
}
