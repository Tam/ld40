using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	[RequireComponent(typeof(RectTransform))]
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

		private RectTransform _rect;
		
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
		
		// Unity
		// =====================================================================

		private void Awake()
		{
			if (_rect == null)
				_rect = GetComponent<RectTransform>();
		}

		private void Update()
		{
			if (enabled && Input.GetKeyDown(KeyCode.Escape))
				Hide();
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
			Transform target,
			string name,
			UIStat stat1,
			UIStat stat2,
			UIStat stat3
		) {
			SetName(name);
			SetStats(stat1, stat2, stat3);
			Show();
			SetTarget(target);
		}

		public void SetTarget(Transform trans)
		{
			Vector3 pos = Camera.main.WorldToScreenPoint(trans.position);
			float h = _rect.rect.height;
			float offset = h / 2f + 10f;

			if (pos.y <= h)
				pos.y += offset;
			else
				pos.y -= offset;
			
			transform.position = pos;
		}
		
	}
}
