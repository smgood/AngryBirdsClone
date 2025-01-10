using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts;
using System;


public class blueBirdClone : Bird 
{
	public Vector2 startPosition;
	public Vector2 startVelocity;

	private bool Collided = false;
	private Sprite normalSprite;


	public override void Start()
	{    
		base.Start();
		normalSprite = GetComponent<SpriteRenderer> ().sprite;
		OnThrow ();
		transform.position = startPosition;
		GetComponent<Rigidbody2D> ().linearVelocity = startVelocity;
	}
}
