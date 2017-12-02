using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementCollision : MonoBehaviour
{
    public bool IsColliding;

    void OnTriggerEnter(Collider collider)
    {
        IsColliding = true;
    }

    void OnTriggerExit(Collider collider)
    {
        IsColliding = false;
    }
}
