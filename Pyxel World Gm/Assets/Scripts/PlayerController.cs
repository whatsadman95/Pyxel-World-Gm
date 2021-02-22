using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

	public float moveSpeed;                                      //variable 'moveSpeed' controls the speed
    private float currentMoveSpeed;
    //public float diagonalMoveModifier;
	private Animator anim;					                        //Declaring anim as a variable for Animator Reference

	private bool playerMoving; 
	public Vector2 lastMove;
    private Vector2 moveInput;

    private Rigidbody2D myRigidBody;
    private static bool playerExists;

    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;
    public string startPoint;                                       // newly added for startpoint 
    public bool canMove;
    private SFXManager sfxMan;
    


	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();  	                                                            //Getting Animation componenet from Animator
        myRigidBody = GetComponent<Rigidbody2D>();                                                  //getting componenets under Rigidbody2D to the variable declared 
        sfxMan = FindObjectOfType<SFXManager>();
            

        if(!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);                                                 //wont destroy character on new levels
        }
        else
        {
            Destroy(gameObject);
        }
        canMove = true;
        lastMove = new Vector2(0, -1f);
    }

	
	// Update is called once per frame
	void Update () {

		playerMoving = false;																		//player is by default not moving

        if (!canMove)
        {
            myRigidBody.velocity = Vector2.zero;
            return;
        }

        if (!attacking)
        {




            /*  if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f )   //for x axis Movement

              {
                                                                                                          //transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));

                  myRigidBody.velocity = new Vector2 (Input.GetAxisRaw("Horizontal") * currentMoveSpeed, myRigidBody.velocity.y);                 //Update ,using rigidbody 2d to precise more less bouncy movement for x axis

                  playerMoving = true;

                  lastMove = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0f);							//last move input gets horizontal last input
              }


              if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f )        //for y axis Movement

              {
                                                                                                          //transform.Translate (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime, 0f));

                  myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed);           //Update ,using rigidbody 2d to precise more less bouncy movement for Y Axis

                  playerMoving = true;

                  lastMove = new Vector2 (0f, Input.GetAxisRaw ("Vertical"));							            //last move input gets from vertical last input
              }

              if(Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f )
              {

                  myRigidBody.velocity = new Vector2(0f, myRigidBody.velocity.y);

              }                                                                           // Fixing the sudden snowfalling type problems after adding rigidbody movements , we will provide them to to y axis as well

              if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
              {

                  myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, 0f);

              }*/

            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;  // new move

            if(moveInput != Vector2.zero)
            {
                myRigidBody.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
                playerMoving = true;
                lastMove = moveInput;
            }
            else
            {
                myRigidBody.velocity = Vector2.zero; 
            }

            if (Input.GetKeyDown(KeyCode.Space))                                // if player presses "Space" it will start to attack
            {
                attackTimeCounter = attackTime;                         //counting attacktime
                attacking = true;
                myRigidBody.velocity = Vector2.zero;                 //freeze player while doing attack
                anim.SetBool("Attack", true);                       //Attack in animator will be on
                sfxMan.playerAttack.Play();

            }

           /* if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)    //without plus minus the 0,! type data will be generated
            {
                currentMoveSpeed = moveSpeed * diagonalMoveModifier; 
            } else
            {
                currentMoveSpeed = moveSpeed;
            }*/

        }






        if(attackTimeCounter > 0)                               //if attact time is there, it will be decreased slowly by the given attackTime
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if(attackTimeCounter <= 0)                                  //conditions for attackTime is over
        {
            attacking = false;    //attack STOPPED
            anim.SetBool("Attack", false);  //told animator that Attack is OVER
        }

        anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));		//input will be triggered by the horizontal keys and shifted to MoveX in unity animator parametrs
		anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));			//input will be triggered by the vertical keys and shifted to MoveY in unity animator parametrs
		anim.SetBool ("PlayerMoving", playerMoving);			//PlayerMoving will be set by variable playerMoving in input
		anim.SetFloat ("LastMoveX", lastMove.x);				//LastMoveX will be getting datas from variable lastMove through the vector2 x-axis input
		anim.SetFloat ("LastMoveY", lastMove.y);				//LastMoveY will be getting datas from variable lastMove through the vector2 y-axis input
        

	}
}
