using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class playerController : MonoBehaviour {

    private Rigidbody2D rb;

    private static float horizontal;
    private float vertical;

    [Range(5, 15)]
    public float maxSpeed;
    public float speed;
    [Range(0, 1)]
    public float moveTime;

    public Text scoreText;

    Vector2 reference;

    public bool tiltOn;
    //Tilting
    [Range(0, 10)]
    public float smooth = 2.0F;
    public float tiltAngle = 30.0F;

    private float initScale;
    private int score;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        initScale = transform.localScale.x;

        score = 0;
        SetScoreText();

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
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * smooth);
    }
	
	void FixedUpdate () {
        speed = maxSpeed * (initScale / transform.localScale.x);
        rb.velocity = Vector2.SmoothDamp(rb.velocity, new Vector2(horizontal * speed, vertical * speed), ref reference, moveTime, Mathf.Infinity, Time.fixedDeltaTime)  ;

    }

    public void reduceSize(float dmg) {
        transform.localScale = new Vector3(transform.localScale.x - (dmg / 100), transform.localScale.y - (dmg / 100), transform.localScale.z);
    }

    public void increaseSize(float dmg)
    {
        score = score + 1;
        SetScoreText();
        transform.localScale = new Vector3(transform.localScale.x + (dmg / 100), transform.localScale.y + (dmg / 100), transform.localScale.z);
    }

    public static float getHorizontal()
    {
        return horizontal;
    }

    void SetScoreText()
    {
        scoreText.text = score.ToString();
    }
}
