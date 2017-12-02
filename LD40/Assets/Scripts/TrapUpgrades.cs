using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapUpgrades : MonoBehaviour
{
    bool isUIUp = false;

    void OnMouseOver()
    {
        if (isUIUp != true)
        {
            MakeUIAppear();
            isUIUp = true;
        }

        Debug.Log("fuck");
    }

    void OnMouseExit()
    {
        if(isUIUp == true)
        {
            isUIUp = false;
        }

        Debug.Log("Doublefuck");
    }

    void MakeUIAppear()
    {
        
    }
}
