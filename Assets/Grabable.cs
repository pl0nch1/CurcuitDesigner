using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Grabable
{
    public void Grab();
    public void Move(Vector3 mousePosition);
    public void Release();
}
