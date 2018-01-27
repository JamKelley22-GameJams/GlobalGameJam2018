using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour {

    [Range(5,20)]
    public int attackRadius;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            Collider2D[] collidersInRange = Physics2D.OverlapCircleAll(transform.position, attackRadius);
            foreach(Collider2D collider in collidersInRange)
            {
                if (collider.gameObject.tag == "Enemy")
                {
                    Debug.Log(collider.gameObject.name);
                }
            }
        }
	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
