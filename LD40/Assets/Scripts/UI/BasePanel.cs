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
			SetActive(true);
			
			if (showWithOverlay)
				_globalVars.uiManager.AddPanelToOverlayList(this);
		}

		public void Hide()
		{
			if (showWithOverlay && _globalVars != null)
				_globalVars.uiManager.RemovePanelFromOverlayList(this);
			
			SetActive(false);
		}

		private void SetActive(bool active)
		{
			gameObject.SetActive(active);
			
			if (active && _globalVars == null)
				_globalVars = GlobalVars.instance;
		}
		
	}
}
