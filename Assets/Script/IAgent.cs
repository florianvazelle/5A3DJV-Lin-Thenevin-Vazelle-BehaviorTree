using System;
using UnityEngine;

public interface IAgent
{
    State MoveToTarget();
    State Detection();
    State Fire();
    State Patrol();
}
