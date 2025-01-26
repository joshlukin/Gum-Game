using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseCandyController : MonoBehaviour
{
    [SerializeField]  GameObject playerRef;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag.Equals("Gum")){
            playerRef.GetComponent<playerMovement>().OnCandyHit("red");
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }
}
