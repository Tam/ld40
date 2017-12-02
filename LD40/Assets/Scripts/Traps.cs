using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    public float SucessRate;
    public int AttractRaduis;
    public int ResourceAmount;

    public float CheckAttractionTime = 10f;

    public Transform TargetPoint;

    public List<GameObject> GlobFlopsInRange = new List<GameObject>();

    private void Start()
    {
        InvokeRepeating("CheckAttraction", 5, CheckAttractionTime);
    }

    private void CheckAttraction()
    {
        for(int i = 0; i < GlobFlopsInRange.Count; i++)
        {
            if(GlobFlopsInRange[i] == null)
            {
                GlobFlopsInRange.Remove(GlobFlopsInRange[i]);
            }
            else if (Random.value <= SucessRate / 100)
            {
                mobs.Globflob gf = GlobFlopsInRange[i]
                    .GetComponentInParent<mobs.Globflob>();
                
                if (gf != null)
                    gf.setTarget(TargetPoint, ResourceAmount);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!GlobFlopsInRange.Contains(other.gameObject) && other.gameObject.tag == "GlobFlob")
            GlobFlopsInRange.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (GlobFlopsInRange.Contains(other.gameObject))
            GlobFlopsInRange.Remove(other.gameObject);
    }
}
