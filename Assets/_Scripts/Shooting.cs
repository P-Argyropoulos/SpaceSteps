using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Shooting : MonoBehaviour
{
   
    public GameObject bulletPrefab;
    //public ObjectPooling bulletOnPool;
    public Transform playerPosition;
    public AudioSource sound;

    
   
    void Start()
    { 
        sound = GameObject.Find("Player").GetComponent<AudioSource>();
        playerPosition = GetComponent<Transform>();  
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && !PauseMenuScript.isPaused) 
        {
            sound.Play();
            
           GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
           //bulletOnPool.GetObject(bulletPrefab);

        }
    }

    
}
