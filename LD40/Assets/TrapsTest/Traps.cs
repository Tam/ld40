using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    public float SucessRate = 0;
    public int AttractRaduis = 0;
    public int ResourceAmount = 0;

    public float CheckAttractionTime = 10f;

    public Transform TargetPoint;

    public List<GameObject> GlobFlopsInRange;

    private void Start()
    {
        InvokeRepeating("CheckAttraction", 0, CheckAttractionTime);
    }

    private void CheckAttraction()
    {
        foreach (GameObject obj in GlobFlopsInRange)
        {
            if (Random.value <= SucessRate / 100)
            {
                obj.GetComponentInParent<mobs.Globflob>().setTarget(TargetPoint);

                GlobFlopsInRange.Remove(obj);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!GlobFlopsInRange.Contains(other.gameObject))
            GlobFlopsInRange.Add(other.gameObject);

        if (Random.value <= SucessRate / 100)
        {
            Debug.Log("lol");
            other.gameObject.GetComponentInParent<mobs.Globflob>().setTarget(TargetPoint);

            if (GlobFlopsInRange.Contains(other.gameObject))
                GlobFlopsInRange.Remove(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(GlobFlopsInRange.Contains(other.gameObject))
            GlobFlopsInRange.Remove(other.gameObject);
    }
}
