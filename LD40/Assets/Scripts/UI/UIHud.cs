using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class UIHud : MonoBehaviour {
		
		// Variables
		// =====================================================================

		public Text numUnprocessedGlobflobs;
		public Text svuTotal;
		public Text monthlyQuota;
		public Text money;
		public Text buzz;
		public Text protesters;
		public Text globflobs;
		
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

			monthlyQuota.text = _globalVars.quota.currentQuota + " / " + 
			                    _globalVars.quota.maxQuota;

			money.text = _globalVars.money + "";

			buzz.text = _globalVars.socialBuzz.currentSocialBuzz + " / " +
			            _globalVars.socialBuzz.maxSocialBuzz;

			protesters.text = _globalVars.currentProtesters + " / " +
			                  _globalVars.maxProtesters;

			globflobs.text = _globalVars.currentGlobflobs + " / " +
			                 _globalVars.maxGlobflobs;
		}
		
	}
}
