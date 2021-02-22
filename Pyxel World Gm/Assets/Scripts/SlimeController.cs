using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    private bool moving;                      /*we will estimate that the enemy will stop and wait for some secs and move again and do the same again
                                              so we customize accordingly*/
    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;

    private Vector3 moveDirection;
    public float waitToReload;   //reload time variable
    private bool reloading;      //if reloading happens for for player destruction or not
    private GameObject thePlayer; 

	// Use this for initialization
	void Start () {

        myRigidbody = GetComponent<Rigidbody2D>();                                  //getting Rigidbody Property from the RigidBody2D

        //timeBetweenMoveCounter = timeBetweenMove;                                 
        //timeToMoveCounter = timeToMove;

        timeBetweenMoveCounter = Random.Range(timeBetweenMove * .75f, timeBetweenMove * 1.25f);              //counter counts the time randomly
        timeToMoveCounter = Random.Range(timeToMove * .55f, timeToMove * 1.75f);

    }
	
	// Update is called once per frame
	void Update () {

        if(moving)
        {
            timeToMoveCounter -= Time.deltaTime; //time to move, the countdown begins
            myRigidbody.velocity = moveDirection;

            if (timeToMoveCounter < 0f)         //time to move countdowns to 0,now time between moves is here.
            {
                moving = false;
                // timeBetweenMoveCounter = timeBetweenMove;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * .75f, timeBetweenMove * 1.25f);

            }

        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;  //time between move countdown begins

            myRigidbody.velocity = Vector2.zero;   //stopping the velocity by setting vector2 x,y axis 0

            if (timeBetweenMoveCounter < 0f)            //time between move counts down
            {
                moving = true;
                //timeToMoveCounter = timeToMove; 

                timeToMoveCounter = Random.Range(timeToMove * .55f, timeToMove * 1.75f);           // time to move counter start to count the time

                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f); //random generating values from -1f to 1f including moveSpeed Feature
            }
        }
		
        if (reloading)
        {
            waitToReload -= Time.deltaTime;                 //if loading is true ,waitToReload will be counting down, if it gets below 0 then application will load a new level
            if(waitToReload < 0)
            {
                Application.LoadLevel(Application.loadedLevel);  //loadedlevel will reload the same level again for now..

                thePlayer.SetActive(true);                      //player will be activated after loading new level
            }

        }

	}
     void OnCollisionEnter2D(Collision2D other)  //if player  collides with this enemy , it will KILL him (using colllution in 2D environ ment)
    {
       /* if (other.gameObject.name == "Player")  // condition that detects enemy hitted with the player!!
        {

            
            other.gameObject.SetActive(false);  //DEACTIVATED PLAYER

            reloading = true;                   //Reloades
            thePlayer = other.gameObject;       //killled player are set to current player.
        }*/

    }
}
