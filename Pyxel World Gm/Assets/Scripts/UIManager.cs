using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Slider healthBar;
    public Text HPTExt;
    public PlayerHealthManager playerHealth;
    private static bool UIExists;
    private PlayerStats thePS;
    public Text levelText;

    // Use this for initialization
    void Start () {


        if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);                                                 //wont destroy character on new levels
        }
        else
        {
            Destroy(gameObject);
        }

        thePS = GetComponent<PlayerStats>();   

    }
	
	// Update is called once per frame
	void Update () {

        healthBar.maxValue = playerHealth.playerMaxHealth;                                                          //setting max health value with UI 
        healthBar.value = playerHealth.playerCurrentHealth;                                                         // current health value displays using PlayerHealthManager Script
        HPTExt.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;               //sets the text display 
        levelText.text = "lvl: " + thePS.currentLevel;                                                               //displayes levels from the PlayerStats Script


	}
}
