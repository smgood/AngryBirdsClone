using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	private float TimePassed = 0;
	private bool panIn = true; 

	void openingZoomOut ()
	{
	TimePassed += Time.deltaTime;
	
	if (TimePassed < 2)
		{
		transform.position = new Vector3 (5, 2, -10);
		}
	else if (TimePassed < 3)
		{
		transform.position = new Vector3 (5 - (TimePassed-2)*5, 2, -10);
		}
	else
		{
		transform.position = new Vector3 (0, 2, -10);
		panIn = false;
		}
	}

    // Use this for initialization
    void Start()
    {	
		Camera.main.orthographic = true;
		transform.position = new Vector3 (4, 2, -10);
		StartingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
	//	if (panIn == true)
	//		openingZoomOut ();

		if (IsFollowing)
		{ 
            if (BirdToFollow != null) //bird will be destroyed if it goes out of the scene
            {
                var birdPosition = BirdToFollow.transform.position;
                float x = Mathf.Clamp(birdPosition.x, minCameraX, maxCameraX);
                //camera follows bird's x position
				if (x < StartingPosition.x)
					transform.position = new Vector3(StartingPosition.x, StartingPosition.y, StartingPosition.z);
				else
					transform.position = new Vector3(x, StartingPosition.y, StartingPosition.z);
            }
            else
                IsFollowing = false;
        }
    }

    [HideInInspector]
    public Vector3 StartingPosition;


    private const float minCameraX = 0;
    private const float maxCameraX = 13;
    [HideInInspector]
    public bool IsFollowing;
    [HideInInspector]
    public Transform BirdToFollow;
}