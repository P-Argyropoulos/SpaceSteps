using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleShiledCollider : MonoBehaviour
{
    [SerializeField]
    private GameObject asteroidExplosionOnShield;

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.transform.GetChild(1).gameObject.activeSelf)
        {
            if (other.gameObject.CompareTag("Asteroids")){
                Instantiate(asteroidExplosionOnShield, other.transform.position, Quaternion.identity);
                Destroy(other.gameObject);
            }
        } 
    }   
}
