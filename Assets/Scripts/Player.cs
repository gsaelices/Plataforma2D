using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float velocidad = 5f;
	public float salto = 10f;
	public float power = 1f;
	public bool tocando_suelo = false;
	private Animator animator;
	private Rigidbody2D rb;
	private GameControlScript gcs;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		gcs = GameObject.Find ("GameControl").GetComponent<GameControlScript> ();
	}
	// Update is called once per frame
	void Update () {
		animator.SetFloat ("velocidad_animator", Mathf.Abs(rb.velocity.x));
		if (Input.GetKey("right"))
		{
			rb.velocity = new Vector2(velocidad*power,rb.velocity.y);
			transform.localScale = new Vector3(1, 1, 1);
		
		}
		if (Input.GetKey("left"))
		{
			rb.velocity = new Vector2(-velocidad*power,rb.velocity.y);
			transform.localScale = new Vector3(-1, 1, 1);
		}

		if(Input.GetKeyDown(KeyCode.Space) && tocando_suelo){
			animator.SetBool ("saltando", true);
			rb.AddForce (new Vector2(0,salto));
		}
	}

	void OnTriggerStay2D(Collider2D objeto){
		if (objeto.tag == "Suelo") {
			tocando_suelo = true;
		}
	}

	void OnTriggerExit2D(Collider2D objeto){
		if (objeto.tag == "Suelo") {
			tocando_suelo = false;

		}
	}

	void OnTriggerEnter2D(Collider2D objeto){
		if (objeto.tag == "Suelo") {
			tocando_suelo = true;
			animator.SetBool ("saltando", false);		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "muerte") {
			gcs.respawn ();
		}

	}
}
