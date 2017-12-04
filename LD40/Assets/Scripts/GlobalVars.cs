using Logic;
using Traps;
using UI;
using UnityEngine;

public enum MobTypes
{
	Protester,
	Globflob,
}

[RequireComponent(typeof(UIManager), typeof(SocialBuzz), typeof(Quota))]
public class GlobalVars : MonoBehaviour
{
	
	//Singleton
	public static GlobalVars instance;

	[Header("Sub-Logic")]
	public UIManager uiManager;

	public SocialBuzz socialBuzz;

	public Quota quota;

	public Inspection inspection;

	public TrapPlacement TrapPlacement;

	// Time Playing the game from start to finish.
	[Space]
	public float TimeElapsed;
	
	// Events
	// =====================================================================

	public delegate void OnMoneyChange(int money);
	public OnMoneyChange OnMoneyChangeCallback;
	
	// Modifiers
	// =====================================================================

	/// <summary>
	/// How many protesters will spawn per Globflob captured
	/// </summary>
	[Header("Modifiers")]
	public int protestersToGlobflobs = 2;

	/// <summary>
	/// How much Supervaluableunobtainium is worth in money
	/// </summary>
	public int moneyToSupervaluableunobtainium = 5;

	/// <summary>
	/// How much Supervaluableunobtainium each Globflob is worth
	/// </summary>
	public int globflobsToSupervaluableunobtainium = 3;

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

	// Score
	// ---------------------------------------------------------------------

	public float score;
	public bool scoreBonus;
	public float scoreBonusMultiplier = 1.2f;
	
	// Date
	// ---------------------------------------------------------------------
	
	private int _day = 1;
	public int day
	{
		get { return _day; }
	}

	private int _month = 1;
	public int month
	{
		get { return _month; }
	}

	// Globflobs
	// ---------------------------------------------------------------------

	private int _globflobsCaptured;
	public int globflobsCaptured
	{
		get { return _globflobsCaptured; }
	}

	public void IncreaseGlobflobsCaptured(int amount)
	{
		_globflobsCaptured += amount;
		_unprocessedGlobflobs += amount;
		_maxProtesters += amount * protestersToGlobflobs;
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
	/// </summary>
	/// <param name="amount">Number to process</param>
	/// <param name="worth">
	/// 	How much Supervaluableunobtainium this Globflob is worth.
	/// 	Leave at -1 (unset) to use the default value.
	/// 	TODO: For worth to work, Factory needs to know the worth of each Globflob
	/// 	TODO(cont.): So we'll need to store each Globflob in a list w/ their worth
	/// </param>
	public void ProcessGlobflobs(int amount, int worth = -1)
	{
		if (_unprocessedGlobflobs == 0)
			return;
		
		if (worth < 0)
			worth = globflobsToSupervaluableunobtainium;
		
		if (amount > _unprocessedGlobflobs)
			amount = _unprocessedGlobflobs;
		
		_unprocessedGlobflobs -= amount;
		_processedGlobflobs += amount;

		IncreaseSupervaluableunobtainiumAquired(amount * worth);
	}

	// Supervaluableunobtainium
	// ---------------------------------------------------------------------

	private int _supervaluableunobtainiumAquiredTotal;
	public int supervaluableunobtainiumAquiredTotal
	{
		get { return _supervaluableunobtainiumAquiredTotal; }
	}

	public void IncreaseSupervaluableunobtainiumAquired(int amount)
	{
		// Increase the overall total
		_supervaluableunobtainiumAquiredTotal += amount;
		
		// Increase the monthly quota count
		quota.IncreaseCurrentQuota(amount);
			
		// Increase the money
		IncreaseMoney(amount * moneyToSupervaluableunobtainium);
		
		// Increase the score
		score += scoreBonus ? amount * scoreBonusMultiplier : amount;
	}
	
	// Money
	// ---------------------------------------------------------------------

	private int _money = 100;
	public int money
	{
		get { return _money; }
	}

	public void IncreaseMoney(int amount)
	{
		_money += amount;
		
		if (OnMoneyChangeCallback != null)
			OnMoneyChangeCallback.Invoke(_money);
	}

	public void DecreaseMoney(int amount)
	{
		_money -= amount;
		
		if (OnMoneyChangeCallback != null)
			OnMoneyChangeCallback.Invoke(_money);
	}
	
	// Misc
	// ---------------------------------------------------------------------

	/// <summary>
	/// The amount of money it costs to build a trap
	/// </summary>
	[Header("Misc")]
	public int trapCost = 100;


	#region Old variables that need orgainizing
	
	//--------------------------------------------AI------------------------------------------------//

	//Amount of globflops on playing felid
	private int amountGlobFlops;

	//Maxuim Amount of GlobFlops Allowed
	[Header("Other (needs organizing)")]
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
	
	#endregion
	

	// Unity
	// =====================================================================

	void Awake()
	{
		if (instance != null) return;
		
		instance = this;
		uiManager.globalVars = instance;
		socialBuzz.globalVars = instance;
		quota.globalVars = instance;
		inspection.globalVars = instance;
		TrapPlacement.globalVars = instance;
	}

	private void Start()
	{
		// Day tick runs every 2s after 2s
		InvokeRepeating("DayTick", 2f, 2f);
	}

	// Actions
	// =====================================================================

	public void Pause()
	{
		Time.timeScale = 0;
	}

	public void UnPause()
	{
		Time.timeScale = 1;
	}

	/// <summary>
	/// Goes to the next day
	/// </summary>
	private void DayTick()
	{
		_day++;
		
		// If the day isn't higher than the max per month (30), return 
		if (_day <= 30)
			return;

		_day = 1;
		_month++;
		
		quota.CheckQuotaReached();
	}
	
}
