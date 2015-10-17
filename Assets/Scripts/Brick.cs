using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
	public float Health = 70f;
	public Sprite SpriteShownWhenHurt;
	private float ChangeSpriteHealth;

	void Start()
	{
		ChangeSpriteHealth = Health/2;
	}

    void OnCollisionEnter2D(Collision2D col)
    {
		//calculate the damage via the difference in velocities of the two colliding objects          
		Vector2 velocity1;
		if (col.gameObject.GetComponent<Rigidbody2D>() == null) 
			velocity1 = new Vector2(0,0);
		else
			 velocity1 = col.gameObject.GetComponent<Rigidbody2D> ().velocity;

		Vector2 velocity2 = GetComponent<Rigidbody2D> ().velocity;
		float damage = Mathf.Sqrt(Mathf.Pow(velocity2.x - velocity1.x, 2) + Mathf.Pow(velocity2.y - velocity1.y,2)) * 10;

        //don't play audio for small damages
//        if (damage >= 10)
//            GetComponent<AudioSource>().Play();
        //decrease health according to magnitude of the object that hit us
        Health -= damage;

		if (Health < ChangeSpriteHealth)
		{//change the shown sprite
			GetComponent<SpriteRenderer>().sprite = SpriteShownWhenHurt;
		}
        //if health is 0, destroy the block
        if (Health <= 0) Destroy(this.gameObject);
    }



    //wood sound found in 
    //https://www.freesound.org/people/Srehpog/sounds/31623/
}
