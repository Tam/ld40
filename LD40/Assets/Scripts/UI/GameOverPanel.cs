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
		
		// Events
		// =====================================================================

		public void OnMainMenuClick()
		{
			Debug.Log("MAIN MENU");
		}

		public void OnRestartClick()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

	}
}
