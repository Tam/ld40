using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretBuildUI : MonoBehaviour
{
    TurretPlacement turretPlacement;

    public Button TurretOne;
    public Button TurretTwo;
    public Button TurretThree;

    public void Start ()
    {
        TurretOne.interactable = false;
        TurretTwo.interactable = false;
        TurretThree.interactable = false;
    }

    public void SetButtonInteractable(TurretPlacement _turretPlacement, bool _condiction)
    {
        turretPlacement = _turretPlacement;

        TurretOne.interactable = _condiction;
        TurretTwo.interactable = _condiction;
        TurretThree.interactable = _condiction;
    }

	public void OnClickTurret1(GameObject _TurretOne)
    {
        turretPlacement.BuildTurret(_TurretOne);
    }

    public void OnClickTurret2(GameObject _TurretTwo)
    {
        turretPlacement.BuildTurret(_TurretTwo);
    }

    public void OnClickTurret3(GameObject _TurretThree)
    {
        turretPlacement.BuildTurret(_TurretThree);
    }
}
