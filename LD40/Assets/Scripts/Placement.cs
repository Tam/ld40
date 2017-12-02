using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    public bool Placing = false;

    public int GameobjectToPlaceID = 100;
    public GameObject[] GameobjectHolo;
    public GameObject[] GameobjectToPlace;

    public int numberOfTurrets;

    Vector3 Default = new Vector3(0, -2, 0);
    PlacementCollision PC;

    public LayerMask TurretMask;
    public LayerMask TrapMask;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Go into Placement Mode.
        if (Input.GetKeyUp(KeyCode.T))
        {
            GameobjectToPlaceID = 0;
        }

        if (GameobjectToPlaceID != 100)
        {
            //Fire Raycast from Camera To Mouse Position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit = new RaycastHit();

            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);

            LayerMask Mask;

            if(GameobjectToPlaceID > numberOfTurrets)
            {
                Mask = TrapMask;
            }
            else
            {
                Mask = TurretMask;
            }

            if (Physics.Raycast(ray, out Hit, 1000, Mask))
            {
                Vector3 HitPos = new Vector3(Hit.point.x, 0.5f, Hit.point.z);

                if (PC == null)
                {
                    PC = GameobjectHolo[GameobjectToPlaceID].GetComponent<PlacementCollision>();
                }

                GameobjectHolo[GameobjectToPlaceID].transform.position = HitPos;

                if (!PC.IsColliding)
                {
                    GameobjectHolo[GameobjectToPlaceID].GetComponent<Renderer>().material.color = Color.green;

                    if (Input.GetMouseButtonDown(0))
                    {
                        GameobjectHolo[GameobjectToPlaceID].transform.position = Default;
                        Instantiate(GameobjectToPlace[GameobjectToPlaceID], HitPos, Quaternion.identity);
                        GameobjectToPlaceID = 100;
                    }
                }
                else
                {
                    GameobjectHolo[GameobjectToPlaceID].GetComponent<Renderer>().material.color = Color.red;

                    if (Input.GetMouseButtonDown(0))
                    {
                        Debug.Log("Ermmm There is something in the way bro !!");
                    }
                }
            }        
        }
	}
}
