using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUpHolder : MonoBehaviour
{
    public PowerUps speedAbility, shieldAbility;
    private float speedcoolDownTime, shieldcoolDownTime;
    private float speedactiveTime, shieldactiveTime;
    private GameObject spaceStation;

    enum AbilityState
    {
        active,
        ready,
        cooldown
    }

    AbilityState state = AbilityState.ready;

    AbilityState stationState = AbilityState.ready;
    public KeyCode keyShift;
    public KeyCode keyG;

    //private bool isPowerupActive = false;

    private void OnEnable()
    {
        spaceStation = GameObject.Find("SpaceStation");
    }
    private void Update()
    {
        // Speed Boost case
        switch (state)
        {
            case AbilityState.ready:
                if (Input.GetKeyDown(keyShift)){
                    if (GameManager.instance.pointSummary >= speedAbility.activationCredits)
                    { 
                        EventHandler.TriggerPointAdditionEvent(-speedAbility.activationCredits);
                        EventHandler.PowerUpIconsBufferingEvent(speedAbility);
                        speedAbility.Activate(gameObject);
                       
                        state = AbilityState.active;
                        speedactiveTime = speedAbility.powerupActiveTime;
                    }else
                    {
                        EventHandler.DisplayCreditsMessage();
                    }
                }
            break;

            case AbilityState.cooldown:
                if (speedcoolDownTime > 0)
                {
                    speedcoolDownTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.ready;   
                }
            break;

            case AbilityState.active:
                
                if (speedactiveTime > 0)
                {
                    speedactiveTime -= Time.deltaTime;
                }
                else
                {
                    speedAbility.BeginCooldowm(gameObject);
                    state = AbilityState.cooldown;
                    speedcoolDownTime = speedAbility.powerupCoolDownTime;
                }
            break;
        }

        // Station Shield case
        switch (stationState)
        {
            case AbilityState.ready:
                if (Input.GetKeyDown(keyG))
                {
                    if (GameManager.instance.pointSummary >= shieldAbility.activationCredits)
                    {
                        EventHandler.TriggerPointAdditionEvent(-shieldAbility.activationCredits);
                        EventHandler.PowerUpIconsBufferingEvent(shieldAbility);
                        shieldAbility.Activate(spaceStation);
                        
                        stationState = AbilityState.active;
                        shieldactiveTime = shieldAbility.powerupActiveTime;
                    }else
                    {
                        EventHandler.DisplayCreditsMessage();
                    }
                }
            break;

            case AbilityState.cooldown:
                if (shieldcoolDownTime > 0)
                {
                    shieldcoolDownTime -= Time.deltaTime;
                }
                else
                {
                    stationState = AbilityState.ready;   
                }
            break;

            case AbilityState.active:
                
                if (shieldactiveTime > 0)
                {
                    shieldactiveTime -= Time.deltaTime;
                }
                else
                {
                    shieldAbility.BeginCooldowm(spaceStation);
                    stationState = AbilityState.cooldown;
                    shieldcoolDownTime = shieldAbility.powerupCoolDownTime;
                }
            break;
        }
    }
}
