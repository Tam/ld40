using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class UIManager : MonoBehaviour
	{
		
		// Variables
		// =====================================================================

		public GlobalVars globalVars;

		public Button overlayButton;
		
		public UpgradePanel upgradePanel;

		public GameOverPanel gameOverPanel;
		
		// Unity
		// =====================================================================

		private void Awake()
		{
			// Make sure everything is hidden
			upgradePanel.Hide();
			gameOverPanel.Hide();
			
			// TODO: When opening a panel w/ overlay, add panel to overlay list
			// TODO: When closing panel, remove from overlay list (hide overlay if list now empty)
			// TODO: On overlay click close all panels in overlay list
		}

		// Actions
		// =====================================================================

		public void ShowOverlay()
		{
			overlayButton.gameObject.SetActive(true);
		}

		public void HideOverlay()
		{
			overlayButton.gameObject.SetActive(false);
		}

		public void ShowGameOver(float score)
		{
			gameOverPanel.scoreText.text = score + "";
			gameOverPanel.Show();
			
			// Pause the game
			globalVars.Pause();
		}

	}
}
