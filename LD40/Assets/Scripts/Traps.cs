using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class Traps : MonoBehaviour
{
    public float SucessRate;
    public float AttractRaduis;

    public float CheckAttractionTime = 10f;

    public Transform TargetPoint;

    public List<GameObject> GlobFlopsInRange = new List<GameObject>();

    private bool isUIUp;

    private GlobalVars _globalVars;

    private void Start()
    {
        _globalVars = GlobalVars.instance;
        GetComponentInChildren<SphereCollider>().radius = AttractRaduis;
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
                    gf.setTarget(TargetPoint);
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

    public void SetCatcherRaduis(float _raduis)
    {
        AttractRaduis = _raduis;
        GetComponentInChildren<SphereCollider>().radius = AttractRaduis;
    }

    public void SetSucessRate(float _Valve)
    {
        SucessRate = _Valve;
    }

    public void SetAttractionTime(int _time)
    {
        CheckAttractionTime = _time;
    }

    void OnMouseOver()
    {
        if (isUIUp != true)
        {
            if(Input.GetMouseButtonDown(0))
            { 
                MakeUIAppear();
                isUIUp = true;
            }
        }
    }

    void OnMouseExit()
    {
        if (isUIUp)
        {
            MakeUIDisappear();
            isUIUp = false;
        }
    }

    void MakeUIAppear()
    {
        _globalVars.uiManager.upgradePanel.SetAndShow(
            "Trap Name Here",
            UIStat.Create("Cooldown Duration", CheckAttractionTime),
            UIStat.Create("Success Chance", SucessRate),
            UIStat.Create("Area of Effect", AttractRaduis)
        );
    }

    void MakeUIDisappear()
    {
        _globalVars.uiManager.upgradePanel.Hide();
    }
}
