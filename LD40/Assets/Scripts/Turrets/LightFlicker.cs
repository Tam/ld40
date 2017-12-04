using UnityEngine;

namespace Turrets
{
	public class LightFlicker : MonoBehaviour {

		private const float PI = Mathf.PI;

		public float amplitude = 1f;
		public float frequency = 0.5f;

		private Color originalColor;
		private Light _light;

		// Use this for initialization
		void Start () {
			_light = GetComponent<Light>();
			originalColor = _light.color;
		}
	
		void Update () {
			_light.color = originalColor * EvalWave();	
		}

		float EvalWave()
		{
			float x = (Time.time) * frequency;
			x = x - Mathf.Floor(x);
			float y = Mathf.Sin(x * 2 * PI);

			return (y * amplitude) + 1f;
		}
	}
}
