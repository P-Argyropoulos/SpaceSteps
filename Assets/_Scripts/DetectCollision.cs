using UnityEngine;


public class DetectCollision : MonoBehaviour
{
    public GameObject asteroidExplosion1, asteroidExplosion2,fracturedPrefab;
    private Transform playersPosition;
    private float hitPoint;
    private int damage;
    
    void Start()
    {
        playersPosition = GameObject.Find("Player").GetComponent<Transform>();

    }

    private void OnEnable()
    {
        
        if (gameObject.layer == LayerMask.NameToLayer("Asteroid Small"))
        { 
            hitPoint = 17.5f;
            damage = 25;

        }
        else if (gameObject.layer == LayerMask.NameToLayer("Asteroid Medium"))  
        {
            hitPoint = 12.5f;
            damage = 50;
        }
        else   
        {
            hitPoint = 7.5f;
            damage = 100;
        }
    }


    void Update()
    {
        if ((playersPosition.position - transform.position).magnitude > 3000)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Asteroids"))
        {  
            if (collision.gameObject.CompareTag("Bullet"))
            {
                Vector3 randomRotation = new Vector3 (Random.Range(-360,360), Random.Range(-360,360), Random.Range(-360,360));

                //when colliding with bullet instantiate the explosion prefab and in the asteroid position instantiate the fractured prefab asteroid of that type
                Instantiate(asteroidExplosion1, transform.position, Quaternion.LookRotation(randomRotation));
                var fracuredPieces = Instantiate(fracturedPrefab, transform.position, transform.rotation);
                
        
                EventHandler.TriggerPointAdditionEvent(hitPoint);
                Destroy(gameObject, 0.13f);  // destroying asteroid prefab after 0.13 in order to show the impact of the bullets

                if (fracturedPrefab != null)
                {
                    Destroy(fracuredPieces, 23f);//destoy fragments after 23 sec
                }  
            }
            else
            {   
                EventHandler.HealthUpdateEvent(damage);
                EventHandler.TriggerPointAdditionEvent(-hitPoint/2);  // when asteroid hiting subtracks of the total points the half amount that he provides on destruction

                var fracuredPiecesOnStation = Instantiate(fracturedPrefab, transform.position, transform.rotation);
                Instantiate(asteroidExplosion2, transform.position, transform.rotation);
                Destroy(gameObject, 0.13f);

                if (fracuredPiecesOnStation != null)
                {
                    Destroy(fracuredPiecesOnStation, 15f);
                }
                
            }    
        }
    }
}
