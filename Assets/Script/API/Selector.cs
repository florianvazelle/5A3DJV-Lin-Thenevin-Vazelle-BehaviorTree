using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Selector : Comparator
{
    bool act(IAgent agent)
    {
        foreach (var node in nodes)
        {
            if (node.act(agent))
            {
                return State.SUCCESS;
            }
        }
        return State.FAILURE;
    }
}
