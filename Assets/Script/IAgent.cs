using System;
using UnityEngine;

public interface IAgent
{
    void moveTo(Vector3 target);
    bool Dectection();
    void Fire();
}
