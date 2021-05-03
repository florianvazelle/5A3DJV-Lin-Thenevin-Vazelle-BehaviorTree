using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ForceState<S, T> 
    where T : INode, new()
{
    public T instance;
    public State returnState;

    public ForceState(State returnState)
    {
        this.returnState = returnState;
        this.instance = new T();
    }

    State act()
    {
        instance.act();
        return returnState;
    }
}

