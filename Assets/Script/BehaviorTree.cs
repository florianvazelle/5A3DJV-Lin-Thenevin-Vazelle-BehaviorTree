using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BehaviorTree
{
    static void act(in Selector selector, ref IAgent agent)
    {
        selector.act(agent);
    }
}
