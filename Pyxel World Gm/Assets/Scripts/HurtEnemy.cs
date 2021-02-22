using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour {


    public int damageToGive;
    private int currentDamage;
    public GameObject damageBurst;
    public Transform hitPoint;              //point where the sword hits
    public GameObject damageNumber;         // its a gameobject named damagenumber

    private PlayerStats thePS;


	// Use this for initialization
	void Start () {
        thePS = FindObjectOfType<PlayerStats>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //Destroy(other.gameObject);
            currentDamage = damageToGive + thePS.currentAttack;  //defined current damage 

            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(currentDamage);            //connected to EnemyHealthManager Script to fetch the function "HurtEnemy"
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);                   //takes a prefab from object in game and gets the postition , rotations etc, here we tracked DamagedBrust prefabs, need to add this to the sword


            var clone = (GameObject) Instantiate(damageNumber, hitPoint.position, Quaternion.Euler (Vector3.zero) );   
            
            /* instantuate collects the data such as the point in world where it hits with the enemy, 
             * and the Quaternion with Euler Attribute helps to provide 3 info while without Euler it will express 4, values are added null.
             * we dont care even the sword wings up,or left right ,so we nulled it */



            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage; 
            
            /*connected with the floating number script to get the damageNumber which displays values of damage on screen.We set the damageToGive Value on Enemy prefab and now this line will help to detect the number in UI */

        }
    }
}
