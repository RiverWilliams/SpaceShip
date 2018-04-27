using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeOut : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	//disparition progressive de l'objet puis destruction
	void Update () {
		Color cl = gameObject.GetComponent<SpriteRenderer> ().color;
		cl.a -= 0.05F;
		gameObject.GetComponent<SpriteRenderer> ().color = cl;
		if (cl.a < 0) {
			Destroy (gameObject);
		}
	}
}
