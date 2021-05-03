using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ForceState<state, T> where T : INode
{

    public T instance;

    public void FroceState()
    {
        //instance = new T ();
    }

    bool act(IAgent agent)
    {
        instance.act(agent);
        return false;
    }
}

