using UnityEngine;
using System.Collections;

public class CollectableScript : MonoBehaviour {
	private playercontroller playerCollect ;
	// Use this for initialization
	void Start () {
		playerCollect = FindObjectOfType<playercontroller> ();

	}
	
	// Update is called once per frame
	void Update () {


	}

	void OnTriggerEnter2D(Collider2D other) {


		if (other.tag == "player") {
			Destroy(gameObject);
			playerCollect.collectingCount ++ ;
		}

	}







}
