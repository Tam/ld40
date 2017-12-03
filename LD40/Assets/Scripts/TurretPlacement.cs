using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlacement : MonoBehaviour
{
    GameObject PlacedTurret;

    public GameObject PlacementVector;

    private bool _mouseOver;

    private void Update()
    {
        if (_mouseOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Make Build Buttons Interactable
                //Send Which Placement Platform is requesting Building
                GlobalVars.instance.uiManager.turretBuildUI.SetButtonInteractable(this, true);
            }
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            //Make Build buttons UnInteractable
            GlobalVars.instance.uiManager.turretBuildUI.SetButtonInteractable(null, false);
        }
    }

	private void OnMouseOver()
	{
	    _mouseOver = true;
	}

    private void OnMouseExit()
    {
        _mouseOver = false;
    }

    public void BuildTurret(GameObject _TurretToBuild)
    {
        PlacedTurret = Instantiate(_TurretToBuild, PlacementVector.transform.position, Quaternion.identity);
    }
}
