﻿using System.Collections;
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

    public FireType fireType;

    [Header("Projectile Properties")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;

    [Header("Particle Properties")]

    [Header("Line Renderer Properties")]
    public LineRenderer lineRenderer;
    // TODO: Other stats

    [Header("Debug")]
    public Color radiusColor = Color.red;
    private Color targetLineColor = Color.red;
    public bool showRadius = true;
    public bool showRayToTarget = true;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("FindTarget", 0, findTargetFrequency);
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
	void Update ()
    {
		if(target != null)
        {
            TrackTarget();

            Shoot();
        }
        else
        {
            if(lineRenderer != null)
            {
                lineRenderer.enabled = false;
            }
        }
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

    }

    void ShootParticle()
    {

    }

    void ShootLineRenderer()
    {
        if (target == null) return;

        if(lineRenderer == null)
        {
            throw new UnityException("Did not define a line renderer for turret.");
        }

        IsLookingAtTarget();

        //lineRenderer.enabled = true;

        lineRenderer.SetPosition(0, muzzlePoint.position);
        lineRenderer.SetPosition(1, target.transform.position);
    }

    bool IsLookingAtTarget()
    {
        targetLineColor = Color.red;
        if (target == null) return false;
        Debug.Log("RAY");

        RaycastHit hit;
        Debug.DrawRay(muzzlePoint.transform.position, muzzlePoint.transform.TransformDirection(Vector3.forward) * 100f, Color.cyan);
        if(Physics.Raycast(muzzlePoint.transform.position, muzzlePoint.transform.TransformDirection(Vector3.forward), out hit, 100f))
        {
            Debug.Log(hit.transform.gameObject.GetInstanceID() + " + " + target.GetInstanceID());
            if (hit.transform.gameObject.GetInstanceID() == target.GetInstanceID())
            {
                Debug.Log("Is looking at target");
                targetLineColor = Color.blue;
                return true;
            }
        }
        targetLineColor = new Color(255, 157, 10);
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