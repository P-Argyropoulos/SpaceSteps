using UnityEngine;

public class AimingScript : MonoBehaviour
{
  [SerializeField] private Canvas myCanvas;
   [SerializeField] private Transform crosshair;

    void Start()
    {
      // Calculating the mouse position in canvas and applying the crosshair image to that position. 
      
       // RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out Vector2 pos);
        //transform.position = myCanvas.transform.TransformPoint(pos);
          
    }
   private void Update()
   {
    
    //Simplier solution making the crosshair image follow directly the crosshair object from world to screen coordinates! 
      transform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, crosshair.position);
   }
}
