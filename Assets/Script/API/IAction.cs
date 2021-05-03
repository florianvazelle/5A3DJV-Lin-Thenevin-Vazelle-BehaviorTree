using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script;

public class IAction
{
    public virtual bool verify(IAgent);
    public virtual void update(IAgent);

}
