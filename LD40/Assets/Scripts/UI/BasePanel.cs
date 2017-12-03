using UnityEngine;

namespace UI
{
	public class BasePanel : MonoBehaviour
	{
		private GlobalVars _globalVars;
		
		protected bool showWithOverlay = true;
	
		// Actions
		// =====================================================================

		public void Show()
		{
			if (_globalVars == null)
				_globalVars = GlobalVars.instance;

			if (showWithOverlay)
				_globalVars.uiManager.AddPanelToOverlayList(this);
			
			gameObject.SetActive(true);
		}

		public void Hide()
		{
			if (showWithOverlay)
				_globalVars.uiManager.RemovePanelFromOverlayList(this);
			
			gameObject.SetActive(false);
		}
		
	}
}
