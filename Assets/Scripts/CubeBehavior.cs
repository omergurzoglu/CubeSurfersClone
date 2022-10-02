using UnityEngine;
public class CubeBehavior : MonoBehaviour
{
    private bool isCollected;
    private RaycastHit hit;
    public GameObject mainColumn;
    public GameObject topPlayerModel;
    
    private void Start()
    {
        mainColumn=GameObject.Find("MainColumn");
        topPlayerModel=GameObject.Find("PlayerModel2");
    }
    
    private void FixedUpdate()
    { 
        //Debug.DrawRay(transform.position, mainColumn.transform.forward, Color.red);
        if (Physics.SphereCast(transform.position, 0.4f, mainColumn.transform.forward, out hit,0.3f))
        {
            if (hit.collider.gameObject.CompareTag("Obstacle"))
            {
                hit.collider.gameObject.tag = "Untagged";
                transform.parent = null;
            }
            if (hit.collider.gameObject.CompareTag("Collectible"))
            {
                hit.collider.gameObject.layer = default;
                hit.collider.gameObject.tag = "Collected";
                hit.transform.parent = mainColumn.transform;
                topPlayerModel.transform.position += Vector3.up;
                hit.transform.position = topPlayerModel.transform.position + Vector3.down;
            }

            if (hit.collider.gameObject.CompareTag("LastStairs"))
            {
                hit.collider.gameObject.tag = "Untagged";
                transform.parent = null;
                Camera2.staticFloat++;

            }
        }
    }
}


