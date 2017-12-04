using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryAttackable : MonoBehaviour
{
	
	// Variables
	// =====================================================================

	public float maxHealth = 100f;
	private float _currentHealth = 100f;
	public float currentHealth
	{
		get { return _currentHealth; }
		set
		{
			_currentHealth = value;
			healthSlider.value = 1 - (maxHealth - value) / maxHealth;
			
			if (value <= 0f)
				_globalVars.uiManager.ShowGameOver("Protesters raided the factory!");
		}
	}

	public Slider healthSlider;
	
	private GlobalVars _globalVars;
	
	private float _hitEffectZOffset;
	private float _hitEffectYOffset;
	
	private readonly List<int> _currentColliding = new List<int>();
	
	// Unity
	// =====================================================================

	private void Start()
	{
		_globalVars = GlobalVars.instance;
		
		Collider cldr = GetComponent<Collider>();
		
		// Work out how far back we should put the hit effect
		_hitEffectZOffset = Mathf.Abs(cldr.bounds.size.z / 2f);
		_hitEffectYOffset = cldr.bounds.size.y / 2f;

		currentHealth = maxHealth;
	}

	private void OnTriggerEnter(Collider clrd)
	{
		int id = clrd.gameObject.GetInstanceID();
		
		if (_currentColliding.Contains(id))
			return;
		
		_currentColliding.Add(id);
		
		// Spawn the particles
		GameObject effect = Instantiate(_globalVars.hitEffect, transform);
		
		// Set their position
		effect.transform.position = Vector3.zero;
		float x = clrd.transform.position.x;
		effect.transform.localPosition = new Vector3(
			x,
			Random.Range(-_hitEffectYOffset, _hitEffectYOffset),
			_hitEffectZOffset
		);
		
		// Damage
		currentHealth -= _globalVars.protesterAttackDamage;

		// Destroy after effect has finished
		Destroy(effect, effect.GetComponent<ParticleSystem>().main.duration);
	}

	private void OnTriggerExit(Collider cldr)
	{
		_currentColliding.Remove(cldr.gameObject.GetInstanceID());
	}
	
}
