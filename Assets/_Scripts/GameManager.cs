using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set;} 

    public List<GameObject> asteroidList;
    public int stationTotalHealth = 2000;
    public int stationCurrentHealth;
    private GameObject asteroidPrefab, spawnerPoint, spaceStation;
    private Rigidbody asteroidRb;
    public float meteorLaunchSpeed = 100.0f , pointSummary = 0;
    public GameObject[] spawners;
    private bool dmgVFXbool1 = false, dmgVFXbool2 = false;

    private void Awake()
    {
        if ( instance != null && instance != this )
        {
            Destroy(this);
        }else
        {
            instance = this;
        }
        
    }
    
    private void OnEnable()
    {
        EventHandler.OnPointAddition += TotalPointCalculatorFunc;
        EventHandler.OnDamageTaken += CurrentStationHealth;
    }
    private void OnDisable()
    {
        EventHandler.OnPointAddition -= TotalPointCalculatorFunc;
        EventHandler.OnDamageTaken -= CurrentStationHealth;
    }
    void Start()
    {
        stationCurrentHealth = stationTotalHealth;
        spaceStation = GameObject.Find("SpaceStation");
        StartCoroutine(MeteorSpawn());
        
    }

    IEnumerator MeteorSpawn()
    {
        while(true)
        {
            //Every 1 sec selects a random spawner obj (the asteroid spawn origin) from spawner matrix and 
            //adding force and torque to a random asteroid prefab from the asteroid list
            yield return new WaitForSeconds(1.0f);
            spawnerPoint = spawners[Random.Range(0,7)];
                
            asteroidPrefab = Instantiate(asteroidList[Random.Range(0,asteroidList.Count)], spawnerPoint.transform.position, Random.rotation);
            
            asteroidRb = asteroidPrefab.GetComponent<Rigidbody>();

            asteroidRb.AddForce((spaceStation.transform.position - spawnerPoint.transform.position + new Vector3(0, Random.Range(-300, 300), Random.Range(-500, 500))) * meteorLaunchSpeed, ForceMode.Impulse);
            asteroidRb.AddTorque(Random.Range(-75f, 75f), Random.Range(-75f, 75f), Random.Range(-75f, 75f), ForceMode.Acceleration);

        }
    }
    private void CurrentStationHealth(int damage)
    {   
        stationCurrentHealth -= damage;
        if (stationCurrentHealth <= 0)
        {
            
        }
        else if (stationCurrentHealth <= stationTotalHealth * 0.5f && !dmgVFXbool1)
        {
            //activating the vfx on module 5 of the gamestation gameobj when station life under 50%
            spaceStation.transform.GetChild(0).GetChild(5).GetChild(0).gameObject.SetActive(true);
            dmgVFXbool1 = true;
        }
        else if (stationCurrentHealth <= stationTotalHealth * 0.25f && !dmgVFXbool2)
        {
             //activating the vfx on module 13 of the gamestation gameobj when station life under 25%
            spaceStation.transform.GetChild(0).GetChild(13).GetChild(0).gameObject.SetActive(true);
            dmgVFXbool2 = true;
        }   
       
    }
    private void TotalPointCalculatorFunc(float hitPoint)
    {
        pointSummary += hitPoint; 
        
    }  
}
