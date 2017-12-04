using UnityEngine;

namespace Turrets
{
    public class TurretPlacement : MonoBehaviour
    {

        // Variables
        // =====================================================================
        
        private GlobalVars _globalVars;
        
        GameObject PlacedTurret;

        public GameObject PlacementVector;

        private bool _mouseOver;
        
        // Unity
        // =====================================================================

        private void Start()
        {
            _globalVars = GlobalVars.instance;
        }

        private void Update()
        {
            if (_mouseOver && Input.GetMouseButtonDown(0) && PlacedTurret == null)
            {
                //Make Build Buttons Interactable
                //Send Which Placement Platform is requesting Building
                if (PlacedTurret == null)
                    _globalVars.uiManager.buildTurretPanel.Show(this);
            }
        }

        private void OnMouseEnter()
        {
            _mouseOver = true;
        }

        private void OnMouseExit()
        {
            _mouseOver = false;
        }

        // Actions
        // =====================================================================
        
        public void BuildTurret(GameObject _TurretToBuild)
        {
            PlacedTurret = Instantiate(_TurretToBuild, PlacementVector.transform.position, Quaternion.identity);
        }
    }
}
