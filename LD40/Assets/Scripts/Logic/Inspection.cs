using UI;
using UnityEngine;

namespace Logic
{
	[RequireComponent(typeof(GlobalVars))]
	public class Inspection : MonoBehaviour
	{
		
		// Variables
		// =====================================================================

		[HideInInspector] 
		public GlobalVars globalVars;

		private int _bribe = 100;
		public int bribe
		{
			get { return _bribe; }
		}

		// Actions
		// =====================================================================

		public void TriggerInspector()
		{
			InspectionPanel panel = globalVars.uiManager.inspectionPanel;

			if (globalVars.money < _bribe)
				panel.bribeButton.interactable = false;
			
			panel.bribeButtonText.text = "Bribe £" + _bribe;
			panel.Show();
			
			globalVars.Pause();
		}
		
		// Events
		// =====================================================================

		public void OnBribe()
		{
			globalVars.DecreaseMoney(_bribe);
			globalVars.socialBuzz.ClearBuzz();
			globalVars.uiManager.inspectionPanel.Hide();
			globalVars.UnPause();

			_bribe = (int) (_bribe * 1.5f);
		}

		public void OnInspection()
		{
			globalVars.uiManager.inspectionPanel.Hide();
			globalVars.uiManager.ShowGameOver("Allowed an inspection");
		}

	}
}
