using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class QuotaPanel : MonoBehaviour
	{
		
		// Variables
		// =====================================================================

		public Slider slider;
		
		private GlobalVars _globalVars;
		
		// Unity
		// =====================================================================

		private void Start()
		{
			_globalVars = GlobalVars.instance;
		}

		private void LateUpdate()
		{
			float current = _globalVars.quota.currentQuota;
			float max = _globalVars.quota.maxQuota;
			
			slider.value = current / max;
		}
		
	}
}
