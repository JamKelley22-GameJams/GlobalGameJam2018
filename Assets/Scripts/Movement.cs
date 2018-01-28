using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	//public float moveSpeed;
	//public float moveTime;
	public float jumpSpeed;

	private Rigidbody2D rb;

	//movement values
	float horizontal;
	float vertical;
	Vector3 reference;

	//jump values
	bool jumpPressed;
	bool grounded;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		reference = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        //horizontal = Input.GetAxisRaw ("Horizontal");
        //vertical = Input.GetAxisRaw ("Vertical");
        //Debug.Log(grounded);
        if (Input.GetButtonDown ("Jump") && grounded) {
			jumpPressed = true;
		}
	}

	void FixedUpdate() {
		/*Vector3 targetVelocity = new Vector3 (
			horizontal * moveSpeed,
			rb.velocity.y,
			vertical * moveSpeed);
		rb.velocity = Vector3.SmoothDamp (rb.velocity, targetVelocity, ref reference, moveTime);
        */

		if (jumpPressed) {
			jumpPressed = false;
			rb.velocity = new Vector2 (rb.velocity.x, jumpSpeed);
		}

		grounded = false;
		Collider2D[] beneath = Physics2D.OverlapBoxAll (transform.position + Vector3.down * (transform.localScale.y * 2f),
                                 new Vector3 (transform.localScale.x / 2, 0.05f, transform.localScale.z / 2),0);

		foreach (Collider2D c in beneath) {
			if (c.gameObject.CompareTag ("Floor")) {
				grounded = true;
			}
		}
	}

	public bool getGrounded(){
		return grounded;
	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(transform.position + Vector3.down * (transform.localScale.y*2.4f), new Vector3(transform.localScale.x / 2, 0.05f, transform.localScale.z / 2));
    }
}
