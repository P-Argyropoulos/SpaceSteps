using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventHandler
{
    public static event Action<float> OnPointAddition;
    public static event Action<int> OnDamageTaken;
    public static event Action<PowerUps> OnPowerUpUsage;

    public static event Action OnLowCredits;
     

    public static void TriggerPointAdditionEvent(float points)
    {
        OnPointAddition?.Invoke(points);
    }
    public static void HealthUpdateEvent(int damage)
    {
        OnDamageTaken?.Invoke(damage);
    }
    public static void PowerUpIconsBufferingEvent(PowerUps ability)
    {
        OnPowerUpUsage?.Invoke(ability);

    }
    public static void DisplayCreditsMessage()
    {
        OnLowCredits?.Invoke();
    }

}
