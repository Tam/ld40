using UnityEngine;

namespace Traps
{
	public class PlacementCollision : MonoBehaviour
	{
		public bool IsColliding;

		void OnTriggerEnter(Collider cldr)
		{
			if (!cldr.gameObject.CompareTag("Untagged"))
				IsColliding = true;
			
//			if (cldr.gameObject.CompareTag("GlobFlob") ||
//			    cldr.gameObject.CompareTag("Protester") ||
//			    cldr.gameObject.CompareTag("Trap") || 
//			    cldr.gameObject.CompareTag("Turret"))
//				IsColliding = true;
		}

		void OnTriggerExit(Collider cldr)
		{
			if (!cldr.gameObject.CompareTag("Untagged"))
				IsColliding = false;
			
//			if (cldr.gameObject.CompareTag("GlobFlob") ||
//			    cldr.gameObject.CompareTag("Protester") ||
//			    cldr.gameObject.CompareTag("Trap") || 
//			    cldr.gameObject.CompareTag("Turret"))
//				IsColliding = false;
		}
	}
}
