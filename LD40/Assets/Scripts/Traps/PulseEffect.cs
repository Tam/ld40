using System.Runtime.Serialization.Formatters;
using UnityEngine;

namespace Traps
{
	[RequireComponent(typeof(LineRenderer))]
	public class PulseEffect : MonoBehaviour {

		// Variables
		// =====================================================================

		public int segments;
		public float maxRadius = 10f;
		public float speed = 0.1f;
		public Color color = Color.white;

		private float _radius;
		private LineRenderer _line;
		
		// Unity
		// =====================================================================

		private void Start()
		{
			_line = gameObject.GetComponent<LineRenderer>();
			_line.useWorldSpace = false;
		}

		private void Update()
		{
			_line.positionCount = segments + 1;
			CreatePoints();

			float alpha = 1f;
			
			if (_radius <= 0f)
				_radius = maxRadius;
			else
				_radius -= speed;

			float distFromEnd = maxRadius - _radius;
			if (distFromEnd <= 5f)
				alpha = distFromEnd / 5f;
			else if (distFromEnd >= maxRadius - 5f)
				alpha = (maxRadius - distFromEnd) / 5f;

			Color c = color;
			c.a = alpha;

			_line.startColor = c;
			_line.endColor = c;

		}
		
		// Actions
		// =====================================================================

		private void CreatePoints()
		{
			float angle = 0f;

			for (int i = 0; i < segments + 1; i++)
			{
				float x = Mathf.Sin(Mathf.Deg2Rad * angle);
				float z = Mathf.Cos(Mathf.Deg2Rad * angle);
				_line.SetPosition(i, new Vector3(x, 0f, z) * _radius);
				angle += 360f / segments;
			}
		}
		
	}
}
