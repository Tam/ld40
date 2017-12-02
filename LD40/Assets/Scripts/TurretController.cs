using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {

    private GameObject target;

    [Header("Turret Parts")]
    public Transform turretHead;
    public Transform muzzlePoint;

    [Header("General")]
    public string enemyTag;
    public float range = 10f;

    [Header("Use Projectiles")]
    public bool useProjectiles;
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    
    [Header("Use Particles")]
    public bool useParticles;

    [Header("Use Line Renderer")]
    public bool useLineRenderer;

    [Header("Debug")]
    public Color radiusColor = Color.red;
    public bool showRadius;
    public bool showRayToTarget;

	// Use this for initialization
	void Start () {
        InvokeRepeating("FindTarget", 1, 1);
	}
	
    void FindTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(enemyTag);
        float closestDist = int.MaxValue;
        GameObject closestObj = null;

        foreach(var enemy in targets)
        {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);
            if(dist < closestDist)
            {
                closestDist = dist;
                closestObj = enemy;
            }
        }

        target = (closestObj != null) && (closestDist <= range) ? closestObj : null;
    }

	// Update is called once per frame
	void Update () {
		
	}

    void OnDrawGizmos()
    {
        Gizmos.color = radiusColor;
        if (showRadius)
        {
            Gizmos.DrawWireSphere(transform.position, range);
        }
        
        if(target != null && showRayToTarget)
        {
            //TODO: Set color to green is target in range, else red
            if (Vector3.Distance(transform.position, target.transform.position) <= range)
            {
                Gizmos.color = Color.blue;
            }
            else
            {
                Gizmos.color = Color.red;
            }
            Gizmos.DrawLine(muzzlePoint.transform.position, target.transform.position);
        }
    }
}
