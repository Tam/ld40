using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class UIHud : MonoBehaviour {
		
		// Variables
		// =====================================================================

		public Text numUnprocessedGlobflobs;
		
		private GlobalVars _globalVars;
		
		// Unity
		// =====================================================================

		private void Start()
		{
			_globalVars = GlobalVars.instance;
			_globalVars.OnStatChangeCallback += OnStatChange;
		}
		
		// Events
		// =====================================================================

		private void OnStatChange(AvailableStats stat, int value)
		{
			switch (stat)
			{
				case AvailableStats.NumUnprocessedGlobflobs:
					numUnprocessedGlobflobs.text = value.ToString();
					break;
			}
		}
		
	}
}
