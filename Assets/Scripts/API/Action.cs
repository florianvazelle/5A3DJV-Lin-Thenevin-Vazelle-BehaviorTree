using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// INode d'action, permet de joué une action attaché lors de la construction de l'objet
/// </summary>
public class Action : INode
{
    private Func<State> action;

    public Action()
    {
        this.action = null;
    }

    public Action(Func<State> func)
    {
        this.action = func;
    }

    public State act()
    {
        if (action == null) {
            throw new NotImplementedException();
        }
        return action();
    }
}
