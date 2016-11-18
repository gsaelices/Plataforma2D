using UnityEngine;
using System.Collections;

public class moneda : MonoBehaviour {
	private Rigidbody2D rb;
	GameObject txt_moneda;
	ControlMonedas ctrl_moneda;
	// Use this for initialization
	void Start () {
		Destroy (gameObject,3);
		rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (new Vector2(Random.Range(-100,100),100));
		txt_moneda = GameObject.Find ("texto_moneda");
		ctrl_moneda =txt_moneda.GetComponent<ControlMonedas>();
	
	}
	

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			ctrl_moneda.suma_monedas (5);
			Destroy (gameObject);
		}
	}

	void OnDestroy() {
       //GameObject.Find("texto_monedas").GetComponent<ControlMonedas>().suma_moneda(1);
    }
}
