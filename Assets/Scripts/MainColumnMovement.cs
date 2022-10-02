
using UnityEngine;
public class MainColumnMovement : MonoBehaviour
{
    private Vector3 _movement;
    [SerializeField]private float xRange;
    public static bool GoAlongZ=true;
    
    void Update()
    {
        _movement.x = Input.GetAxis("Mouse X");
       
        if (!GameManager.RotateCameraCheck)
        {
            transform.Translate(_movement * (Time.deltaTime * 7f));
            transform.Translate(transform.forward * (5f * Time.deltaTime),Space.World);
        }
        
        
        if (GoAlongZ)
        {
            if (transform.position.x > xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }

            if (Mathf.Abs(transform.position.x) > xRange)
            {
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            }
        }
        
    }

   
}
