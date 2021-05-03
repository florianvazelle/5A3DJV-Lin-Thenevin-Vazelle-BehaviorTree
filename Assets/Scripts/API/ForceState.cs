using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * @brief Utilisé pour forcer le retour
 *
 * Pour n'importe quelle INode (Selector, Action ...) on va pouvoir
 * retourner toujours SUCCESS ou toujours FAILURE, au choix.
 */
class ForceState<T> 
    where T : INode, new()
{
    private T instance;
    private State returnState;

    public ForceState(T instance, State returnState)
    {
        this.instance = instance;
        this.returnState = returnState;
    }

    State act()
    {
        instance.act();
        return returnState;
    }
}

