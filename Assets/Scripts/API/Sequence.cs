using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Sequence : Comparator
{
    public Sequence() : base() {}

    public override State act()
    {
        foreach (var node in nodes)
        {
            if (node.act() == State.FAILURE)
            {
                return State.FAILURE;
            }
        }
        return State.SUCCESS;
    }
}