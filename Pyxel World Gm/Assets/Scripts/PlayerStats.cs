using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public int currentLevel;            //detects current level
    public int currentExp;              //Experience number

    public int[] toLevelUp;             // int[] refers to an array variable 
    public int[] HPLevels;
    public int[] attackLevels;
    public int[] defenceLevels;

    public int currentHP;
    public int currentAttack;
    public int currentDefence;
    private PlayerHealthManager thePlayerHealth;

	// Use this for initialization
	void Start () {
        currentHP = HPLevels[1];
        currentAttack = attackLevels[1];
        currentDefence = defenceLevels[1];              //in unity editor there was element dropdown section in the canvas, we dont want to start with 0 level, rather we define  "element 0" as 1

        thePlayerHealth = FindObjectOfType<PlayerHealthManager>();  //getting data from PlayerHealthManager Script
		
	}
	
	// Update is called once per frame
	void Update () {

        if(currentExp >= toLevelUp[currentLevel])        //rule if experience number exceeds or equals the required current level numbers, it will get to the next level
        {
            //currentLevel++; 
            LevelUp();
        }
		
	}

    public void AddExperience(int experienceToAdd)   //new function to add experience to the player
    {
        currentExp += experienceToAdd;
    }
    public void LevelUp()
    {
        currentLevel++;
        currentHP = HPLevels[currentLevel];         //current level is updated, all we need is to attach "currentLevel" with the HPLevels,attack ,defence  array, notice that previous one was HPLevel[1]

        thePlayerHealth.playerMaxHealth = currentHP;  //filling the max player health with updated current HP or health point , new level , new max health
        thePlayerHealth.playerCurrentHealth += currentHP - HPLevels[currentLevel-1];  //gets extra health when level up , the extra is count by the difference of current hp and previous hp
        currentAttack = attackLevels[currentLevel];
        currentDefence = defenceLevels[currentLevel];


    }
}
