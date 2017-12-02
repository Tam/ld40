﻿using UnityEngine;

namespace mobs
{
	public class MobSpawner : MonoBehaviour {
		
		// Variables
		// =====================================================================

		/// <summary>
		/// Name of the mob
		/// </summary>
		public new string name;
		
		/// <summary>
		/// The prefab to spawn
		/// </summary>
		public GameObject mob;

		/// <summary>
		/// Where the mobs will spawn from
		/// </summary>
		public Transform[] spawnTargets = new Transform[5];

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
			_parent = new GameObject(name);
			
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
			// Pick spawn
			Transform spawnPoint = spawnTargets[Random.Range(0, spawnTargets.Length)];
			
			// Instantiate the mob 
			GameObject newMob = Instantiate(mob, spawnPoint.position, Quaternion.identity);
			newMob.transform.parent = _parent.transform;
		}
		
	}
}
