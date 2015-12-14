using UnityEngine;
using System.Collections;

public class waterkill : MonoBehaviour {
	private playercontroller theplayer ;
	public Levelmanager levelmanager2 ;
	// Use this for initialization
	void Start () {
		levelmanager2 = FindObjectOfType<Levelmanager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.name=="player") {
			levelmanager2.respawnplayer() ;
		}
		
	}
}
