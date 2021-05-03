using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Action : INode
{
    private Func<State> action;

    public Action(Func<State> func)
    {
        this.action = func;
    }

    public State act()
    {
        return action();
    }
}
