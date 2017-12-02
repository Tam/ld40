using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {

    public enum FireType
    {
        Projectile,
        Particle,
        Line_Renderer
    }

    private GameObject target;

    [Header("Turret Parts")]
    public Transform turretHead;
    public Transform muzzlePoint;

    [Header("General")]
    public string enemyTag;
    public float range = 10f;
    public float turnSpeed = 2.5f;
    public float findTargetFrequency = 0.75f;
    
    [Space]
    public float damage = 1f;
    public float fear;

    public float damagePerTick = 0.1f;
    public float fearPerTick;
    
    [Space]
    public FireType fireType;

    [Header("Projectile Properties")]
    public GameObject bulletPrefab;
    public int projectilesPerShot = 1;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Particle Properties")]
    public ParticleSystem particles;
    
    [Header("Line Renderer Properties")]
    public LineRenderer lineRenderer;

    [Header("Debug")]
    public Color radiusColor = Color.red;
    private Color targetLineColor = Color.red;
    public bool showRadius = true;
    public bool showRayToTarget = true;

	void Start ()
    {
        InvokeRepeating("FindTarget", 0, findTargetFrequency);
	}
	

	void Update ()
    {
		if(target != null)
        {
            TrackTarget();

            Shoot();
        }
        else
        {
            if(particles != null)
            {
                particles.Stop();
            }
        }
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

    void Shoot()
    {
        switch (fireType)
        {
            case FireType.Projectile:
                ShootProjectile();
                break;
            case FireType.Particle:
                ShootParticle();
                break;
            case FireType.Line_Renderer:
                ShootLineRenderer();
                break;
            default:
                Debug.LogError("[WUT] Unknown fire type.");
                break;
        }
    }

    void ShootProjectile()
    {
        if(fireCountdown <= 0f)
        {
            FireProjectile();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    void ShootParticle()
    {
        if (particles == null)
        {
            throw new UnityException("Did not define a particle system for turret.");
        }

        if(target != null)
        {
            particles.Play();
        }        

    }

    void ShootLineRenderer()
    {
        if (target == null) return;

        if(lineRenderer == null)
        {
            throw new UnityException("Did not define a line renderer for turret.");
        }

        if (IsLookingAtTarget())
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, muzzlePoint.position);
            lineRenderer.SetPosition(1, target.transform.position);
        }
        else
        {
            lineRenderer.enabled = false;
        }
       
    }

    void FireProjectile()
    {
        for(int i = 0; i < projectilesPerShot; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, muzzlePoint.transform.position, muzzlePoint.transform.rotation) as GameObject;
            BulletController bulletController = bullet.GetComponent<BulletController>();
            if(bulletController != null)
            {
                bulletController.Seek(gameObject.transform, target.transform);
            }
        }
    }

    bool IsLookingAtTarget()
    {
        targetLineColor = Color.red;
        if (target == null) return false;

        RaycastHit hit;
        if (Physics.Raycast(muzzlePoint.transform.position, muzzlePoint.transform.TransformDirection(Vector3.right), out hit, 100f))
        {
            if (hit.transform.gameObject.GetInstanceID() == target.GetInstanceID())
            {
                targetLineColor = Color.blue;
                return true;
            }
        }
        targetLineColor = new Color(1, 0.616f, 0.039f);
        return false;
    }

    void TrackTarget()
    {
        Vector3 dir = target.transform.position - turretHead.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(turretHead.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        turretHead.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
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
            //if (Vector3.Distance(transform.position, target.transform.position) <= range)
            //{
            //    Gizmos.color = Color.blue;
            //}
            //else
            //{
            //    Gizmos.color = Color.red;
            //}
            Gizmos.color = targetLineColor;
            Gizmos.DrawLine(muzzlePoint.transform.position, target.transform.position);
        }
    }
}
