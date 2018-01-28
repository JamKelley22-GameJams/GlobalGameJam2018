using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class playerController : MonoBehaviour {

    private Rigidbody2D rb;

    private static float horizontal;
    //private float vertical;

    [Range(5, 25)]
    public float maxSpeed;
    public float speed;
    [Range(0, 1)]
    public float moveTime;

    Vector2 reference;

    private float initScale;

    public GameObject loseScreen;
    public GameObject winScreen;

    public float posMult = 2;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        initScale = transform.localScale.x;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (transform.position.y < -40)
            Lose();
        //vertical = Input.GetAxisRaw("Vertical");

        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * smooth);
    }
	
	void FixedUpdate () {
        speed = maxSpeed * (initScale / transform.localScale.x);
        if(rb.velocity.x > 0)
            rb.velocity = Vector2.SmoothDamp(rb.velocity, new Vector2(horizontal * speed* posMult, 0), ref reference, moveTime, Mathf.Infinity, Time.fixedDeltaTime);
        else
            rb.velocity = Vector2.SmoothDamp(rb.velocity, new Vector2(horizontal * speed, 0), ref reference, moveTime, Mathf.Infinity, Time.fixedDeltaTime);

    }

    public void reduceSize(float dmg) {
        if (transform.localScale.x > 1)
            transform.localScale = new Vector3(transform.localScale.x - (dmg / 100), transform.localScale.y - (dmg / 100), transform.localScale.z);
        else
            Lose();
            //SceneManager.LoadScene("test");
    }

    public void increaseSize(float dmg)
    {
        if (transform.localScale.x < 3)
            transform.localScale = new Vector3(transform.localScale.x + (dmg / 100), transform.localScale.y + (dmg / 100), transform.localScale.z);
    }

    public static float getHorizontal()
    {
        return horizontal;
    }

    public void Lose()
    {
        Time.timeScale = .1f;
        loseScreen.SetActive(true);
    }

    public void Win()
    {
        Time.timeScale = .1f;
        winScreen.SetActive(true);
    }
}
