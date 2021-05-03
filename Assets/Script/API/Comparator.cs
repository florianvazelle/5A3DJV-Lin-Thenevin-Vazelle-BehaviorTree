using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Comparator : INode
{
    public List<INode> nodes;

    public Comparator()
    {
        nodes = new List<INode>();
    }

    public void AddAction(INode node)
    {
        nodes.Add(node);
    }

    public virtual State act()
    {
        throw new NotImplementedException();   
    }
}
