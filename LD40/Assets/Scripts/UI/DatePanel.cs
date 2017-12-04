using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class DatePanel : MonoBehaviour
	{
		
		// Variables
		// =====================================================================
		
		public Text date;
		
		private GlobalVars _globalVars;

		private readonly string[] _months = {
			"Janbuggery",
			"Floobtoober",
			"Marrakesh",
			"Avril Lavigne",
			"Mayshoop",
			"Junbug",
			"Julyia Childs",
			"Augustsusus",
			"Septembre",
			"Octagon",
			"Nova Scotia",
			"Christmas",
		};
		
		// Unity
		// =====================================================================

		private void Start()
		{
			_globalVars = GlobalVars.instance;
		}

		private void LateUpdate()
		{
			string month = _months[(_globalVars.month - 1) % 12];
			string day = _globalVars.day + Helpers.DateSuffix(_globalVars.day);
			
			date.text = day + " of " + month;
		}
		
	}
}
