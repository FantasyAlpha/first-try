using UnityEngine;
using System.Collections;

public class mud : MonoBehaviour {
	private playercontroller player ;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<playercontroller> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.CompareTag("player"))
			player.movespeed = player.movespeed / 3;

	}

	void OnCollisionExit2D(Collision2D other) {

		if (other.gameObject.CompareTag("player"))
			player.movespeed = player.movespeed *3;

	}




}
