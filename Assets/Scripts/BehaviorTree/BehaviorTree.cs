using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviorTree
{
	public static class BehaviorTree
	{
		/// <summary>
		/// Lance l'exploration de notre arbre de comportement, depuis une INode root
		/// </summary>
		/// <param name="selector">
		/// L'INode root de notre Behavior Tree
		/// </param>
		public static void act(Selector selector)
		{
			selector.act();
		}
	}
}
