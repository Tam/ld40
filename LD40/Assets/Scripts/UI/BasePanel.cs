using UnityEngine;

namespace UI
{
	public class BasePanel : MonoBehaviour
	{
		protected GlobalVars globalVars;
		
		protected bool showWithOverlay = true;

		// Actions
		// =====================================================================

		public virtual void Show()
		{
			SetActive(true);
			
			if (showWithOverlay)
				globalVars.uiManager.AddPanelToOverlayList(this);
		}

		public virtual void Hide()
		{
			if (showWithOverlay && globalVars != null)
				globalVars.uiManager.RemovePanelFromOverlayList(this);
			
			SetActive(false);
		}

		private void SetActive(bool active)
		{
			gameObject.SetActive(active);
			
			if (active && globalVars == null)
				globalVars = GlobalVars.instance;
		}
		
	}
}
