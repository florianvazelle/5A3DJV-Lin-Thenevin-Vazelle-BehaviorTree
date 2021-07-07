using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviorTree
{
	/// <summary>
	/// INode de spécification Retry, ici on spécifie une INode (Action, Selector ...) 
	/// que l'on aimerait retenté un certain nombre, si l'action échoue
	/// </summary>
	public class Retry<T> : INode
		where T : INode
	{
		private T instance;
		private int retryCount;

		public Retry(T instance, int retryCount)
		{
			this.instance = instance;
			this.retryCount = retryCount;
		}

		public State act()
		{
			int i = 0;
			State res;
			do
			{
				i++;
				res = instance.act();
			} while (i < retryCount && res != State.SUCCESS);
			return res;
		}
	}
}