using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour {
    public int playerMaxHealth;
    public int playerCurrentHealth;
    private bool flashActive;
    public float flashLength;
    private float flashCounter;
    private SpriteRenderer playerSprite;
    private SFXManager sfxMan;
  
    

    // Use this for initialization
    void Start () {

        
        playerCurrentHealth = playerMaxHealth; //in startin player has full health
        sfxMan = FindObjectOfType<SFXManager>();
        playerSprite = GetComponent<SpriteRenderer>();


	}
	
	// Update is called once per frame
	void Update () {
		
        if(playerCurrentHealth <= 0)  //if player's health gets zero, will be deactive
        {
   
            sfxMan.playerDead.Play();
            

            gameObject.SetActive(false);
           
             

        }

        if(flashActive)                                     //invisible mode (Visible-Invisible-Visible)
        {   if (flashCounter > flashLength * .66f )             //this states that the number of flash counter must be greater than flashlength * 66f , it would last a short time
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);   //alpha value or opacity is zero at 2/3 portion of time

            } else if (flashCounter > flashLength * .33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);   //alpha value or opacity is 1 at 1/3 portion of time

            } else if (flashCounter > 0f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);   //alpha value or opacity is 0 at 0th portion of time
            }
            else
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);       //alpha value or opacity is normal as it were

                flashActive = false;

            }
            flashCounter -= Time.deltaTime;   //countdown the counter to normal
        }



    }
    public void HurtPlayer(int damageToGive)   //hurt function
    {
        playerCurrentHealth -= damageToGive;

        flashActive = true;
        flashCounter = flashLength;
        sfxMan.playerHurt.Play();
    }

    public void SetMaxHealth()              //max health manager
    {
        playerCurrentHealth = playerMaxHealth;
    }


}

