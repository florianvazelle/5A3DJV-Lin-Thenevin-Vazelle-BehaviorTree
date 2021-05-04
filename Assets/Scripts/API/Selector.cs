using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// INode de comparaison OR, la comparaison est que lors de la première INode success, on arrète
/// </summary>
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
