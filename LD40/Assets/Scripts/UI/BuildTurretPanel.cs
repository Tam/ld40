using Turrets;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class BuildTurretPanel : BasePanel
	{
		
		// Variables
		// =====================================================================

		public Button beanBagButton;
		public Button waterButton;
		public Button laserButton;

		private GlobalVars _globalVars;
		private TurretPlacement _target;

		// Actions
		// =====================================================================

		public void Show(TurretPlacement target)
		{
			if (_globalVars == null)
				_globalVars = GlobalVars.instance;
			
			_target = target;
			UpdateAvailability();
			base.Show();
		}

		private void UpdateAvailability()
		{
			float money = _globalVars.money;
			
			float beanBagCost = _globalVars.beanBagCost;
			float waterCost = _globalVars.waterCost;
			float laserCost = _globalVars.laserCost;

			beanBagButton.interactable = beanBagCost <= money;
			waterButton.interactable = waterCost <= money;
			laserButton.interactable = laserCost <= money;
		}
		
		// Events
		// =====================================================================

		public void OnBuildBeanBagClick(GameObject turret)
		{
			_target.BuildTurret(turret);
			_globalVars.DecreaseMoney(_globalVars.beanBagCost);
			Hide();
		}

		public void OnBuildWaterClick(GameObject turret)
		{
			_target.BuildTurret(turret);
			_globalVars.DecreaseMoney(_globalVars.waterCost);
			Hide();
		}

		public void OnBuildLaserClick(GameObject turret)
		{
			_target.BuildTurret(turret);
			_globalVars.DecreaseMoney(_globalVars.laserCost);
			Hide();
		}

		public void OnCancelClick()
		{
			Hide();
		}
		
	}
}
