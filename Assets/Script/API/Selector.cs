using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Selector : Comparator
{
    public Selector() : base() { }

    public override State act()
    {
        foreach (var node in nodes)
        {
            if (node.act() == State.SUCCESS)
            {
                return State.SUCCESS;
            }
        }
        return State.FAILURE;
    }
}
