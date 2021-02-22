using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject followTarget;			// it will follow any game object, just select them inside unity
	private Vector3 targetPos;				// Camera position in x,y,z vector3 form
	public float moveSpeed;                // Speed of camera to chase
    private static bool cameraExists;
    public BoxCollider2D boundsBox;
    private Vector3 minBounds;
    private Vector3 maxBounds;

    private Camera theCamera;
    private float halfHeight;
    private float halfWidth;

    // Use this for initialization
    void Start () {

        if (!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);     //wont destroy character on new levels
        }
        else
        {
            Destroy(gameObject);
        }
        if (boundsBox == null)
        {
            boundsBox = FindObjectOfType<theBound>().GetComponent<BoxCollider2D>();
            minBounds = boundsBox.bounds.min;
            maxBounds = boundsBox.bounds.max;
        }


        minBounds = boundsBox.bounds.min;
        maxBounds = boundsBox.bounds.max;

        theCamera = GetComponent<Camera>();
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;



    }
	
	// Update is called once per frame
	void Update () {

		targetPos = new Vector3 (followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);   //gets the position from the transform.position  of followTarget to the targetPos 

		transform.position = Vector3.Lerp (transform.position, targetPos, moveSpeed * Time.deltaTime);					// enables moveSpeeds to adjust the speed pacing with the target using lerp

        if(boundsBox == null)
        {
            boundsBox = FindObjectOfType<theBound>().GetComponent<BoxCollider2D>();
            minBounds = boundsBox.bounds.min;
            maxBounds = boundsBox.bounds.max;
        }

        float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
        float clampedY = Mathf.Clamp(transform.position.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    public void SetBounds(BoxCollider2D newBounds)
    {
        boundsBox = newBounds;
        minBounds = boundsBox.bounds.min;
        maxBounds = boundsBox.bounds.max;

    }
}
