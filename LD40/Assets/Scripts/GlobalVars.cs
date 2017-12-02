using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars : MonoBehaviour
{
    //Singleton
    public static GlobalVars instance;

    //Time Playing the game from start to finish.
    public float TimeElapsed;
    
    // Mobs
    // =====================================================================
    
    // Globflobs
    // ---------------------------------------------------------------------

    private int _currentGlobflobs;
    public int currentGlobflobs
    {
        get { return _currentGlobflobs; }
        set { _currentGlobflobs = value; }
    }

    private int _maxGlobflobs = 50;
    public int maxGlobflobs
    {
        get { return _maxGlobflobs; }
        set { _maxGlobflobs = value; }
    }

    // Protestors
    // ---------------------------------------------------------------------

    private int _currentProtesters;
    public int currentProtesters
    {
        get { return _currentProtesters; }
        set { _currentProtesters = value; }
    }

    private int _maxProtesters = 50;
    public int maxProtesters
    {
        get { return _maxProtesters; }
        set { _maxProtesters = value; }
    }

    //--------------------------------------------AI------------------------------------------------//

    //Amount of globflops on playing felid
    private int amountGlobFlops;

    //Maxuim Amount of GlobFlops Allowed
    public int maxAmountGlobFlops;

    //Minium Amount of GlobFlops Allowed
    public int minAmountGlobFlops;

    //Amount of GlobFlops killed
    private int amountGlobFlopsKilled;

    //Amount of Protestors
    private int amountProtestors;

    //Maxuim Amount Of Protestors
    private int maxAmountProtestor;

    // Default Target Positions for Protestors
    public Transform[] ProtestorsTargets = new Transform[5];

    //------------------------------------------Mechcanics------------------------------------------//

    //Amount of Currency
    private float amountCurrency;

    //Global Price SuperValibleUnObtainium
    public float GobalPriceUnobtainium;

    //------------------------------------------Placements------------------------------------------//

    //Amount of Turrents Placed
    public int TurretsPlaced;

    //Amount of Traps Placed
    public int TrapsPlaced;


    public int AmountGlobFlops
    {
        get
        {
            return amountGlobFlops;
        }

        set
        {
            amountGlobFlops = value;
        }
    }

    public int AmountGlobFlopsKilled
    {
        get
        {
            return amountGlobFlopsKilled;
        }

        set
        {
            amountGlobFlopsKilled = value;
        }
    }

    public int AmountProtestors
    {
        get
        {
            return amountProtestors;
        }

        set
        {
            amountProtestors = value;
        }
    }

    public int MaxAmountProtestor
    {
        get
        {
            return maxAmountProtestor;
        }

        set
        {
            maxAmountProtestor = value;
        }
    }

    public float AmountCurrency
    {
        get
        {
            return amountCurrency;
        }

        set
        {
            amountCurrency = value;
        }
    }

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
}
