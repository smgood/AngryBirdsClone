using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts;
using System;


public class blueBird : Bird 
{
	public Sprite SpriteShownWhenCloned;
	public GameObject blueBirdClones;

	private bool Collided = false;
	private bool Cloned = false;
	private Sprite normalSprite;
	private GameObject blueBirdUp;
	private GameObject blueBirdDown;

	public override void Start()
	{    
		base.Start();
		normalSprite = GetComponent<SpriteRenderer> ().sprite;
	}

	void Update() 
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			if (State == BirdState.Thrown && Collided == false && Cloned == false) 
			{
				Vector2 currentPosition = transform.position;
				Vector2 currentVelocity = GetComponent<Rigidbody2D>().linearVelocity;
				Cloned = true;

				blueBirdUp = Instantiate(blueBirdClones) as GameObject;
				blueBirdUp.GetComponent<blueBirdClone>().startPosition = new Vector2(currentPosition.x, currentPosition.y + 0.25f);
				blueBirdUp.GetComponent<blueBirdClone>().startVelocity = new Vector2(currentVelocity.x, currentVelocity.y + 2f);

				blueBirdDown = Instantiate(blueBirdClones) as GameObject;
				blueBirdDown.GetComponent<blueBirdClone>().startPosition = new Vector2(currentPosition.x, currentPosition.y - 0.25f);
				blueBirdDown.GetComponent<blueBirdClone>().startVelocity = new Vector2(currentVelocity.x, currentVelocity.y - 2f);


				GetComponent<SpriteRenderer>().sprite = SpriteShownWhenCloned;
			}
		}
	}
	
	void OnCollisionEnter2D() 
	{
		if (State == BirdState.Thrown && Collided == false) 
		{
			Collided = true;
			GetComponent<SpriteRenderer>().sprite = normalSprite;
		}
	}
}
