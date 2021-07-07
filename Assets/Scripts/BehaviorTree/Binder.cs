using System;

namespace BehaviorTree
{
	/// <summary>
	/// Dans certain cas, on va avoir besoin de passer un paramètre a une action
	///    <example>
	///    State ActionDemo() 
	///    {
	///        ...
	///    }
	///    ...
	///    new Action(agentFight.ActionDemo)
	///    </example>
	/// à la place on aura :
	///    <example>
	///    State ActionDemo(Agent agent) 
	///    {
	///        ...
	///    }
	///    ...
	///    new Action(new Binder<Agent, State>(agent.ActionDemo, otherAgent).Apply))
	///    </example>
	/// </summary>
	public sealed class Binder<T, TResult>
	{
		private readonly T arg;
		private readonly Func<T, TResult> func;

		internal Binder(Func<T, TResult> func, T arg)
		{
			this.func = func;
			this.arg = arg;
		}

		public TResult Apply()
		{
			return func(arg);
		}
	}
}
