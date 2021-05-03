using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sequence = System.Collections.Generic.List<IAction>;

class Selector
{
    public Sequence sequence;

    public Selector()
    {
        sequence = new Sequence();
    }

    public void AddAction(IAction action)
    {
        sequence.Add(action);
    }
}
