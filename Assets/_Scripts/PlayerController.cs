using UnityEngine;



public class PlayerController : MonoBehaviour
{
   
    [SerializeField] private float  strafeSpeed = 75.0f,  hoverSpeed = 75.0f, rollSpeed = 90.0f;
    public float normalSpeed = 150f , forwardSpeed = 300.0f;
    private float activeForwardSpeed, activeStrafeSpeed, activeHoverSpeed, activeRoll;
    [SerializeField] private float forwardAccel = 2.5f, strafeAccel = 2.0f, hoverAccel = 2.0f, rollAccel = 10.0f , navigateSpeed = 90f;
    private Vector2 lookDirectionInput, centerOfScreen, distancefromScreenCenter;
   
        
    void Start()
    {
        centerOfScreen.x = Screen.width/2.0f;
        centerOfScreen.y = Screen.height/2.0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    void Update()
    {
        PlayerMovement();
        CrosshairAiming();    
    }

    private void PlayerMovement()
    {
       lookDirectionInput.x =  Input.mousePosition.x;
       lookDirectionInput.y =  Input.mousePosition.y;

        distancefromScreenCenter.x = (lookDirectionInput.x - centerOfScreen.x)/centerOfScreen.y;
        distancefromScreenCenter.y = (lookDirectionInput.y - centerOfScreen.y)/ centerOfScreen.y;

        transform.Rotate(-distancefromScreenCenter.y * navigateSpeed * Time.deltaTime, distancefromScreenCenter.x * navigateSpeed * Time.deltaTime, activeRoll * rollSpeed * Time.deltaTime, Space.Self);

        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAccel * Time.deltaTime);
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAccel *Time.deltaTime );
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAccel * Time.deltaTime);
        activeRoll = Mathf.Lerp(activeRoll, Input.GetAxisRaw("Roll"), rollAccel * Time.deltaTime);

        transform.position += (transform.forward * activeForwardSpeed * Time.deltaTime) + 
                                (transform.right * activeStrafeSpeed * Time.deltaTime) + (transform.up * activeHoverSpeed * Time.deltaTime);
    }

    private void CrosshairAiming()
    { 
        if (!PauseMenuScript.isPaused){ // && !GameOverScript.isOver
           
            distancefromScreenCenter = Vector2.ClampMagnitude(distancefromScreenCenter,1f);   
        } 
    }
}
