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

        private bool Attracted = false;
		
		// Unity
		// =====================================================================

		private void Awake()
		{
			_agent = GetComponent<NavMeshAgent>();
			_agent.SetDestination(Vector3.zero);
			
			_wanderDelay = Random.Range(10f, 15f);
			_wanderRadius = Random.Range(5f, 50f);
		}

		private void Update()
		{
			_timer += Time.deltaTime;

            if (!Attracted)
            {
                if (_timer >= _wanderDelay)
                {
                    Vector2 newPos = Random.insideUnitCircle * _wanderRadius;
                    _agent.SetDestination(transform.position + new Vector3(newPos.x, 0f, newPos.y));
                    _timer = 0;
                    PickNewTimeAndTarget();
                }
            }
            else
            {
                if (!_agent.pathPending)
                    if (_agent.remainingDistance <= _agent.stoppingDistance)
                        if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                        {
                            GlobalVars.instance.NumUnporcessedGlobFlops += 1;
                            Destroy(gameObject);
                        }
            }
		}

		// Actions
		// =====================================================================

		private void PickNewTimeAndTarget()
		{
			_wanderDelay = Random.Range(0f, 5f);
			_wanderRadius = Random.Range(5f, 50f);
		}

        public void setTarget(Transform _transform)
        {
            Attracted = true;
            _agent.SetDestination(_transform.position);
        }	
	}  
}
