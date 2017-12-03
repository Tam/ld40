using UnityEngine;

namespace Logic
{
	public class Quota : MonoBehaviour
	{
		
		// Variables
		// =====================================================================
		
		[HideInInspector]
		public GlobalVars globalVars;

		public float monthlyQuotaMultiplier = 1.75f;

		private int _currentQuota;
		public int currentQuota
		{
			get { return _currentQuota; }
		}

		private int _maxQuota = 10;
		public int maxQuota
		{
			get { return _maxQuota; }
		}
		
		// Actions
		// =====================================================================

		public void IncreaseCurrentQuota(int amount)
		{
			_currentQuota += amount;

			if (!globalVars.scoreBonus)
				if (_currentQuota > _maxQuota)
					globalVars.scoreBonus = true;
		}

		public void CheckQuotaReached()
		{
			if (_currentQuota >= _maxQuota)
			{
				_currentQuota = 0;
				globalVars.scoreBonus = false;
				_maxQuota = Mathf.CeilToInt(_maxQuota * monthlyQuotaMultiplier);
				return;
			}
			
			globalVars.uiManager.ShowGameOver("Failed to meet monthly quota");
		}
		
	}
}
