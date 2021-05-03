using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BehaviorTree
{
    public List<Selector> listSelec;
    void behaviorTree(IAgent ia)
    {
        foreach(Selector selec in listSelec)
        {
            bool res = true;
            foreach(IAction act in selec.sequence.actions)
            {
                if ((!act.verify(ia))){
                    res = false;
                    break;
                }
            }

            if (res)
            {
                foreach(IAction act in selec.sequence.actions)
                {
                    act.update(ia);
                }
                break;
            }

        }
    }



}
