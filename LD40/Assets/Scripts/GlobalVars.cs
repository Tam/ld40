using UnityEngine;

public enum MobTypes
{
    Protester,
    Globflob,
}

public enum AvailableStats
{
    NumUnprocessedGlobflobs,
}

public class GlobalVars : MonoBehaviour
{
    //Singleton
    public static GlobalVars instance;

    //Time Playing the game from start to finish.
    public float TimeElapsed;
    
    // Events
    // =====================================================================
    
    public delegate void OnStatChange(AvailableStats stat, int value);
    public OnStatChange OnStatChangeCallback;
    
    // Mobs
    // =====================================================================

    public void IncreaseCurrentMobsBy(MobTypes mob, int amount)
    {
        switch (mob)
        {
            case MobTypes.Protester:
                _currentProtesters += amount;
                break;
            case MobTypes.Globflob:
                _currentGlobflobs += amount;
                break;
        }
    }

    public void DecreaseCurrentMobsBy(MobTypes mob, int amount)
    {
        switch (mob)
        {
            case MobTypes.Protester:
                _currentProtesters -= amount;
                break;
            case MobTypes.Globflob:
                _currentGlobflobs -= amount;
                break;
        }
    }

    public int GetCurrentMobs(MobTypes mob)
    {
        switch (mob)
        {
            case MobTypes.Protester:
                return _currentProtesters;
            case MobTypes.Globflob:
                return _currentGlobflobs;
        }

        return 0;
    }

    public int GetMaxMobs(MobTypes mob)
    {
        switch (mob)
        {
            case MobTypes.Protester:
                return _maxProtesters;
            case MobTypes.Globflob:
                return _maxGlobflobs;
        }

        return 0;
    }
    
    // Globflobs
    // ---------------------------------------------------------------------

    private int _currentGlobflobs;
    public int currentGlobflobs
    {
        get { return _currentGlobflobs; }
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

    //Stored GlobFlops For processing
    private int numUnporcessedGlobFlops;

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

    public int NumUnporcessedGlobFlops
    {
        get
        {
            return numUnporcessedGlobFlops;
        }

        set
        {
            numUnporcessedGlobFlops = value;
            TriggerStatChange(AvailableStats.NumUnprocessedGlobflobs, value);
        }
    }

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void TriggerStatChange(AvailableStats stat, int value)
    {
        if (OnStatChangeCallback != null)
            OnStatChangeCallback.Invoke(stat, value);
    }
    
}
