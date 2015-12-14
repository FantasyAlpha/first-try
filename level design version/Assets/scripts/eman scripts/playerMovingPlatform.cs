using UnityEngine;
using System.Collections;

public class playerMovingPlatform : MonoBehaviour {

	float c = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.tag == "platformMoving")
		{
			transform.parent= other.transform ;  
			c += Time.fixedDeltaTime;

			if(c >= 3){
				Destroy(other.gameObject.GetComponent<BoxCollider2D>());
				transform.parent = null;
			}
		}
	}
	void OnCollisionExit2D(Collision2D other)
	{
		if (other.transform.tag == "platformMoving")
		{
			transform.parent= null;
			
		}
	}
}
