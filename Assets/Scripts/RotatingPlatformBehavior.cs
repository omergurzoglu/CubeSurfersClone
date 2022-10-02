using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatformBehavior : MonoBehaviour
{
    
    void FixedUpdate()
    {
        transform.Rotate(0,15*Time.deltaTime,0);
        
    }
}
