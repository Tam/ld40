using mobs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour {

    [Header("Stats")]
    public float damage;
    public float fear;
    public float speed;

    [HideInInspector]
    public float additionalDamage = 0;
    [HideInInspector]
    public float additionalFear = 0;

    [Space]
    public GameObject impactEffect;

    [Space]
    [Header("Physics")]
    public bool gravityOnImpact;
    public float lifeAfterImpact;
    [Range(0, 1)]
    public float randomSpin;

    private Transform parentTurret;
    private Transform target;

    private Rigidbody rb;

    public void Seek(Transform parentTurret, Transform target)
    {
        this.parentTurret = parentTurret;
        this.target = target;

        rb = GetComponent<Rigidbody>();

        rb.AddForce(transform.TransformDirection(Vector3.right) * speed * Random.Range(0.9f, 1) * 100);
        rb.AddTorque(Random.insideUnitSphere * randomSpin);

        Destroy(gameObject, 5f);
    }

    public void Upgrade(float damageUpgradeMultiplier, float fearUpgradeMultiplier)
    {
        if(additionalDamage == 0)
        {
            additionalDamage = damage;
        }

        if(additionalFear == 0)
        {
            additionalFear = fear;
        }

        additionalDamage *= damageUpgradeMultiplier;
        additionalFear *= fearUpgradeMultiplier;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (gravityOnImpact)
        {
            rb.useGravity = true;
        }
        Destroy(gameObject, lifeAfterImpact);
    }

    void HitTarget()
    {
        if (impactEffect != null)
        {
            GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation) as GameObject;
            Destroy(effect, 5f);
        }

        Protester protester = target.GetComponent<Protester>();
        if(protester != null)
        {
            if (damage > 0)
            {
                protester.Damage(damage + additionalDamage);
            }

            if(fear > 0)
            {
                protester.Scare(fear + additionalFear, parentTurret);
            }
        }

        Destroy(gameObject);
    }


}
