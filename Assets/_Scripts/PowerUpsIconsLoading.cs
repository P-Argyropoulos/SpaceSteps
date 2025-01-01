using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpsIconsLoading : MonoBehaviour
{
    public Image imageSpeed, imageShield;

    public class PowerUpInfo
    {
        public float activetime { get; set; }
        public float cooldowntime { get; set; }
        public Image icon { get; set; }
    }

    private Dictionary<string, PowerUpInfo> PowerUpDictionary = new();

    private void OnEnable()
    {
        EventHandler.OnPowerUpUsage += IconBuffering;
    }

    private void OnDisable()
    {
        EventHandler.OnPowerUpUsage -= IconBuffering;
    }

    void Update()
    {
        foreach (var powerUp in PowerUpDictionary.Values)
        {
            if ( powerUp.icon.fillAmount < 1)
            {
                powerUp.icon.fillAmount += 1f / powerUp.cooldowntime * Time.deltaTime;
             
            }
        }
    }

    private void IconBuffering(PowerUps ability)
    {
        if (!PowerUpDictionary.ContainsKey(ability.powerupName))
        {
            if (ability.powerupName.Equals("SpeedUp"))
            {
                PowerUpDictionary.Add(ability.powerupName, new PowerUpInfo{ activetime = ability.powerupActiveTime, cooldowntime = ability.powerupCoolDownTime, icon = imageSpeed });
            }
            else if (ability.powerupName.Equals("SpaceStationShield"))
            {
                PowerUpDictionary.Add(ability.powerupName, new PowerUpInfo{ activetime = ability.powerupActiveTime, cooldowntime = ability.powerupCoolDownTime, icon = imageShield });
            }
        }

        var powerUpInfo = PowerUpDictionary[ability.powerupName];
        StartCoroutine(HandleActiveTime(powerUpInfo));
    }

    private IEnumerator HandleActiveTime(PowerUpInfo powerUpInfo)
    {
        yield return new WaitForSeconds(powerUpInfo.activetime);
        powerUpInfo.icon.fillAmount = 0f;
      
    }
}



