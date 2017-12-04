using System.Collections.Generic;
using Mobs;
using UI;
using UnityEngine;

namespace Traps
{
	public class Trap : MonoBehaviour
	{
		
		// Variables
		// =====================================================================
		
		public float SucessRate;
		public float AttractRaduis;
		public float CheckAttractionTime = 10f;

		public Transform TargetPoint;

		public List<GameObject> GlobflobsInRange = new List<GameObject>();

		private bool isUIUp;
		private bool _wasPlaced = true;

		private GlobalVars _globalVars;

		public TrapTypes Type;
		
		// Unity
		// =====================================================================

		private void Start()
		{
			_globalVars = GlobalVars.instance;
			GetComponentInChildren<SphereCollider>().radius = AttractRaduis;
			InvokeRepeating("CheckAttraction", 5, CheckAttractionTime);
		}

		private void OnTriggerEnter(Collider other)
		{
			if (!other.gameObject.CompareTag("GlobFlob"))
				return;

			if (GlobflobsInRange.Contains(other.gameObject))
			{
				Globflob gf = other.GetComponent<Globflob>();
				if (gf == null)
					gf = other.transform.parent.GetComponent<Globflob>();
			
				gf.Capture();
			}
			else
			{
				GlobflobsInRange.Add(other.gameObject);
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (GlobflobsInRange.Contains(other.gameObject))
				GlobflobsInRange.Remove(other.gameObject);
		}

		/////////////////////////////////////////
		// Disabling upgrading because fuck it //
		/////////////////////////////////////////
		
		void OnMouseOver()
		{
//			if (isUIUp != true)
//			{
//				if (Input.GetMouseButtonUp(0))
//				{
//					MakeUIAppear();
//					isUIUp = true;
//				}
//			}
		}

//		void OnMouseExit()
//		{
//			if (isUIUp)
//			{
////          MakeUIDisappear();
//				isUIUp = false;
//			}
//		}
		
		// Actions
		// =====================================================================

		private void CheckAttraction()
		{
			for (int i = 0; i < GlobflobsInRange.Count; i++)
			{
				if (GlobflobsInRange[i] == null)
				{
					GlobflobsInRange.Remove(GlobflobsInRange[i]);
				}
				else if (Random.value <= SucessRate / 100)
				{
					Globflob gf = GlobflobsInRange[i].GetComponentInParent<Globflob>();

					if (gf != null)
						gf.setTarget(TargetPoint);
				}
			}
		}

		public void SetCatcherRaduis(float _raduis)
		{
			AttractRaduis += _raduis;
			GetComponentInChildren<SphereCollider>().radius = AttractRaduis;
			GetComponentInChildren<PulseEffect>().maxRadius = AttractRaduis;
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

		/// <summary>
		/// Scares the globflobs in range
		/// </summary>
		public void Scare()
		{
			Collider[] globflobsInRange = Physics.OverlapSphere(
				transform.position,
				AttractRaduis
			);
			
			int i = 0;
			while (i < globflobsInRange.Length)
			{
				Globflob gf = globflobsInRange[i].GetComponent<Globflob>();

				if (gf == null && globflobsInRange[i].transform.parent != null)
					globflobsInRange[i].transform.parent.GetComponent<Globflob>();

				if (gf != null)
					gf.RunAway(transform, AttractRaduis + 5f);
				
				i++;
			}
		}
		
	}
}
