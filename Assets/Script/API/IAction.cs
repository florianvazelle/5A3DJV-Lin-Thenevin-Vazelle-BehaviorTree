using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script;

public interface IAction
{
    virtual bool verify(IAgent agent);
    virtual void update(IAgent agent);

}
