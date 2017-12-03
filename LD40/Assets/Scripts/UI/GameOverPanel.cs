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
			// TODO: Main Menu Button
			Debug.Log("MAIN MENU");
		}

		public void OnRestartClick()
		{
			globalVars.UnPause();
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

	}
}
