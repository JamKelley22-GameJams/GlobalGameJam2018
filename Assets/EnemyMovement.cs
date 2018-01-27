using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour {

    private Rigidbody2D rb;

    [Range(5, 15)]
    public float maxSpeed;
    public float speed;

    GameObject currTarget;

    [Range(5, 15)]
    public float visionRadius;

    [Range(0, 5)]
    public float attackStrength;

    private playerController playerController;

    private float initScale;

    // Use this for initialization
    void Start () {
        initScale = transform.localScale.x;
        currTarget = GameObject.FindWithTag("Player");
        playerController = currTarget.GetComponent<playerController>();
        Debug.Log("CurrTarget: " + currTarget);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        if (Vector3.Distance(currTarget.transform.position, transform.position) <= visionRadius) {
            speed = maxSpeed * (initScale / transform.localScale.x);
            float step = speed * Time.fixedDeltaTime;
            transform.position = Vector3.MoveTowards(transform.position, currTarget.transform.position, step);
        }
        //rb.velocity = Vector2.SmoothDamp(rb.velocity, new Vector2(horizontal * maxSpeed, vertical * maxSpeed), ref reference, moveTime, Mathf.Infinity, Time.fixedDeltaTime);
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Touch");
            gameObject.transform.parent = other.gameObject.transform;
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerController.reduceSize(attackStrength);
            increaseSize(attackStrength);
        }
    }

    public void reduceSize(float dmg)
    {
        transform.localScale = new Vector3(transform.localScale.x - (dmg / 100), transform.localScale.y - (dmg / 100), transform.localScale.z);
    }

    public void increaseSize(float dmg)
    {
        transform.localScale = new Vector3(transform.localScale.x + (dmg / 100), transform.localScale.y + (dmg / 100), transform.localScale.z);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
    }
}
