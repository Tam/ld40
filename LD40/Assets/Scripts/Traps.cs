using System.Collections.Generic;
using mobs;
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
	private bool _wasPlaced = true;

	private GlobalVars _globalVars;

	public TrapTypes Type;

	private void Start()
	{
		_globalVars = GlobalVars.instance;
		GetComponentInChildren<SphereCollider>().radius = AttractRaduis;
		InvokeRepeating("CheckAttraction", 5, CheckAttractionTime);
	}

	private void CheckAttraction()
	{
		for (int i = 0; i < GlobFlopsInRange.Count; i++)
		{
			if (GlobFlopsInRange[i] == null)
			{
				GlobFlopsInRange.Remove(GlobFlopsInRange[i]);
			}
			else if (Random.value <= SucessRate / 100)
			{
				Globflob gf = GlobFlopsInRange[i].GetComponentInParent<Globflob>();

				if (gf != null)
					gf.setTarget(TargetPoint);
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!other.gameObject.CompareTag("GlobFlob"))
			return;

		if (GlobFlopsInRange.Contains(other.gameObject))
		{
			Globflob gf = other.GetComponent<Globflob>();
			if (gf == null)
				gf = other.transform.parent.GetComponent<Globflob>();
			
			gf.Capture();
		}
		else
		{
			GlobFlopsInRange.Add(other.gameObject);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (GlobFlopsInRange.Contains(other.gameObject))
			GlobFlopsInRange.Remove(other.gameObject);
	}

	public void SetCatcherRaduis(float _raduis)
	{
		AttractRaduis += _raduis;
		GetComponentInChildren<SphereCollider>().radius = AttractRaduis;
		UpdateUI();
	}

	public void SetSucessRate(float _Valve)
	{
		SucessRate += _Valve;
		UpdateUI();
	}

	public void SetAttractionTime(int _time)
	{
		CheckAttractionTime -= _time;
		UpdateUI();
	}

	void OnMouseOver()
	{
		if (isUIUp != true)
		{
			if (Input.GetMouseButtonUp(0))
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
//          MakeUIDisappear();
			isUIUp = false;
		}
	}

	void MakeUIAppear()
	{
		if (_wasPlaced)
		{
			_wasPlaced = false;
			return;
		}

		_globalVars.uiManager.upgradePanel.SetAndShow(
			transform,
			"Trap Name Here",
			UIStat.Create("Cooldown Duration", CheckAttractionTime),
			UIStat.Create("Success Chance", SucessRate),
			UIStat.Create("Area of Effect", AttractRaduis),
			this
		);
	}

	void UpdateUI()
	{
		_globalVars.uiManager.upgradePanel.SetStats(
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
