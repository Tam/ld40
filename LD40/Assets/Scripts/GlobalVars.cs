using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars : MonoBehaviour
{
    //Singleton
    public static GlobalVars GlobalVarsSingleton;

    //Time Playing the game from start to finish.
    public float TimeElapsed;

    //--------------------------------------------AI------------------------------------------------//

    //Amount of globflops on playing felid
    public int AmountGlobFlops;

    //Maxuim Amount of GlobFlops Allowed
    public int MaxAmountGlobFlops;

    //Minium Amount of GlobFlops Allowed
    public int MinAmountGlobFlops;

    //Amount of GlobFlops killed
    public int AmountGlobFlopsKilled;

    //Amount of Protestors
    public int AmountProtestors;

    //Maxuim Amount Of Protestors
    public int MaxAmountProtestor;

    //Default Target Positions for Protestors
    public Transform[] ProtestorsTargets = new Transform[5];

    //------------------------------------------Mechcanics------------------------------------------//

    //Amount of Currency
    public float AmountCurrency;

    //Global Price SuperValibleUnObtainium
    public float GobalPriceUnobtainium;

    //------------------------------------------Placements------------------------------------------//

    //Amount of Turrents Placed
    public int TurretsPlaced;

    //Amount of Traps Placed
    public int TrapsPlaced;


    void Awake()
    {
        if(GlobalVarsSingleton == null)
        {
            GlobalVarsSingleton = this;
        }
    }
}
