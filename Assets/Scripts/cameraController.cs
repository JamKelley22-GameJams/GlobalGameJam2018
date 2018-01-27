using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

    GameObject player;
    [Range(0,1)]
    public float camLagTime;
    public Vector3 offset;

	void Start () {
        player = GameObject.FindWithTag("Player");
        //Debug.Log(player);
    }
	
	void FixedUpdate () {
        
        Vector3 desiredPos = player.transform.position + offset;
        //Debug.Log("DesiredPos: " + desiredPos);
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, camLagTime);
        //Debug.Log("SmothedPos: " + desiredPos);
        transform.position = smoothedPos;
        
        //transform.position = player.transform.position + offset;
    }
}
