using Mobs;
using UnityEngine;

namespace Turrets
{
    [RequireComponent(typeof(Rigidbody))]
    public class BulletController : MonoBehaviour {

        [Header("Stats")]
        public float damage;
        public float fear;
        public float speed;

        [HideInInspector]
        public float additionalDamage;
        [HideInInspector]
        public float additionalFear;

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
        private bool hasHit;

        public void Seek(Transform parentTurret, Transform target)
        {
            this.parentTurret = parentTurret;
            this.target = target;

            rb = GetComponent<Rigidbody>();

            rb.AddForce(transform.TransformDirection(Vector3.forward) * speed * Random.Range(0.9f, 1) * 100);
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

            if (!hasHit)
            {
                HitTarget();
                hasHit = false;
            }
        
        }

        void HitTarget()
        {
            if (impactEffect != null)
            {
                GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation) as GameObject;
                Destroy(effect, 5f);
            }

            if(target == null)
            {
                return;
            }

            Protester protester = target.GetComponent<Protester>();

            if (protester != null)
            {
                if (damage > 0)
                {
                    protester.Damage(damage + additionalDamage);
                }

                if(fear > 0)
                {
                    protester.Scare(fear + additionalFear);
                }
            }

            Destroy(gameObject);
        }


    }
}
