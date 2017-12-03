using UnityEngine;

namespace Logic
{
	public class Quota : MonoBehaviour
	{
		
		// Variables
		// =====================================================================
		
		[HideInInspector]
		public GlobalVars globalVars;

		private int _currentQuota;
		public int currentQuota
		{
			get { return _currentQuota; }
		}

		private int _maxQuota;
		public int maxQuota
		{
			get { return _maxQuota; }
		}
		
		// Actions
		// =====================================================================

		public void IncreaseCurrentQuota(int amount)
		{
			_currentQuota += amount;
			
			// TODO: If above max quota, get bonus score
		}

		public void CheckQuotaReached()
		{
			if (_currentQuota >= _maxQuota)
			{
				_currentQuota = 0;
				_maxQuota = Mathf.CeilToInt(_maxQuota * 1.2f);
				return;
			}
			
			Debug.Log("Game over, man! Game over! (TODO)");
		}
		
	}
}
