using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// INode de comparaison AND, la comparaison est que lors de la première INode failure, on arrète
/// </summary>
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