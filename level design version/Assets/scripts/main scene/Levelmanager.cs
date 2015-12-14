using UnityEngine;
using System.Collections;

public class Levelmanager : MonoBehaviour {
	public GameObject currentcheckpoint ;
	private playercontroller theplayer ;
	// Use this for initialization
	void Start () {
		theplayer = FindObjectOfType<playercontroller> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void respawnplayer () {
		Debug.Log("respawnplayer");

		theplayer.transform.position = currentcheckpoint.transform.position;
}
}
