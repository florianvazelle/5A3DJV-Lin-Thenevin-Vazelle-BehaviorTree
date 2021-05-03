using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Comparator : INode
{

    public List<INode> nodes;
    public void AddAction(INode node)
    {
        nodes.Add(node);
    }

    public bool act(IAgent agent) { return false; }
}
