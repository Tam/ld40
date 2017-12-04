using UnityEngine;
using UnityEngine.AI;

namespace Mobs
{
	[RequireComponent(typeof(NavMeshAgent))]
	public class Globflob : MonoBehaviour
	{
		// Variables
		// =====================================================================

		private float _wanderDelay;
		private float _wanderRadius;

		private GlobalVars _globalVars;
		private NavMeshAgent _agent;

		private float _timer;

		private bool Attracted;

		private int AmountOfResoucre = 1;

		private bool _fleeing;

		// Unity
		// =====================================================================

		private void Awake()
		{
			_agent = GetComponent<NavMeshAgent>();
			_agent.SetDestination(Vector3.zero);

			_wanderDelay = Random.Range(10f, 15f);
			_wanderRadius = Random.Range(5f, 50f);
		}

		private void Start()
		{
			_globalVars = GlobalVars.instance;
		}

		private void Update()
		{
			_timer += Time.deltaTime;

			if (!Attracted && !_fleeing)
			{
				if (_timer >= _wanderDelay)
				{
					Vector2 newPos = Random.insideUnitCircle * _wanderRadius;
					_agent.SetDestination(
						transform.position + new Vector3(newPos.x, 0f, newPos.y)
					);
					_timer = 0;
					PickNewTimeAndTarget();
				}
			}

			if (_fleeing && Helpers.AgentHasStoppedMoving(_agent))
				_fleeing = false;
		}

		// Actions
		// =====================================================================

		public void setTarget(Transform _transform)
		{
			Attracted = true;
			AmountOfResoucre += 1;
			_agent.SetDestination(_transform.position);
		}

		private void PickNewTimeAndTarget()
		{
			_wanderDelay = Random.Range(0f, 5f);
			_wanderRadius = Random.Range(5f, 50f);
		}

		/// <summary>
		/// Triggered in Traps::OnTriggerEnter
		/// </summary>
		public void Capture()
		{
			_globalVars.IncreaseGlobflobsCaptured(1);
			_globalVars.DecreaseCurrentMobsBy(MobTypes.Globflob, 1);
			Destroy(gameObject);
		}

		/// <summary>
		/// Run away (usually from a trap that has just been placed)
		/// </summary>
		/// <param name="from"></param>
		/// <param name="distance"></param>
		public void RunAway(Transform from, float distance = 10f)
		{
			_fleeing = true;

			Vector3 nextPos = from.position - transform.position;
			nextPos = nextPos.normalized * distance;

			_agent.SetDestination(transform.position - nextPos);
		}
		
	}
}
