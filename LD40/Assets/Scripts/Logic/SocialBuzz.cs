using UnityEngine;

namespace Logic
{
	[RequireComponent(typeof(GlobalVars))]
	public class SocialBuzz : MonoBehaviour
	{
		
		// Variables
		// =====================================================================

		[HideInInspector]
		public GlobalVars globalVars;

		/// <summary>
		/// The number of protesters per 1 buzz
		/// </summary>
		public float protestersToBuzz = 0.1f;

		private float _maxSocialBuzz = 100;
		public float maxSocialBuzz
		{
			get { return _maxSocialBuzz; }
		}

		private float _currentSocialBuzz;
		public float currentSocialBuzz
		{
			get { return _currentSocialBuzz; }
		}
		
		// Unity
		// =====================================================================

		private void Start()
		{
			// Increase the buzz every 5s
			InvokeRepeating("MoreBuzz", 0f, 5f);
		}
		
		// Actions
		// =====================================================================

		/// <summary>
		/// Clears the social buzz (fired when the fuzz is bribed)
		/// </summary>
		public void ClearBuzz()
		{
			_currentSocialBuzz = 0;
		}

		private void MoreBuzz()
		{
			int protesters = globalVars.currentProtesters;
			_currentSocialBuzz += protesters * protestersToBuzz;
			
			if (_currentSocialBuzz >= _maxSocialBuzz)
				globalVars.inspection.TriggerInspector();
		}
		
	}
}
