using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour {

    public float timeToDestroy;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        timeToDestroy -= Time.deltaTime; //decreases within time

        if (timeToDestroy <= 0)
        {

            Destroy(gameObject); //destroys number when its equal to zero
        }

	}
}
