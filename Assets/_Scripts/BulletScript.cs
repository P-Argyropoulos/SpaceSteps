using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject bulletImpactPrefab;
    [SerializeField] private float bulletSpeed = 1000.0f;
   
    private GameObject crosshair;
    void Awake()
    {
        crosshair = GameObject.Find("CrossHair");  
    } 
    void Start()
    {   
         //calculating the position and direction of the crosshair gameobject and adding force to that direction
        Vector3 aimingDirection = crosshair.transform.position - transform.position;
        gameObject.GetComponent<Rigidbody>().AddForce(aimingDirection.normalized * bulletSpeed, ForceMode.Impulse);
        Destroy(gameObject, 6f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet")){
            
        }
        else if (collision.gameObject.CompareTag("Asteroids"))
        {
            Instantiate(bulletImpactPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
            if ( collision.gameObject.layer == 14){
                Destroy(collision.gameObject);
            }
                   
        }else
        {
            Instantiate(bulletImpactPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
            EventHandler.HealthUpdateEvent(5);
        }
    }
}
