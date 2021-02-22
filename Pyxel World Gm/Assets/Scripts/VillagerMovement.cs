 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour {

    public float moveSpeed;

    private Rigidbody2D myRigidbody;
    public bool isWalking;      //checkmarks walking
    public float walkTime;      //how long will walk     
    public float waitTime;      //how long will wait
    private float walkCounter;
    private float waitCounter;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;

    private int walkDirection;      //specific 4 numbers indicates the move in up,down,left or right
    public Collider2D walkZone;
    private bool hasWalkZone;
    public bool canMove;
    private DialogueManager theDM;

    // Use this for initialization
    void Start () {

        myRigidbody = GetComponent<Rigidbody2D>();   //rigidbody assign to the unity componenet
        theDM = FindObjectOfType<DialogueManager>();
      

        waitCounter = waitTime;
        walkCounter = walkTime;
        chooseDirection();         //adding external functions
        if(walkZone != null)
        {

       
            minWalkPoint = walkZone.bounds.min;     //adding min,max point of walking zone from collider as unity accepts 
            maxWalkPoint = walkZone.bounds.max;
            hasWalkZone = true;
        }
        canMove = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (!theDM.dialogueActive)      //checks if dialogue manager is not activated ,ause then, they will start to move
        {
            canMove = true;
        }
        if (!canMove)
        {
            myRigidbody.velocity = Vector2.zero;
            return;

        }

        if (isWalking)
        {
            walkCounter -= Time.deltaTime;
         
            switch (walkDirection)
            {
                case 0:
                    myRigidbody.velocity = new Vector2(0, moveSpeed);        // up(Y Axis)

                    if(hasWalkZone && transform.position.y > maxWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;  //reset waitCounter

                    }
                    break;
                case 1:
                    myRigidbody.velocity = new Vector2(moveSpeed, 0);       //right (X axis)

                    if (hasWalkZone && transform.position.x > maxWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;  //reset waitCounter

                    }
                    break;
                case 2:
                    myRigidbody.velocity = new Vector2(0, -moveSpeed);    //down (Y axis)
                    if (hasWalkZone && transform.position.y < maxWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;  //reset waitCounter

                    }
                    break;
                case 3:
                    myRigidbody.velocity = new Vector2(-moveSpeed, 0);      //left (X axis)
                    if (hasWalkZone && transform.position.x < maxWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;  //reset waitCounter

                    }
                    break;
            }

            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;  //reset waitCounter

            }

        }
        else
        {
            waitCounter -= Time.deltaTime;
            myRigidbody.velocity = Vector2.zero;  //stops rigidbody/chrctr 

            if(waitCounter < 0)
            {
                chooseDirection();      //after waiting, getting new values from walkDirecion and do it again
            }
        }
       
		
	}
    public void chooseDirection()
    {
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;

    }
}
