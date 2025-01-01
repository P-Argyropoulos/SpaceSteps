using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[CreateAssetMenu]
public class StationShieldPowerUp : PowerUps
{
    public override void Activate(GameObject spaceStation)
    {
        spaceStation.transform.GetChild(1).gameObject.SetActive(true);
    }

    public override void BeginCooldowm(GameObject spaceStation)
    {
        spaceStation.transform.GetChild(1).gameObject.SetActive(false);
    }

}
