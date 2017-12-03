using UI;
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

[RequireComponent(typeof(UIManager))]
public class GlobalVars : MonoBehaviour
{
	//Singleton
	public static GlobalVars instance;

	public UIManager uiManager;

	// Time Playing the game from start to finish.
	public float TimeElapsed;
	
	// Modifiers
	// =====================================================================

	/// <summary>
	/// How many protesters will spawn per Globflob captured
	/// </summary>
	public int protestersToGlobflobs = 2;

	/// <summary>
	/// How much Supervaluableunobtainium is worth in money
	/// </summary>
	public int moneyToSupervaluableunobtainium = 5;

	/// <summary>
	/// How much Supervaluableunobtainium each Globflob is worth
	/// </summary>
	public int globflobsToSupervaluableunobtainium = 3;

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
	}

	// Game Stats
	// =====================================================================
	
	// Globflobs
	// ---------------------------------------------------------------------

	private int _globflobsCaptured;
	public int globflobsCaptured
	{
		get { return _globflobsCaptured; }
		set
		{
			_globflobsCaptured += value;
			_unprocessedGlobflobs += value;
			_maxProtesters += value * protestersToGlobflobs;
		}
	}

	private int _unprocessedGlobflobs;
	public int unprocessedGlobflobs
	{
		get { return _unprocessedGlobflobs; }
	}

	private int _processedGlobflobs;
	public int processedGlobflobs
	{
		get { return _processedGlobflobs; }
	}

	/// <summary>
	/// Process the Globflobs
	/// 
	/// TODO: Improve. This only works if we only have 1 type of Globflob (no super 'flobs)
	/// </summary>
	/// <param name="amount">Number to process</param>
	public void ProcessGlobflobs(int amount)
	{
		if (amount > _unprocessedGlobflobs)
			amount = _unprocessedGlobflobs;
		
		_unprocessedGlobflobs -= amount;
		_processedGlobflobs += amount;

		_supervaluableunobtainiumAquiredMonth += amount * globflobsToSupervaluableunobtainium;
	}

	// Supervaluableunobtainium
	// ---------------------------------------------------------------------

	private int _supervaluableunobtainiumAquiredTotal;
	public int supervaluableunobtainiumAquiredTotal
	{
		get { return _supervaluableunobtainiumAquiredTotal; }
	}

	private int _supervaluableunobtainiumAquiredMonth;
	public int supervaluableunobtainiumAquiredMonth
	{
		get { return _supervaluableunobtainiumAquiredMonth; }
		set
		{
			// Increase the overall total
			_supervaluableunobtainiumAquiredTotal += value;
			
			// Increase the monthly total
			_supervaluableunobtainiumAquiredMonth += value;
			
			// Increase the money
			_money += value * moneyToSupervaluableunobtainium;
		}
	}
	
	// Money
	// ---------------------------------------------------------------------

	private int _money;
	public int money
	{
		get { return _money; }
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

	//------------------------------------------Upgrades----------------------------------------------//
	//Damage Modifa when you upgrade the damage this value to added on.
	public int TDamageUpgradeNum;

	//This value to added on when upgrading Attack Speed
	public float TAttackSpeed;

	//this value is added on when upgrading range
	public int TAttackRange;


	//thi value is added on when the play upgrades the catch rate or a trap
	public int CatchRateIncrease;

	//this value is added on when upgrading the attract raduis in traps
	public int AttractRaduisIncrease;

	//this value is sbtracted on when decreases the attration time
	public int CheckAtractionTimeIncrease;


	public int AmountGlobFlops
	{
		get { return amountGlobFlops; }

		set { amountGlobFlops = value; }
	}

	public int AmountGlobFlopsKilled
	{
		get { return amountGlobFlopsKilled; }

		set { amountGlobFlopsKilled = value; }
	}

	public int AmountProtestors
	{
		get { return amountProtestors; }

		set { amountProtestors = value; }
	}

	public int MaxAmountProtestor
	{
		get { return maxAmountProtestor; }

		set { maxAmountProtestor = value; }
	}

	public float AmountCurrency
	{
		get { return amountCurrency; }

		set { amountCurrency = value; }
	}

	public int NumUnporcessedGlobFlops
	{
		get { return numUnporcessedGlobFlops; }

		set
		{
			numUnporcessedGlobFlops = value;
			TriggerStatChange(AvailableStats.NumUnprocessedGlobflobs, value);
		}
	}

	// Unity
	// =====================================================================

	void Awake()
	{
		if (instance == null)
			instance = this;
	}

	// Events
	// =====================================================================

	private void TriggerStatChange(AvailableStats stat, int value)
	{
		if (OnStatChangeCallback != null)
			OnStatChangeCallback.Invoke(stat, value);
	}
}
