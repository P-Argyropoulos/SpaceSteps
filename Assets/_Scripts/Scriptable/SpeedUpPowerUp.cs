using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class SpeedUpPowerUp : PowerUps
{
   public float speed;
    
    public override void Activate(GameObject parent)
    { 

        PlayerController player = parent.GetComponent<PlayerController>();
        GameObject boostEngines = parent.transform.GetChild(0).gameObject;

        boostEngines.SetActive(true);
        player.forwardSpeed = speed;
        
    }

    public override void BeginCooldowm(GameObject parent)
    {
        PlayerController player = parent.GetComponent<PlayerController>();
        GameObject boostEngines = parent.transform.GetChild(0).gameObject;
        
        boostEngines.SetActive(false);
        player.forwardSpeed = player.normalSpeed;
        
    }

}
