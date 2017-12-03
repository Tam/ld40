using UnityEngine;

namespace UI
{
	public class BasePanel : MonoBehaviour
	{

		protected GlobalVars _globalVars;
		
		protected bool showWithOverlay = true;
	
		// Actions
		// =====================================================================

		public void Show()
		{
			if (_globalVars == null)
				_globalVars = GlobalVars.instance;
			
			if (showWithOverlay)
				_globalVars.uiManager.ShowOverlay();
			
			gameObject.SetActive(true);
		}

		public void Hide()
		{
			gameObject.SetActive(false);
		}
		
	}
}
