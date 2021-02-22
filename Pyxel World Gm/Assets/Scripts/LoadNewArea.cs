using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour {

    public string levelToLoad;                                      //will use this variable for everytime we add a new level and to load it from previouss
    public string exitPoint;                                              //sets exit point in leaving the area
    private PlayerController thePlayer;


	// Use this for initialization
	void Start () {


        thePlayer = FindObjectOfType<PlayerController>();                    //connected with player controller script
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D (Collider2D other)                    //using a brand new update function 
    {
        if (other.gameObject.name == "Player")               /*we selected the player is a condition that if the player collides with our Trigger object
                                                             we will enter to next level*/
        {
            SceneManager.LoadScene(levelToLoad);                //in the brackets we decared the public string no need to edit pls[connected with the public string]
            thePlayer.startPoint = exitPoint;

        }
    }
}
