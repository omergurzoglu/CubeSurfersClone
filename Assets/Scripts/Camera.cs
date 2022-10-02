using System;
using UnityEngine;
public class Camera : MonoBehaviour
{
    public Transform playerPos;
    public Vector3 offset;
    private Vector3 campos;
    public float cubeCount;
    void Start()
    {
        offset = transform.position - playerPos.position;
    }
    [Obsolete("Obsolete")]
    void LateUpdate()
    {
        cubeCount = playerPos.GetChildCount();
        offset.z = -cubeCount/2-5;
        offset.y = cubeCount/1.25f;
        campos = Vector3.Lerp(transform.position, offset + playerPos.position, Time.deltaTime);
        transform.position = campos;
    }
}