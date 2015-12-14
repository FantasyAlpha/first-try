using UnityEngine;
using System.Collections;

public class playercontroller : MonoBehaviour
{
	public float jumpheight, movespeed;
	public Transform groundcheck;
    public float groundRad;
	public bool onladder;
	public float climbspeed;
	public bool onMovingPlatform ;
	public GameObject NinjaStar ;
	public Transform firepoint ;
	public float wallslidespeedMax ;
    public bool grounded , doubleJumped;
	public int counter ;
	public int collectingCount=0 ; 
	public float runspeed ;
	private Vector2 storeVelocity;
	private Animator anim ;
	private Rigidbody2D myrgd2d;
    private float climbVelocity , gravitystore;
	private Transform TransformStore ;
	private playercontroller theplayer ;
	private int shootcheck ;

	// climb walls vars 

	public Transform wallcheckpoint ;
	public bool wallcheck ;
	private bool facingR = true ;
	public float walljumpHeight ;
	public bool wallSlide ;
	public bool jumpdetect=false ; 
	public bool jumpcheckpoint ;


    void Start()
    {
        myrgd2d = GetComponent<Rigidbody2D>();
        gravitystore = myrgd2d.gravityScale;
		anim = GetComponent<Animator> ();
    }

    void FixedUpdate ()
    {
        grounded = Physics2D.OverlapCircle(groundcheck.position, groundRad, 1 << LayerMask.NameToLayer("ground"));


    }

    // Update is called once per frame
    void Update()
	{  
		facingR = true;
		wallSlide = false;
		jumpdetect = false;
		wallcheck = false;
		// clime wall code here 

		if (!grounded) {

		wallcheck = Physics2D.OverlapCircle (wallcheckpoint.position, 0.3f, 1 << LayerMask.NameToLayer ("walls"));
		jumpcheckpoint=Physics2D.OverlapCircle (groundcheck.position, 0.1f, 1 << LayerMask.NameToLayer ("walls"));
		if (wallcheck){

		handleslide();	

				}
		}

		shootcheck = 0;
		if (grounded) {
		// prevent sliding while moving 
			
			myrgd2d.velocity = new Vector2 (0, myrgd2d.velocity.y);
			//doubleJumped = false;
		}
		if (jumpcheckpoint) {
			//doubleJumped = false;
			wallcheck=false ;
			myrgd2d.velocity=new Vector2(0,myrgd2d.velocity.y);
		}

		//jump / climb animation

		anim.SetBool ("grounded", grounded||onladder);



		// jumping code 
		
		if (Input.GetKeyDown (KeyCode.E) && (grounded||jumpcheckpoint)&& !wallcheck) {
			jump ();

		}

		// double jump code 
		
	/*	if (Input.GetKeyDown (KeyCode.UpArrow) && (!grounded && !jumpcheckpoint)&& !doubleJumped&& !wallcheck) {

			doubleJumped = true ;
			jump ();
		
		}*/


		//move right and move left codes

		if (Input.GetKey (KeyCode.RightArrow)) {

			facingR=true ;
			transform.localScale = new Vector3(1,1,1);	
			if (Input.GetKey (KeyCode.W)) {
				
				myrgd2d.velocity = new Vector2 (runspeed, myrgd2d.velocity.y); 
				
			}
			else 
			myrgd2d.velocity = new Vector2 (movespeed, myrgd2d.velocity.y);

		}

		else if (Input.GetKey (KeyCode.LeftArrow)) {

			facingR=false ;
			transform.localScale = new Vector3 ( -1, 1, 1);
			if (Input.GetKey (KeyCode.W)) {
				
		     myrgd2d.velocity = new Vector2 (-runspeed, myrgd2d.velocity.y); 

			}
			else 
			myrgd2d.velocity = new Vector2 (-movespeed, myrgd2d.velocity.y);

			}

	
			// moving animation 

	        //	anim.SetFloat ("speed", Mathf.Abs (myrgd2d.velocity.x));

			//climbing

			if (onladder) {   
				//if(!grounded){
				//	myrgd2d.velocity = new Vector2(0, 0);
				//}
				myrgd2d.gravityScale = 0f;
				climbVelocity = climbspeed * Input.GetAxisRaw ("Vertical");
				myrgd2d.velocity = new Vector2 (myrgd2d.velocity.x, climbVelocity);
			}

			if (!onladder) {

				myrgd2d.gravityScale = gravitystore;

			}
			//shooting

			if (Input.GetKeyDown (KeyCode.Return)) {

			Instantiate (NinjaStar, firepoint.position, firepoint.rotation);

			if (theplayer.transform.localScale.x > 0) {
				shootcheck=1 ;
			} 
			else if (theplayer.transform.localScale.x < 0) {

				shootcheck=2 ;
				}
		//	anim.SetInteger("shooting",shootcheck);


			}


		}

    public void jump ()
    {


  myrgd2d.velocity = new Vector2(myrgd2d.velocity.x, jumpheight);



    }
	// wall climb and slide  mechanics 

	void handleslide () {

		//wallSlide = true;

		// slide 

		myrgd2d.velocity = new Vector2 (myrgd2d.velocity.x, wallslidespeedMax);

		// now we will handle wall jumping noting that the normal  jump  is stopped when wallcheck = true 
		// if face right then jump left and the opposite if face left 

	//	if (Input.GetKey (KeyCode.UpArrow))
		//myrgd2d.AddForce (new Vector2 (0,3)*50);

			if (transform.localScale.x == 1) {
				if (Input.GetKeyDown (KeyCode.RightArrow)) {
				myrgd2d.velocity=new Vector2 (0,0);
				} else if (Input.GetKey (KeyCode.LeftArrow)) {
					myrgd2d.AddForce (new Vector2 (-2, walljumpHeight) * 50);
				}
			}
			if (transform.localScale.x == -1) {
				if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				myrgd2d.velocity=new Vector2 (0,0);				
			} else if (Input.GetKey (KeyCode.RightArrow)) {

					myrgd2d.AddForce (new Vector2 (2, walljumpHeight) * 50);
				}
			}

				



	}

void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.CompareTag ("water"))
			storeVelocity = myrgd2d.velocity;
			myrgd2d.velocity = new Vector2 (myrgd2d.velocity.x, -1); 

	}
	void OnCollisionExitr2D(Collision2D other) {
		if (other.gameObject.CompareTag("water"))
			
			myrgd2d.velocity = storeVelocity; 
		
	}


}
