using UnityEngine;
using System.Collections;

public class pickupAndThrow : MonoBehaviour {
	public GameObject player;
	public GameObject throwObjects;
	public bool throwed = false;
	public Transform endLine;
	public bool groundCheck ;
	public float force;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Debug.DrawLine (transform.position,endLine.position,Color.red);
		groundCheck = Physics2D.Linecast (transform.position,endLine.position, 1 << LayerMask.NameToLayer("ground"));

		if (Input.GetKeyDown (KeyCode.R) && transform.parent == player.transform && throwed == false) 
		{
			transform.SetParent(null);
			if(player.transform.localScale.x==1){

			    throwObjects.AddComponent<Rigidbody2D>().AddForce(new Vector2 (2,2)*force);
			}
			else if (player.transform.localScale.x == -1){

				throwObjects.AddComponent<Rigidbody2D>().AddForce(new Vector2 (-2,2)*force);
			}

			throwed = true;

		}
		if (throwed == true && groundCheck) 
		{

			Destroy(GetComponent<Rigidbody2D>());
			throwed=false;
		}
	
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.tag == "player" && groundCheck)
		{
			transform.parent= other.transform ;
			transform.localPosition=new Vector2(0.5f,0.1f);

			
		}
		
		
	}

}
