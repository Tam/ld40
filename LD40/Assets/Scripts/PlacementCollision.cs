using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementCollision : MonoBehaviour
{
    public bool IsColliding;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "GlobFlob" || collider.gameObject.tag == "Protester" || collider.gameObject.tag == "Trap" || collider.gameObject.tag == "Turret")
            IsColliding = true;
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "GlobFlob" || collider.gameObject.tag == "Protester" || collider.gameObject.tag == "Trap" || collider.gameObject.tag == "Turret")
            IsColliding = false;
    }
}
