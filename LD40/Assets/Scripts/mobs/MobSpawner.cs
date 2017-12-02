using UnityEngine;

namespace mobs
{
	public enum MobSpawnSide
	{
		Left,
		Right,
	}
	
	public class MobSpawner : MonoBehaviour {
		
		// Variables
		// =====================================================================

		/// <summary>
		/// The prefab to spawn
		/// </summary>
		public GameObject mob;

		/// <summary>
		/// The side to spawn on (must be the same side as the targets)
		/// </summary>
		public MobSpawnSide spawnSide;
		
		/// <summary>
		/// Radius of spawn circle
		/// </summary>
		public float radius = 10f;

		/// <summary>
		/// Seconds between each spawn
		/// </summary>
		public float spawnDelay = 3f;

		/// <summary>
		/// The parent (for neatness in the editor)
		/// </summary>
		private GameObject _parent;

		// Unity
		// =====================================================================

		private void Start()
		{
			// Create the parent
			_parent = new GameObject("Protesters");
			
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
			// Set the spawn point to a random location in a 2d circle
			Vector3 spawnPoint = Random.insideUnitCircle;
			// Pad that location by our radius 
			// (not sure on this but it kind of works, I think we're just be replacing the position)
			// FIXME
			Vector2 padding = Random.insideUnitCircle * radius;
			spawnPoint += new Vector3(padding.x, 0, padding.y);
			
			// Reset y to 0
			spawnPoint.y = 0f;

			// If the spawn point is on the right, and we want it on the left
			if (spawnPoint.z > 0f && spawnSide == MobSpawnSide.Left)
				// Flip the z to the left
				spawnPoint.z = -spawnPoint.z;
			
			// If the spawn point is on the left, and we want it on the right
			if (spawnPoint.z < 0f && spawnSide == MobSpawnSide.Right)
				// Flip the z to the right
				spawnPoint.z = -spawnPoint.z;
			
			// Instantiate the mob 
			GameObject newMob = Instantiate(mob, spawnPoint, Quaternion.identity);
			newMob.transform.parent = _parent.transform;
		}
		
	}
}
