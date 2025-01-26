using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceController : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag=="Gum"){
            Destroy(this.gameObject);
        }
    }
}
