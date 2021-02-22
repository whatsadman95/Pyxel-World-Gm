using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject dBox;
    public Text dText;

    public bool dialogueActive;
    public string[] dialogLines;  //a string array to contain dialogue lines 
    public int currentLine;           // number of string of dialogue
    private PlayerController thePlayer;
	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();
        
		
	}
	
	// Update is called once per frame
	void Update () {
		if (dialogueActive && Input.GetKeyUp(KeyCode.Space))
        {
            //dBox.SetActive(false);   //once dialogue box is on, by pressing space will turn it off 
            //dialogueActive = false;
            currentLine++;
        
            
        }

        if (currentLine >= dialogLines.Length)    //exceeds string length 
        {
            dBox.SetActive(false);   //once dialogue box is on, by pressing space will turn it off 
            dialogueActive = false;
            currentLine = 0;            //reset current line
            thePlayer.canMove = true;
        }
        dText.text = dialogLines[currentLine];  //now will display what current dialogue is selected
    }
    //public void ShowBox(string dialogue)        //expired one
    //{
       // dialogueActive = true;
       // dBox.SetActive(true);
        // dText.text = dialogue;   
        // thePlayer.canMove = false;

    //}

    public void ShowDialogue()          //this will show dialogue
    {
        dialogueActive = true;
        dBox.SetActive(true);
        thePlayer.canMove = false;
    }
}
