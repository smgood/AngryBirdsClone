using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class yellowBird : Bird 
{
	private bool Collided = false;
	private bool Boosted = false;
	public Sprite SpriteShownWhenBoosted;
	private Sprite normalSprite;

	public override void Start()
	{    
		base.Start();
		normalSprite = GetComponent<SpriteRenderer> ().sprite;
	}

	void Update() 
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			if (State == BirdState.Thrown && Collided == false && Boosted == false) 
			{
				Boosted = true;
				Vector2 Velocity = GetComponent<Rigidbody2D>().velocity;
				float velocityX = Velocity.x + (15*Velocity.x / (Velocity.x + Velocity.y));
				float velocityY = Velocity.y + (15*Velocity.y / (Velocity.x + Velocity.y));
				GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, velocityY);
				GetComponent<SpriteRenderer>().sprite = SpriteShownWhenBoosted;
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
