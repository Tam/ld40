using mobs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour {

    public float damage;
    public float fear;
    public float speed;

    [Space]
    public GameObject impactEffect;

    [Space]
    public bool gravityOnImpact;
    public float lifeAfterImpact;

    private Transform parentTurret;
    private Transform target;

    private Rigidbody rb;

    public void Seek(Transform parentTurret, Transform target)
    {
        this.parentTurret = parentTurret;
        this.target = target;

        rb = GetComponent<Rigidbody>();
        //Vector3 dir = target.position - transform.position;
        rb.AddForce(transform.TransformDirection(Vector3.right) * speed * 100);
        rb.AddTorque(Random.insideUnitSphere);
        Destroy(gameObject, 5f);
    }

    void OnCollisionEnter(Collision collision)
    {
        //if(collision.transform.gameObject.tag == target.transform.gameObject.tag)
        //{
            if (gravityOnImpact)
            {
                rb.useGravity = true;
            }
            Destroy(gameObject, lifeAfterImpact);
        //}
        
    }

    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }



        //Vector3 dir = target.position - transform.position;
        //float distanceThisFrame = speed * Time.deltaTime;

        //if(dir.magnitude <= distanceThisFrame)
        //{
        //    HitTarget();
        //    return;
        //}

        //transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        //transform.LookAt(target);
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
