using UnityEngine;
using UnityEngine.AI;

namespace mobs
{
	[RequireComponent(typeof(NavMeshAgent))]
	public class Globflob : MonoBehaviour {
		
		// Variables
		// =====================================================================

		private float _wanderDelay;
		private float _wanderRadius;

		private NavMeshAgent _agent;

		private float _timer;
		
		// Unity
		// =====================================================================

		private void Awake()
		{
			_agent = GetComponent<NavMeshAgent>();
			PickNewTimeAndTarget();
		}

		private void Update()
		{
			_timer += Time.deltaTime;
 
			if (_timer >= _wanderDelay) {
				Vector3 newPos = Random.insideUnitCircle * _wanderRadius;
				_agent.SetDestination(newPos);
				_timer = 0;
				PickNewTimeAndTarget();
			}
		}

		// Actions
		// =====================================================================

		private void PickNewTimeAndTarget()
		{
			_wanderDelay = Random.Range(1f, 20f);
			_wanderRadius = Random.Range(3f, 10f);
		}
		
	}
}
