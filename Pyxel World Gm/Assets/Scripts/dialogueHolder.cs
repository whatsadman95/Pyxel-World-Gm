using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueHolder : MonoBehaviour {

    public string dialogue;                          //here you will put the dialogue
    private DialogueManager dMAn;
    public string[] dialogueLines;

	// Use this for initialization
	void Start () {

        dMAn = FindObjectOfType<DialogueManager>();  //connected with the dialogue manager script


	}
	
	// Update is called once per frame
	void Update () {
		

	}
    private void OnTriggerStay2D(Collider2D other)

    {
       if(other.gameObject.name == "Player")                 //checks if player in this area 
        {
            if (Input.GetKeyUp(KeyCode.Space))            //checks if space is pressed up and then starts.
            {
                //dMAn.ShowBox(dialogue);                      //showing the dialogue through dialogue manager script
                if (!dMAn.dialogueActive)
                {
                    dMAn.dialogLines = dialogueLines;   //this dialogueLines will be bridged with dialogue manager's dialogueLines
                    dMAn.ShowDialogue();                //called the showDialogue function
                }
                
                if(transform.parent.GetComponent<VillagerMovement>() != null)
                {
                    transform.parent.GetComponent<VillagerMovement>().canMove = false;   //dialogue is on and vilager is stopped moving
                }

            }
        } 
    }
}
