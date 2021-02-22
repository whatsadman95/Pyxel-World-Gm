using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    public int MaxHealth;
    public int CurrentHealth;
    private PlayerStats thePlayerStats;
    public int expToGive;                   //enemy power 
    public string enemyQuestName;
    private QuestManager theQM;


    // Use this for initialization
    void Start()
    {

       CurrentHealth = MaxHealth; //in startin player has full health
       thePlayerStats = FindObjectOfType<PlayerStats>();  //connected with the playerstats script with variable
        theQM = FindObjectOfType<QuestManager>();

    }

    // Update is called once per frame
    void Update()
    {

        if (CurrentHealth <= 0)  //if Enemy's health gets zero, will be deactive
        {

            theQM.enemyKilled = enemyQuestName;
            Destroy(gameObject);
            thePlayerStats.AddExperience(expToGive);    //when ever enemy destroys experience is added and transferred to the AddExperience scripts
        }



    }
    public void HurtEnemy(int damageToGive)   //hurt function
    {
        CurrentHealth -= damageToGive;

    }

    public void SetMaxHealth()              //max health manager
    {
        CurrentHealth = MaxHealth;
    }


}
