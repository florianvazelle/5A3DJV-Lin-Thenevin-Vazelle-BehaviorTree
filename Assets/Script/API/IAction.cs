using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script;

public class IAction
{
    virtual bool verify(IAgent);
    virtual void update(IAgent);

}
