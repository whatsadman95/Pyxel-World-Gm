using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {


    public AudioSource playerHurt;
    public AudioSource playerDead;
    public AudioSource playerAttack;

    public static bool sfxmanExists;


	// Use this for initialization
	void Start () {

        if (!sfxmanExists)
        {
            sfxmanExists = true;
            DontDestroyOnLoad(transform.gameObject);                                                 //wont destroy character on new levels
        }
        else
        {
            Destroy(gameObject);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
