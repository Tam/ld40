using mobs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    private Transform target;

    public float damage;
    public float fear;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Hit()
    {
        Protester protestor = target.GetComponent<Protester>();
        protestor.Damage(damage);
        protestor.Scare(fear);
    }
}
