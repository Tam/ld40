using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class StatsPanel : MonoBehaviour
	{
		
		// Variables
		// =====================================================================
		
		public Text numUnprocessedGlobflobs;
		public Text svuTotal;
		public Text money;
		
		private GlobalVars _globalVars;
		
		// Unity
		// =====================================================================

		private void Start()
		{
			_globalVars = GlobalVars.instance;
		}

		private void LateUpdate()
		{
			// Updating UI values
			// For efficency we should be using events, not updating every frame
			// butt fuck it
			numUnprocessedGlobflobs.text = _globalVars.unprocessedGlobflobs + "";

			svuTotal.text = _globalVars.supervaluableunobtainiumAquiredTotal + "";

			money.text = "£" + _globalVars.money;
		}
		
	}
}
