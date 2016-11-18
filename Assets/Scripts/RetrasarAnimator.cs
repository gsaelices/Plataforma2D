using UnityEngine;
using System.Collections;
[RequireComponent (typeof(Animator))]
public class RetrasarAnimator : MonoBehaviour {
	Animator anim;
	public float retraso = 0f;
	private float t_activacion;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		anim.enabled = false;
		t_activacion = Time.time + retraso;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > t_activacion) {
			anim.enabled = true;
		}
	}
}
