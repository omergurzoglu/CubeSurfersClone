
using UnityEngine;
public class TokenBehavior : MonoBehaviour
{
    public GameObject TokenOnScreen;
    public GameObject Canvas;
    public static float  Score;
    
    private void Start()
    {
        Canvas=GameObject.Find("Canvas");
        
    }
    private void FixedUpdate()
    {
        transform.Rotate(0,25*Time.fixedDeltaTime,0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collected"))
        {
            Score++;
            Destroy(gameObject);
            GameObject Token=Instantiate(TokenOnScreen, new Vector3(-74,-225,0), Quaternion.Euler(0,0,45), Canvas.transform);
            Token.transform.LeanMoveLocal(new Vector3(170, 400, 0), 1.5f).setEaseOutQuart().setDestroyOnComplete(true);
        }
    }
    
}
