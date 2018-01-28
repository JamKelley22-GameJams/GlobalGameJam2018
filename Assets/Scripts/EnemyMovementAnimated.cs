using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class EnemyMovementAnimated : MonoBehaviour
{

    private Rigidbody2D rb;

    [Range(5, 15)]
    public float maxSpeed;
    public float speed;

    GameObject currTarget;

    [Range(20, 55)]
    public float visionRadius;

    [Range(0, 5)]
    public float attackStrength;

    private playerController playerController;

    private float initScale;

    public Animator anim;
    private SpriteRenderer sr;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        initScale = transform.localScale.x;
        currTarget = GameObject.FindWithTag("Player");
        playerController = currTarget.GetComponent<playerController>();
        //Debug.Log("CurrTarget: " + currTarget);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float dist = transform.position.x - currTarget.transform.position.x;
        //Debug.Log(rb.velocity.x);
        anim.SetFloat("Horizontal", Mathf.Abs(dist));
        Debug.Log(dist);
        if (Mathf.Abs(dist) < visionRadius)
            anim.SetBool("inRange", true);
        else
            anim.SetBool("inRange", false);

        if (Vector3.Distance(currTarget.transform.position, transform.position) <= visionRadius)
        {
            speed = maxSpeed * (initScale / transform.localScale.x);
            float step = speed * Time.fixedDeltaTime;
            Vector3 intermediate = Vector3.MoveTowards(transform.position, currTarget.transform.position, step);

            if (dist > 0.1f)
            {
                sr.flipX = false;
            }
            else if (dist < 0.1f)
            {
                sr.flipX = true;
            }
            transform.position = intermediate;
        }
        else
        {
            anim.SetFloat("Horizontal", 0f);
        }
        //rb.velocity = Vector2.SmoothDamp(rb.velocity, new Vector2(horizontal * maxSpeed, vertical * maxSpeed), ref reference, moveTime, Mathf.Infinity, Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Touch");
            //gameObject.transform.parent = other.gameObject.transform;
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerController.reduceSize(attackStrength);
            //increaseSize(attackStrength);
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
