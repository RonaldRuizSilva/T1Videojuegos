using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{

    public int VelocidadCorrer = 5;

     public Transform trans;
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;


    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
          rb.velocity = new Vector2(-1 * VelocidadCorrer, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D coll) {
        	if (coll.gameObject.tag == "User") {
			Destroy(coll.gameObject);
		}
    }
}
