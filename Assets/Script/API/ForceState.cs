using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ForceState<S, T> 
    where S : State
    where T : INode
{
    public T instance;

    public ForceState()
    {
        instance = new T();
    }

    bool act(IAgent agent)
    {
        instance.act(agent);
        return S;
    }
}

