using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviorTree
{
	/// <summary>
	/// INode de comparaison, c'est une classe parent qui permet d'avoir plusieurs INode et le but
	/// et d'hériter cette classe pour faire un traitement différent sur l'ensemble de ces nodes
	/// </summary>
	public class Comparator : INode
	{
		public List<INode> nodes;

		public Comparator()
		{
			nodes = new List<INode>();
		}

		public void Add(INode node)
		{
			nodes.Add(node);
		}

		public virtual State act()
		{
			throw new NotImplementedException();
		}
	}
}
