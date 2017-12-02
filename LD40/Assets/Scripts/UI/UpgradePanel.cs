using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class UpgradePanel : MonoBehaviour
	{
		
		// Variables
		// =====================================================================

		public new Text name;
		
		public Text stat1Label;
		public Text stat1Value;

		public Text stat2Label;
		public Text stat2Value;

		public Text stat3Label;
		public Text stat3Value;
		
		// Setters
		// =====================================================================

		public void SetName(string name)
		{
			this.name.text = name;
		}

		public void SetStats(UIStat stat1, UIStat stat2, UIStat stat3)
		{
			setStat1(stat1);
			setStat2(stat2);
			setStat3(stat3);
		}

		public void setStat1(UIStat stat)
		{
			stat1Label.text = stat.name;
			stat1Value.text = stat.value;
		}

		public void setStat2(UIStat stat)
		{
			stat2Label.text = stat.name;
			stat2Value.text = stat.value;
		}

		public void setStat3(UIStat stat)
		{
			stat3Label.text = stat.name;
			stat3Value.text = stat.value;
		}
		
		// Actions
		// =====================================================================

		public void Show()
		{
			gameObject.SetActive(true);
		}

		public void Hide()
		{
			gameObject.SetActive(false);
		}

		public void SetAndShow(
			string name,
			UIStat stat1,
			UIStat stat2,
			UIStat stat3
		) {
			SetName(name);
			SetStats(stat1, stat2, stat3);
			Show();
		}
		
	}
}
