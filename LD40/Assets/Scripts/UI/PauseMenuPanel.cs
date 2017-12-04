using UnityEngine.SceneManagement;

namespace UI
{
	public class PauseMenuPanel : BasePanel
	{
		
		// Actions
		// =====================================================================

		public override void Show()
		{
			base.Show();
			globalVars.Pause();
		}

		public override void Hide()
		{
			base.Hide();
			if (globalVars != null)
				globalVars.UnPause();
		}

		public void OnResumeClick()
		{
			Hide();
		}

		public void OnMainMenuClick()
		{
			SceneManager.LoadScene("MainMenu");
		}
		
	}
}
