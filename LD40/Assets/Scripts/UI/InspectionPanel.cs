using UnityEngine.UI;

namespace UI
{
	public class InspectionPanel : BasePanel
	{
		
		// Variables
		// =====================================================================

		public Button bribeButton;
		public Text bribeButtonText;
		
		// Unity
		// =====================================================================

		private void Awake()
		{
			showWithOverlay = false;
		}

	}
}
