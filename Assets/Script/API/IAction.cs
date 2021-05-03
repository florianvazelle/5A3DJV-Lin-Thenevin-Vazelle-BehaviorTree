using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAction
{
    bool verify(IAgent agent);
    void update(IAgent agent);
}