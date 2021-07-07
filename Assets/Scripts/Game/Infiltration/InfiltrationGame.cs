using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

namespace Infiltration
{
	/// <summary>
	/// Jeu d'infiltration, on crée 4 agent de patrouille qui lorsque le joueur rentrera dans leur champs de vision,
	/// se rapprocherons du joueur et lui tirerons dessus (un son de fusil sera joué)
	/// </summary>
	public class InfiltrationGame : MonoBehaviour
	{
		/// <summary>
		/// Structure pour représenter un agent dans l'inspecteur d'Unity
		/// Il est composé des données dont on aura besoin
		/// </summary>
		[System.Serializable]
		public struct Agent
		{
			public GameObject agentGO;
			public Vector3 src, dst;
		}

		public List<Agent> agents;
		private List<AgentPatrol> agentsPatrol;
		private List<Selector> rootSelectors;

		void Start()
		{
			agentsPatrol = new List<AgentPatrol>();
			rootSelectors = new List<Selector>();

			// Pour chaque agent déclaré dans l'inspecteur d'Unity, on crée un AgentPatrol et un arbre de comportement lui correspondant
			for (var i = 0; i < agents.Count; i++)
			{
				agentsPatrol.Add(new AgentPatrol(agents[i].agentGO, agents[i].src, agents[i].dst));

				/* Utilisation de l'API */

				// On crée une première Sequence de détection et d'action
				Sequence detectActionSequence = new Sequence();
				// Si on détecte le joueur
				detectActionSequence.Add(new Action(agentsPatrol[i].Detection));
				// On se rapproche de lui
				detectActionSequence.Add(new Action(agentsPatrol[i].MoveToTarget));
				// Et on lui tire dessus par interval
				detectActionSequence.Add(new Delay<Action>(new Action(agentsPatrol[i].Fire), 2));

				// On crée une seconde Sequence, qui est la Sequence par défaut
				Sequence defaultSequence = new Sequence();
				// L'agent patrouille
				defaultSequence.Add(new Action(agentsPatrol[i].Patrol));

				// On ajoute ensuite l'ensemble de nos Sequence a notre Selector principale
				rootSelectors.Add(new Selector());
				rootSelectors[i].Add(detectActionSequence);
				rootSelectors[i].Add(defaultSequence);
			}
		}

		void Update()
		{
			// On applique le BehaviorTree sur l'ensemble de nos agents
			for (var i = 0; i < rootSelectors.Count; i++)
				BehaviorTree.BehaviorTree.act(rootSelectors[i]);
		}
	}
}