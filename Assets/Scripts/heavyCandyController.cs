using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heavyCandyController : MonoBehaviour
{
    [SerializeField]GameObject playerRef;
    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
{
    if (col.gameObject.tag.Equals("Gum"))
    {
        if(col.gameObject.transform.localScale.x >= 1.3){
            if (playerRef != null)
            {
                playerMovement playerMovementComponent = playerRef.GetComponent<playerMovement>();
                if (playerMovementComponent != null)
                {
                    Debug.Log("Calling OnCandyHit on playerMovement from Heavy");
                    //playerMovementComponent.OnCandyHit("null");
                    playerMovementComponent.OnCandyHit("heavy");
                    Destroy(col.gameObject,0.1f);
                    Destroy(this.gameObject, 0.1f);
                }
                else
                {
                    Debug.LogError("playerMovement component not found on playerRef!");
                }
            }
            else
            {
                Debug.LogError("playerRef is null in baseCandyController!");
            }
        }
    }
}   
}
