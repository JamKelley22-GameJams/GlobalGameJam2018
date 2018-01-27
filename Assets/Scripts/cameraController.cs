using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

    GameObject player;
    [Range(0,1)]
    public float camLagTime;
    private Vector3 offset;

    // How long the object should shake for.
    public float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0f;
    private float decreaseFactor = 1.0f;
    [Range(0f,0.2f)]
    public float shakeStepFactor;
    [Range(0f, 3f)]
    public float maxShake;

    private bool shake;

    void Start () {
        offset = transform.position;
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

        if (playerController.getHorizontal() < 0)//shakeDuration > 0)
        {
            transform.position = Random.insideUnitSphere * shakeAmount + transform.position;
            if(shakeAmount < maxShake)
                shakeAmount += shakeStepFactor;
            //shakeDuration -= Time.fixedDeltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            if(shakeAmount > 0)
                shakeAmount -= shakeStepFactor;
            //transform.position = player.transform.position + offset;
        }
    }
}
