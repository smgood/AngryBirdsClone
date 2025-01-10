using UnityEngine;
using System.Collections;

public class CircleColliders : MonoBehaviour {

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.linearVelocity = new Vector2 (0, 0);
	}
	
	// Update is called once per frame
	void OnCollisionStay2D()
	{
		if (rb.linearVelocity.magnitude < 0.05) {
			rb.Sleep ();
		}
	}

}
