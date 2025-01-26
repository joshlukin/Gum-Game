using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upAndDown : MonoBehaviour
{
	//adjust this to change speed
	[SerializeField]
	float speed = 5f;
	//adjust this to change how high it goes
	[SerializeField]
	float height = 0.5f;

	Vector3 pos;

	private void Start()
	{
		GetComponent<Collider2D>().isTrigger = true;
	pos = transform.position;
	}
	void Update()
	{

	//calculate what the new Y position will be
	float newY = Mathf.Sin(Time.time * speed) * height + pos.y;
	//set the object’s Y to the new calculated Y
	transform.position = new Vector3(transform.position.x, newY, transform.position.z) ;
	}


	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Gum"){
			Debug.Log("gum hit water");
			GetComponent<Collider2D>().isTrigger = false;
			GetComponent<SpriteRenderer>().color = Color.white;
			Destroy(col.gameObject);
		}
	}
}
