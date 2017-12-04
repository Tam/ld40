using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
	public class GameOverPanel : BasePanel
	{
		
		// Variables
		// =====================================================================

		public Text scoreText;

		public Text reasonText;
		
		// Unity
		// =====================================================================

		private void Awake()
		{
			showWithOverlay = false;
		}

		// Events
		// =====================================================================

		public void OnMainMenuClick()
		{
			SceneManager.LoadScene("MainMenu");
		}

		public void OnRestartClick()
		{
			globalVars.UnPause();
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

	}
}
