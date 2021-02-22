using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

    public int damageToGive;
    private int currentDamage;
    public GameObject damageNumber;
    private PlayerStats thePS;

    // Use this for initialization
    void Start () {
        thePS = FindObjectOfType<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update () {

       

    }

    void OnCollisionEnter2D(Collision2D other)                                                  //if player  collides with this enemy , it will KILL him (using colllution in 2D environ ment)
    {
        if (other.gameObject.name == "Player")                                                  // condition that detects enemy hitted with the player!!
        {
            currentDamage = damageToGive - thePS.currentDefence;                                //defined current damage 
            if(currentDamage < 0)                                                               //if current damage becomes -ve due to increased defence level than enemy hurting  points ,it will give back health, to remove this feature, we just nulled everything -ve 
            {
                currentDamage = 0;

            }
            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(currentDamage); //fetching from PlayerHealthManager.cs to have max, current health informations

            var clone = (GameObject)Instantiate(damageNumber, other.transform.position, Quaternion.Euler(Vector3.zero));

            /* instantuate collects the data such as the point in world where it hits with the enemy, 
             * and the Quaternion with Euler Attribute helps to provide 3 info while without Euler it will express 4, values are added null.
             * we dont care even the sword wings up,or left right ,so we nulled it */



            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;

            /*connected with the floating number script to get the damageNumber which displays values of damage on screen.We set the damageToGive Value on Enemy prefab and now this line will help to detect the number in UI */


        }

    }
}
