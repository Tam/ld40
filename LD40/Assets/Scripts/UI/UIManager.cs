using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class UIManager : MonoBehaviour
	{
		
		// Variables
		// =====================================================================

		[HideInInspector]
		public GlobalVars globalVars;

		public Button overlayButton;

		public InspectionPanel inspectionPanel;
		public UpgradePanel upgradePanel;
		public GameOverPanel gameOverPanel;

		public TurretBuildUI turretBuildUI;


		private readonly List<BasePanel> _panelsWithOverlay = new List<BasePanel>();

		private bool _isHidingAll;

		// Unity
		// =====================================================================

		private void Start()
		{
			// Make sure everything is hidden
			upgradePanel.Hide();
			inspectionPanel.Hide();
			gameOverPanel.Hide();
			overlayButton.gameObject.SetActive(false);
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
			if (_isHidingAll)
				return;
			
			_panelsWithOverlay.Remove(panel);
			if (_panelsWithOverlay.Count == 0)
				overlayButton.gameObject.SetActive(false);
		}

		public void ShowGameOver(string reason)
		{
			// Show game over screen
			gameOverPanel.scoreText.text = globalVars.score + "";
			gameOverPanel.reasonText.text = reason;
			gameOverPanel.Show();
			
			// Pause the game
			globalVars.Pause();
		}
		
		// Events
		// =====================================================================

		public void OnOverlayClick()
		{
			_isHidingAll = true;
			
			foreach (BasePanel panel in _panelsWithOverlay)
				panel.Hide();
			
			_panelsWithOverlay.Clear();
			overlayButton.gameObject.SetActive(false);
			
			_isHidingAll = false;
		}

	}
}
