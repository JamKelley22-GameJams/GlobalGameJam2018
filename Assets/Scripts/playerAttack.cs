using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour {

    [Range(5,20)]
    public int attackRadius;

    public float force;

    public SpriteRenderer attackSphere;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.F))
        {
            Color set = attackSphere.color;
            set.a = .1f;
            attackSphere.color = set;
            StartCoroutine("FadeAttack");
            Collider2D[] collidersInRange = Physics2D.OverlapCircleAll(transform.position, attackRadius);
            foreach(Collider2D collider in collidersInRange)
            {
                if (collider.gameObject.tag == "Enemy")
                {
                    //Debug.Log(force * (collider.gameObject.transform.position - transform.position).normalized);

                    collider.gameObject.GetComponent<Rigidbody2D>().AddForce(force * (collider.gameObject.transform.position - transform.position).normalized);
                }
            }
        }

	}

    IEnumerator FadeAttack()
    {
        for (float f = 1f; f >= 0; f -= 0.05f)
        {
            Color c = attackSphere.color;
            c.a = f;
            attackSphere.color = c;
            yield return null;
        }
        Color transparent = attackSphere.color;
        transparent.a = 0;
        attackSphere.color = transparent;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
