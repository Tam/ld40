using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    public bool Placing = false;

    public int TurretToPlaceID = 100;
    public GameObject[] TurretHolo;
    public GameObject[] TurretsToPlace;

    Vector3 Default = new Vector3(0, -2, 0);
    PlacementCollision PC;
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
             TurretToPlaceID = 0;
        }

        if (TurretToPlaceID != 100)
        {
            //Fire Raycast from Camera To Mouse Position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit = new RaycastHit();

            Debug.DrawRay(ray.origin, ray.direction * 100, Color.green);

            if (Physics.Raycast(ray, out Hit, 100, 1 << 3))
            {
                Vector3 HitPos = new Vector3(Hit.point.x, 0.5f, Hit.point.z);

                if (PC == null)
                {
                    PC = TurretHolo[TurretToPlaceID].GetComponent<PlacementCollision>();
                }

                TurretHolo[TurretToPlaceID].transform.position = HitPos;

                if(!PC.IsColliding)
                {
                    TurretHolo[TurretToPlaceID].GetComponent<Renderer>().material.color = Color.green;

                    if (Input.GetMouseButtonDown(0))
                    {
                        TurretHolo[TurretToPlaceID].transform.position = Default;
                        Instantiate(TurretsToPlace[TurretToPlaceID], HitPos, Quaternion.identity);
                        TurretToPlaceID = 100;                      
                    }
                }
                else
                {
                    TurretHolo[TurretToPlaceID].GetComponent<Renderer>().material.color = Color.red;

                    if (Input.GetMouseButtonDown(0))
                    {
                        Debug.Log("Ermmm There is something in the way bro !!");
                    }
                }
                //Start trying to place Object
               
            }        
        }
	}
}
