using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Sequence : Comparator
{
    bool act(IAgent agent)
    {
        foreach (var node in nodes)
        {
            if (!node.act(agent))
            {
                return State.FAILURE;
            }
        }
        return State.SUCCESS;
    }
}