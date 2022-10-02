using System;
using UnityEngine;
public class Camera2 : MonoBehaviour
{
    public Transform playerPos;
    private Vector3 offset;
    private Vector3 campos;
    private float cubeCount;
    public static float staticFloat=5f;
    public Transform player;
    void Start()
    {
        offset = transform.position - playerPos.position;
    }
    [Obsolete("Obsolete")]
    void LateUpdate()
    {
        if (!GameManager.GameOverCalled)
        {
            cubeCount = playerPos.GetChildCount();
            offset.x = cubeCount+5;
            offset.y = cubeCount/1.25f+staticFloat;
            campos = Vector3.Lerp(transform.position, offset + playerPos.position, Time.deltaTime);
            transform.position = campos;
        }

        if (GameManager.RotateCameraCheck)
        {
            RotateAroundPlayer();
        }
        
    }
    public void RotateAroundPlayer()
    {
       transform.LookAt(player.position);
       transform.Translate(Vector3.right * (Time.deltaTime * 10));
        
    }
}