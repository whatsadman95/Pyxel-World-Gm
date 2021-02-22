using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour {

    private PlayerController thePlayer; //calling two scripts in two variables, was private before
    private CameraController theCamera;  //private was before
    public Vector2 startDirection;   // adding direction that facing to the new house
    public string pointName;            //name of point when its starting


    // Use this for initialization
    void Start () {

        thePlayer = FindObjectOfType<PlayerController>();    // for both camera and player, finding objects and transforming position from the "PlayerController" script

        if (thePlayer.startPoint == pointName)
        {

            thePlayer.transform.position = transform.position;
            thePlayer.lastMove = startDirection;

            theCamera = FindObjectOfType<CameraController>();
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
