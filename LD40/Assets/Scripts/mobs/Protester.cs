using UnityEngine;
using UnityEngine.AI;

namespace mobs
{
	[RequireComponent(typeof(NavMeshAgent))]
	public class Protester : MonoBehaviour {
		
		// Variables
		// =====================================================================

		public Transform target;
		
		private NavMeshAgent _agent;
		
		// Unity
		// =====================================================================

		private void Awake()
		{
			_agent = GetComponent<NavMeshAgent>();
		}

		private void Start()
		{
			_agent.SetDestination(target.position);
		}
		
	}
}
