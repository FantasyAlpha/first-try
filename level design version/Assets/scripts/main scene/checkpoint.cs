using UnityEngine;
using System.Collections;

public class checkpoint : MonoBehaviour {
	private Levelmanager levelmang ;
	// Use this for initialization
	void Start () {
		levelmang = FindObjectOfType<Levelmanager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	void OnTriggerEnter2D (Collider2D other){

		if (other.tag == "player") {

			levelmang.currentcheckpoint=gameObject ;
			Debug.Log("activated checkpoint now is  "+transform.position) ;
		}

	}
}
