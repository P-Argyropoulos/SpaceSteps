using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBarScript : MonoBehaviour
{
    public Slider healthSlider;
    private void Awake()
    {
        healthSlider.value = GameObject.Find("Game Manager").GetComponent<GameManager>().stationTotalHealth;  
    }
    private void OnEnable()
    {  
        EventHandler.OnDamageTaken += SpaceStationHealth;   
    }

    private void OnDisable()
    {
        EventHandler.OnDamageTaken -= EventHandler.HealthUpdateEvent;
    }

    private void SpaceStationHealth(int damage)
    {
        healthSlider.value -= damage;
        
    }
    
}
