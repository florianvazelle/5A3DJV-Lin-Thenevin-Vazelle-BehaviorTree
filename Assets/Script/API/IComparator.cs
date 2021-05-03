using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class IComparator : INode
{

    public List<INode> nodes;
    public void AddAction(INode node)
    {
        nodes.Add(node);
    }
}
