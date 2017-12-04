﻿using System.Collections.Generic;
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
		public Button buildTrapButton;

		public InspectionPanel inspectionPanel;
		public UpgradePanel upgradePanel;
		public BuildTurretPanel buildTurretPanel;
		public GameOverPanel gameOverPanel;

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
			buildTurretPanel.Hide();
			overlayButton.gameObject.SetActive(false);

			globalVars.OnMoneyChangeCallback += OnMoneyChange;
			globalVars.TrapPlacement.OnPlacingChangeCallback += OnPlacingChange;
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
		
		// Events: Internal
		// ---------------------------------------------------------------------

		private void OnMoneyChange(int money)
		{
			buildTrapButton.interactable = money >= globalVars.trapCost;
		}

		private void OnPlacingChange(bool isPlacing)
		{
			buildTrapButton.interactable = !isPlacing;
		}
		
		// Events: Buttons
		// ---------------------------------------------------------------------

		public void OnOverlayClick()
		{
			_isHidingAll = true;
			
			foreach (BasePanel panel in _panelsWithOverlay)
				panel.Hide();
			
			_panelsWithOverlay.Clear();
			overlayButton.gameObject.SetActive(false);
			
			_isHidingAll = false;
		}

		public void OnBuildTrapButtonClick()
		{
			globalVars.TrapPlacement.GameobjectToPlaceID = 1;
		}

	}
}
