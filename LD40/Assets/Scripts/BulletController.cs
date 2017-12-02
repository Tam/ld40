using mobs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float damage;
    public float fear;
    public float speed;

    [Space]
    public GameObject impactEffect;

    private Transform parentTurret;
    private Transform target;

    public void Seek(Transform parentTurret, Transform target)
    {
        this.parentTurret = parentTurret;
        this.target = target;
    }

    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation) as GameObject;
        Destroy(effect, 5f);

        Protester protester = target.GetComponent<Protester>();
        if(protester != null)
        {
            if (damage > 0)
            {
                protester.Damage(damage);
            }

            if(fear > 0)
            {
                protester.Scare(fear, parentTurret);
            }
        }

        Destroy(gameObject);
    }
}
