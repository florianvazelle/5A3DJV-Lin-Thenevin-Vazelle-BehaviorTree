using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviorTree
{
	/// <summary>
	/// INode de spécification Repeat, ici on spécifie une INode (Action, Selector ...) 
	/// que l'on aimerait répéter un certain nombre
	/// </summary>
	public class Repeat<T> : INode
		where T : INode
	{
		private T instance;
		private int repeatCount;

		public Repeat(T instance, int repeatCount)
		{
			this.instance = instance;
			this.repeatCount = repeatCount;
		}

		public State act()
		{
			int i = 0;
			State res;
			do
			{
				i++;
				res = instance.act();
			} while (i < repeatCount);
			return res;
		}
	}
}

