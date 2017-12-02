using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{

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
            //Start trying to place Object
            if (Input.GetMouseButtonDown(0))
            {
                //Fire Raycast from Camera To Mouse Position
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit Hit = new RaycastHit();

                Debug.DrawRay(ray.origin, ray.direction * 100, Color.green);


                if (Physics.Raycast(ray, out Hit, 100))
                {

                }
            }
        }
	}
}
