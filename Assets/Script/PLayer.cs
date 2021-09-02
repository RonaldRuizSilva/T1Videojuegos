using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer : MonoBehaviour
{
    public int FuerzaSalto = 5;
    public int VelocidadCorrer = 2;

    bool ChocaEnemigo = false;
	int ce=0;

    public Transform trans;
	public Rigidbody2D rb;
	public Animator anim;

    void Start()
    {
        trans = GetComponent<Transform> ();
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
		//Debug.Log("Matar enemigo desactivado");
		rb.velocity = new Vector2 (1 * VelocidadCorrer, rb.velocity.y);
        
       	if(Input.GetKey(KeyCode.LeftArrow)){
			anim.SetBool ("Slide", true);
			rb.velocity = new Vector2 (1 * VelocidadCorrer, rb.velocity.y);
			ChocaEnemigo=true;
		}
		if(Input.GetKeyUp(KeyCode.LeftArrow)){
			ChocaEnemigo=true;
			anim.SetBool ("Slide", false);
		}
		

        if(Input.GetKeyDown(KeyCode.UpArrow)){
			anim.SetBool ("Jump", true);
			rb.velocity = new Vector2 (rb.velocity.x * 1, FuerzaSalto);
		}

		
        

    }
	//Colisiones y choques con objetos
    	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Piso") {
			anim.SetBool ("Jump", false);
		}

		}

		void OnTriggerEnter2D(Collider2D c)
    {
		if(c.gameObject.CompareTag("Enemigo"))
        {
			Debug.Log("Choca con el puto enemigo");
			if(ChocaEnemigo==true){
				 Destroy(c.gameObject);
			}
        }
		if(c.gameObject.CompareTag("Contador")){
			ce++;
			Debug.Log("Sumando en uno");		}
	}
}
