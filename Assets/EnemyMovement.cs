using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour {

    private Rigidbody2D rb;

    [Range(5, 15)]
    public float speed;

    GameObject currTarget;

    public float visionRadius = 5.0F;

    // Use this for initialization
    void Start () {
		currTarget = GameObject.FindWithTag("Player");
        Debug.Log("CurrTarget: " +currTarget);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        float step = speed * Time.fixedDeltaTime;
        transform.position = Vector3.MoveTowards(transform.position, currTarget.transform.position, step);

        //rb.velocity = Vector2.SmoothDamp(rb.velocity, new Vector2(horizontal * maxSpeed, vertical * maxSpeed), ref reference, moveTime, Mathf.Infinity, Time.fixedDeltaTime);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
    }
}
