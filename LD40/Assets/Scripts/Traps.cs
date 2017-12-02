﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    public float SucessRate;
    public float AttractRaduis;

    public float CheckAttractionTime = 10f;

    public Transform TargetPoint;

    public List<GameObject> GlobFlopsInRange = new List<GameObject>();
    public UpgradePanel upgradePanel; 

    bool isUIUp = false;

    private void Start()
    {
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

        //Ui Set
        upgradePanel.setStat1Text((int)AttractRaduis);
    }

    public void SetSucessRate(float _Valve)
    {
        SucessRate = _Valve;

        //Ui Set
        upgradePanel.setStat2Text((int)SucessRate);
    }

    public void SetAttractionTime(int _time)
    {
        CheckAttractionTime = _time;

        //Ui Set
        upgradePanel.setStat3Text((int)CheckAttractionTime);
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

        Debug.Log("fuck");
    }

    void OnMouseExit()
    {
        if (isUIUp == true)
        {
            isUIUp = false;
        }

        Debug.Log("Doublefuck");
    }

    void MakeUIAppear()
    {
        upgradePanel.gameObject.SetActive(true);

        upgradePanel.setStat3Text((int)CheckAttractionTime);
        upgradePanel.setStat2Text((int)SucessRate);
        upgradePanel.setStat1Text((int)AttractRaduis);
    }

    void MakeUIDisappear()
    {
        upgradePanel.gameObject.SetActive(false);
    }
}
