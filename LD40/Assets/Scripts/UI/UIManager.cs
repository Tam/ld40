using System.Collections.Generic;
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

		private readonly List<BasePanel> _panelsWithOverlay = new List<BasePanel>();

		// Unity
		// =====================================================================

		private void Awake()
		{
			// Make sure everything is hidden
			upgradePanel.Hide();
			gameOverPanel.Hide();
		}

		// Actions
		// =====================================================================

		public void AddPanelToOverlayList(BasePanel panel)
		{
			_panelsWithOverlay.Add(panel);
			overlayButton.gameObject.SetActive(true);
		}

		public void RemovePanelFromOverlayList(BasePanel panel)
		{
			_panelsWithOverlay.Remove(panel);
			if (_panelsWithOverlay.Count == 0)
				overlayButton.gameObject.SetActive(false);
		}

		public void ShowGameOver(float score)
		{
			gameOverPanel.scoreText.text = score + "";
			gameOverPanel.Show();
			
			// Pause the game
			globalVars.Pause();
		}
		
		// Events
		// =====================================================================

		public void OnOverlayClick()
		{
			foreach (BasePanel panel in _panelsWithOverlay)
				panel.Hide();
		}

	}
}
