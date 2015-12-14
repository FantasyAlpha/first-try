using UnityEngine;
using System.Collections;

public class pushable : MonoBehaviour {
	private Rigidbody2D rgd2d ;
	// Use this for initialization
	void Start () {
		rgd2d=GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.CompareTag ("player")){
			rgd2d.isKinematic = false;
	}

	}

	void OnCollisionExit2D(Collision2D other) {

		rgd2d.isKinematic = true;
	}
	

}
