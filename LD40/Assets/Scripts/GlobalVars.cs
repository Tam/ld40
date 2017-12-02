using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars : MonoBehaviour
{
	//Singleton
	public static GlobalVars instance;

	//Time Playing the game from start to finish.
	public float TimeElapsed;

	//--------------------------------------------AI------------------------------------------------//

	//Amount of globflops on playing felid
	private int amountGlobFlops;

	//Maxuim Amount of GlobFlops Allowed
	private int maxAmountGlobFlops;

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

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
	}
}
