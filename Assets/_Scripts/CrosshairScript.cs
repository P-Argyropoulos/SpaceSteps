using UnityEngine;

public class CrosshairScript : MonoBehaviour
{
    [SerializeField] private Camera weaponCamera;
    [SerializeField] private LayerMask layerMask;
    private float crosshairResponseToMousePos = 0.088f; // how quickly crosshair respond to mouse movement

    
    void Update()
    {
        if (!PauseMenuScript.isPaused){ 
        // GameObject Crosshair follows the position where the raycast is hiting every frame.
            Ray rayToCrosshair = weaponCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(rayToCrosshair,out RaycastHit hitInfo, float.MaxValue, layerMask))
            {
                 transform.position =  Vector3.Lerp(transform.position, hitInfo.point, crosshairResponseToMousePos);
            }  
        }
    }
}
