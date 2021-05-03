using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ActionFire : IAction
{
    public bool verify(IAgent agent)
    {
        return agent.Dectection();
    }

    public void update(IAgent agent)
    {
        if (agent.Dectection())
        {
            agent.Fire();
        }
    }

}
