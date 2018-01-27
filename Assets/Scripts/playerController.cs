using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class playerController : MonoBehaviour {

    private Rigidbody2D rb;
    [Range(5,15)]
    public float moveForce;

    private float horizontal;
    private float vertical;

    [Range(5, 15)]
    public float maxSpeed;
    [Range(0, 1)]
    public float moveTime;

    Vector2 reference;

    public bool tiltOn;
    //Tilting
    public float smooth = 2.0F;
    public float tiltAngle = 30.0F;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if(tiltOn) { 
            float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
            float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;
            Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        }
        //Quaternion targetZero = Quaternion.identity;
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * smooth);
        if(Input.GetKey(KeyCode.Space))
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * smooth);
        //Debug.Log(transform.rotation);
    }
	
	void FixedUpdate () {
        rb.velocity = Vector2.SmoothDamp(rb.velocity, new Vector2(horizontal * maxSpeed, vertical * maxSpeed), ref reference, moveTime, Mathf.Infinity, Time.fixedDeltaTime);

    }
}
