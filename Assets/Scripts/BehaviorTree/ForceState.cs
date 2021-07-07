using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviorTree
{
	/// <summary>
	/// INode de spécification ForceState, ici on spécifie une INode (Action, Selector ...) 
	/// pour forcer l'état de retour (on va pouvoir retourner toujours SUCCESS ou toujours FAILURE, au choix)
	/// </summary>
	public class ForceState<T> : INode
		where T : INode, new()
	{
		private T instance;
		private State returnState;

		public ForceState(T instance, State returnState)
		{
			this.instance = instance;
			this.returnState = returnState;
		}

		public State act()
		{
			instance.act();
			return returnState;
		}
	}
}

