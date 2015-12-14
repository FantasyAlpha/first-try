using UnityEngine;
using System.Collections;

public class LevelBorder : MonoBehaviour {
	private playercontroller theplayer ;
	public Levelmanager levelmanager1 ;
	// Use this for initialization
	void Start () {
		levelmanager1 = FindObjectOfType<Levelmanager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.name=="player") {
			levelmanager1.respawnplayer() ;
		}
		
	}
}
