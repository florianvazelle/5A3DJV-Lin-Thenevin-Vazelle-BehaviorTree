using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Sequence
{
    public List<IAction> actions;
    
    public void AddAction(IAction action) {
        actions.Add(action);
    }
}
