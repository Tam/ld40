using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlacement : MonoBehaviour
{
    GameObject PlacedTurret;

    public GameObject PlacementVector;

	private void OnMouseEnter()
    {
        if (Input.GetMouseButton(0))
        {
            //Make Build Buttons Interactable
            //Send Which Placement Platform is requesting Building
            GlobalVars.instance.uiManager.turretBuildUI.SetButtonInteractable(this, true);
        }
    }

    private void OnMouseExit()
    {
        if (Input.GetMouseButton(1))
        {
            //Make Build buttons UnInteractable
            GlobalVars.instance.uiManager.turretBuildUI.SetButtonInteractable(null, false);
        }
    }

    public void BuildTurret(GameObject _TurretToBuild)
    {
        PlacedTurret = Instantiate(_TurretToBuild, PlacementVector.transform.position, Quaternion.identity);
    }
}
