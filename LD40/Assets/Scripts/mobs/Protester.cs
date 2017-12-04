using UnityEngine;
using UnityEngine.AI;

namespace Mobs
{
	[RequireComponent(typeof(NavMeshAgent))]
	public class Protester : MonoBehaviour
	{
		// Variables
		// =====================================================================

		private GlobalVars _globalVars;

		private Transform _target;

		private NavMeshAgent _agent;

		public float maxHealth = 20f;
		private float currentHealth;
		public float fearLimit = 20f;
		private float currentFear;

		private bool _fleeing;

		// Unity
		// =====================================================================

		private void Awake()
		{
			_globalVars = GlobalVars.instance;
			_agent = GetComponent<NavMeshAgent>();
			currentHealth = maxHealth;
		}

		private void Start()
		{
			PickAndGoToRandomTarget();

			// Pick a new random target after 20 seconds, every 10 seconds
			InvokeRepeating("ChangeTarget", 20f, 10f);
		}

		private void Update()
		{
			// If we're not pathing, face the centre
			if (Helpers.AgentHasStoppedMoving(_agent))
			{
				if (_fleeing)
				{
					_fleeing = false;
					// Re-add this mob to the count, re-up the max count
					_globalVars.IncreaseCurrentMobsBy(MobTypes.Protester, 1);
					_globalVars.IncreaseMaxMobsBy(MobTypes.Protester, 1);
				}
				FaceTarget();
			}
		}

		// Actions
		// =====================================================================

		/// <summary>
		/// 50% chance to randomly change target
		/// </summary>
		private void ChangeTarget()
		{
            // Don't change target if we're fleeing
            if (_fleeing)
				return;
			
			// A 75% chance of changing target
			if (Random.value <= 0.75f)
				PickAndGoToRandomTarget();
		}

		/// <summary>
		/// Picks a random target from the pre-defined list
		/// </summary>
		private void PickAndGoToRandomTarget()
		{
			// Pick a random protester target
			Transform[] targets = _globalVars.ProtestorsTargets;
			_target = targets[Random.Range(0, targets.Length)];

			// Find a random spot around that target
			Vector3 target = _target.position;
			float rand = Random.Range(-3.5f, 3f);
			target.x += rand;
			target.z += rand;

			// Go there
			_agent.SetDestination(target);
		}

		/// <summary>
		/// Face the centre (the position of GlobalVars)
		/// </summary>
		private void FaceTarget()
		{
			Vector3 direction =
				(_globalVars.transform.position - transform.position).normalized;

			Quaternion lookRotation = Quaternion.LookRotation(
				new Vector3(direction.x, 0, direction.z)
			);

			transform.rotation = Quaternion.Slerp(
				transform.rotation,
				lookRotation,
				Time.deltaTime * 3f
			);
		}

		/// <summary>
		/// Make the protester take damage
		/// </summary>
		/// <param name="amount">Amount of damage to take</param>
		public void Damage(float amount)
		{
			currentHealth -= amount;
			if (currentHealth < 0)
			{
                // Kill protestor
				if (!_fleeing)
					_globalVars.DecreaseCurrentMobsBy(MobTypes.Protester, 1);
                CancelInvoke();
                Destroy(gameObject);
			}
		}

		/// <summary>
		/// Scare the protester
		/// </summary>
		/// <param name="amount">Amount of fear to add</param>
		public void Scare(float amount)
		{
			currentFear += amount;

			if (currentFear >= fearLimit)
				RunAway();
		}

		/// <summary>
		/// Run away!!
		/// </summary>
		private void RunAway()
		{
			if(_agent == null || !_agent.enabled || _fleeing)
				return;
			
			_fleeing = true;
			currentFear = 0f;
			
			// Temporarily stop them contributing to the total mob count
			// This will stop them adding to the social buzz.
			_globalVars.DecreaseCurrentMobsBy(MobTypes.Protester, 1);
			
			// Temporarily decrease the max # protesters that can spawn, so we
			// don't spawn more protesters than we should.
			_globalVars.DecreaseMaxMobsBy(MobTypes.Protester, 1);
			
			Transform runTo = 
				_globalVars.ProtestorSpawns[Random.Range(0, _globalVars.ProtestorSpawns.Length)];

			_agent.SetDestination(runTo.transform.position);
		}
	}
}
