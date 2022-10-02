
using System;
using UnityEngine;
public class TopModelBehavior : MonoBehaviour
{
    public GameManager GameManager;
    public GameObject cube;
    public Transform MainColumn;
    Vector3 rotation = new Vector3(0, 0, 0);
    float speed = 200;
    float y = 0;
    public bool turnright = false;
    public Camera cam1,cam2;
    

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Road"))
        {
            Time.timeScale = 0;
            GameManager.GameOver();
        }

        if (collision.gameObject.CompareTag("RotateCheck"))
        {
            Destroy(collision.gameObject);
            turnright = true;
            MainColumnMovement.GoAlongZ = false;
            cam1.gameObject.SetActive(false);
            cam2.gameObject.SetActive(true);
        }

        if (collision.gameObject.layer==3)
        {
            Time.timeScale = 1;
            GameManager.Won();
            cam2.GetComponent<Camera2>().RotateAroundPlayer();
        }
    }
    void Update()
    {
        if(turnright)
        {
            y -= speed * Time.deltaTime;
            if (y <= -90)
            {
                turnright = false;
                y = -90;
            }
            rotation = new Vector3(0,y,0);
            MainColumn.transform.eulerAngles = rotation;
        }
    }
}
