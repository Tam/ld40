using UnityEngine;
using UnityEngine.AI;

namespace mobs
{
	[RequireComponent(typeof(NavMeshAgent))]
	public class Protester : MonoBehaviour {
		
		// Variables
		// =====================================================================

		private GlobalVars _globalVars;
		
		private Transform _target;
		
		private NavMeshAgent _agent;

        public float maxHealth = 20f;
        private float currentHealth;
        public float fearLimit = 20f;
        private float currentFear;

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
			if (!_agent.pathPending)
				if (_agent.remainingDistance <= _agent.stoppingDistance)
					if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
						FaceTarget();
		}
		
		// Actions
		// =====================================================================

		/// <summary>
		/// 50% chance to randomly change target
		/// </summary>
		private void ChangeTarget()
		{
			if (Random.value >= 0.25f)
				PickAndGoToRandomTarget();
		}

		/// <summary>
		/// Picks a random target from the pre-defined list
		/// </summary>
		private void PickAndGoToRandomTarget()
		{
			Transform[] targets = _globalVars.ProtestorsTargets;
			_target = targets[Random.Range(0, targets.Length)];

			Vector3 target = _target.position;
			float rand = Random.Range(-3.5f, 3f);
			target.x += rand;
			target.z += rand;
			
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

        public void Damage(float amount)
        {
            currentHealth -= amount;
            if(currentHealth < 0)
            {
                //Kill protestor
                Destroy(this);
            }
        }

        public void Scare(float amount)
        {
            currentFear += amount;

            if(currentFear >= fearLimit)
            {
                //Scare the protester
                //Run away?
            }
        }
		
	}
}
