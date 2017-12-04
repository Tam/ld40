using UnityEngine;

namespace Traps
{
	public class TrapPlacement : MonoBehaviour
	{
	
		// Variables
		// =====================================================================

		[HideInInspector]
		public GlobalVars globalVars;

		private int _gameobjectToPlaceID = 100;

		public int GameobjectToPlaceID
		{
			get { return _gameobjectToPlaceID; }
			set
			{
				_gameobjectToPlaceID = value;
				if (OnPlacingChangeCallback != null)
					OnPlacingChangeCallback.Invoke(value != 100);
			}
		}

		public GameObject[] GameobjectHolo;
		public GameObject[] GameobjectToPlace;

		public int numberOfTurrets;

		Vector3 Default = new Vector3(0, -2, 0);
		PlacementCollision PC;

		public LayerMask TurretMask;
		public LayerMask TrapMask;

		public delegate void OnPlacingChange(bool isPlacing);

		public OnPlacingChange OnPlacingChangeCallback;
	
		// Unity
		// =====================================================================

		// Update is called once per frame
		void Update()
		{
			//Go into Placement Mode.
			// SEE UIManager::OnBuildTrapButtonClick()
//        if (Input.GetKeyUp(KeyCode.T))
//        {
//            GameobjectToPlaceID = 1;
//        }

			if (GameobjectToPlaceID != 100)
			{
				//Fire Raycast from Camera To Mouse Position
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit Hit = new RaycastHit();

				//Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);

				LayerMask Mask;

				if (GameobjectToPlaceID > numberOfTurrets)
				{
					Mask = TrapMask;
				}
				else
				{
					Mask = TurretMask;
				}

				if (Physics.Raycast(ray, out Hit, 1000, Mask))
				{
					Vector3 HitPos = new Vector3(Hit.point.x, 0f, Hit.point.z);

					if (PC == null)
					{
						PC = GameobjectHolo[GameobjectToPlaceID]
							.GetComponent<PlacementCollision>();
					}

					GameobjectHolo[GameobjectToPlaceID].transform.position = HitPos;

					if (!PC.IsColliding)
					{
						GameobjectHolo[GameobjectToPlaceID].GetComponent<Renderer>().material.color
							= Color.green;

						if (Input.GetMouseButtonDown(0))
						{
							SpawnPlacable(HitPos);
						}
					}
					else
					{
						GameobjectHolo[GameobjectToPlaceID].GetComponent<Renderer>().material
							.color = Color.red;

						if (Input.GetMouseButtonDown(0))
						{
							Debug.Log("Ermmm There is something in the way bro !!");
						}
					}

					if (Input.GetMouseButtonDown(1))
					{
						GameobjectHolo[GameobjectToPlaceID].transform.position = Default;
						GameobjectToPlaceID = 100;
					}
				}
			}
		}
	
		// Actions
		// =====================================================================

		void SpawnPlacable(Vector3 _hitPos)
		{
			
			GameobjectHolo[GameobjectToPlaceID].transform.position = Default;
			GameObject trap = Instantiate(
				GameobjectToPlace[GameobjectToPlaceID], 
				_hitPos,
				Quaternion.identity
			);
			GameobjectToPlaceID = 100;
			
			trap.GetComponent<Trap>().Scare();
		
			globalVars.DecreaseMoney(globalVars.trapCost);
		}
	}
}
