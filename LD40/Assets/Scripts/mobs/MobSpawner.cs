using UnityEngine;

namespace Mobs
{
	public class MobSpawner : MonoBehaviour {
		
		// Variables
		// =====================================================================

		/// <summary>
		/// Type of the mob
		/// </summary>
		public MobTypes type;
		
		/// <summary>
		/// The prefab to spawn
		/// </summary>
		public GameObject mob;

		/// <summary>
		/// Seconds between each spawn
		/// </summary>
		public float spawnDelay = 3f;

		/// <summary>
		/// The parent (for neatness in the editor)
		/// </summary>
		private GameObject _parent;

		private GlobalVars _globalVars;

		/// <summary>
		/// Where the mobs will spawn from
		/// </summary>
		private Transform[] _spawnTargets;

		// Unity
		// =====================================================================

		private void Start()
		{
            _globalVars = GlobalVars.instance;
			// Create the parent
			_parent = new GameObject(type + "s");
			
			// Get Spawn targets
			switch (type)
			{
				case MobTypes.Globflob:
					_spawnTargets = _globalVars.GlobflobSpawns;
					break;
				case MobTypes.Protester:
					_spawnTargets = _globalVars.ProtestorSpawns;
					break;
			}
			
			// Run SpawnMob immediately, then every spawnDelay seconds
			InvokeRepeating("SpawnMob", 0f, spawnDelay);
		}
		
		// Actions
		// =====================================================================

		/// <summary>
		/// Spawn the mob
		/// </summary>
		private void SpawnMob()
		{
			int current = _globalVars.GetCurrentMobs(type);
			int max = _globalVars.GetMaxMobs(type);
			
			// Check that we have room to spawn
			if (current >= max)
				return;
			
			// Pick spawn
			Transform spawnPoint = _spawnTargets[Random.Range(0, _spawnTargets.Length)];
			
			// Instantiate the mob 
			GameObject newMob = Instantiate(mob, spawnPoint.position, Quaternion.identity);
			newMob.transform.parent = _parent.transform;
			
			// Increase number of mob
			_globalVars.IncreaseCurrentMobsBy(type, 1);
		}
		
	}
}
