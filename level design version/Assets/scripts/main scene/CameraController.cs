using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public GameObject player;
	
	private Vector3 offset;
	float distance;
	void Start ()
	{
		//transform.position = player.transform.position;

		offset = -player.transform.position + transform.position;
		/*distance = offset.magnitude;
		offset.Normalize ();*/
	}

	void Update () {
		Vector3 playerpos = player.transform.position;
	playerpos.z = transform.position.z;
		transform.position = playerpos;
	}

	


		//transform.position = Finnpos;
		/*offset = player.transform.position - transform.position;
		distance = offset.magnitude;
		offset.Normalize ();
		if (distance > 0) {
			transform.Translate (offset * 0.2f);

		} else {
			transform.Translate (new Vector3(0, 0, 0));
		}*/
		//transform.position = player.transform.position + offset;
	
}
