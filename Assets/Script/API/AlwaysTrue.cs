using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class AlwaysTrue : IAction
{
    public bool verify(IAgent agent)
    {
        return true;
    }

    public void update(IAgent agent)
    {
        
    }
}