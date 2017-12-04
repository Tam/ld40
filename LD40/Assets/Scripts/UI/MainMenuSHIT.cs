using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
	public class MainMenuSHIT : MonoBehaviour {
		
		// Actions
		// =====================================================================

		public void OnPlayClick()
		{
			SceneManager.LoadScene("Game");
		}

		public void OnExitClick()
		{
			Application.Quit();
		}
		
	}
}
