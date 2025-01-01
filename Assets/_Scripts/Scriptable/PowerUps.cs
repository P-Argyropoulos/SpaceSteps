
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : ScriptableObject
{
    public string powerupName;
    public float powerupActiveTime;
    public float powerupCoolDownTime;

    public float  activationCredits;
    public virtual void Activate(GameObject parent){}

    public virtual void BeginCooldowm(GameObject parent){}

}

   
