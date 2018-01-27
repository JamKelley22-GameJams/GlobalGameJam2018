using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetCell : MonoBehaviour {

    GameObject player;
    private playerController playerController;
    public float health;

    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<playerController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerController.increaseSize(health);
            Destroy(this.gameObject);
        }
    }
}
