using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BehaviorTree
{
    static void act(in List<Selector> selectors, ref IAgent agent)
    {
        foreach(Selector selec in selectors)
        {
            bool res = true;
            foreach(IAction act in selec.sequence)
            {
                if (!act.verify(agent))
                {
                    res = false;
                    break;
                }
            }

            if (res)
            {
                foreach(IAction act in selec.sequence)
                {
                    act.update(agent);
                }
                break;
            }
        }
    }
}
