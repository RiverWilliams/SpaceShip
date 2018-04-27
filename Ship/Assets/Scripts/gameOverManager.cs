using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOverManager : MonoBehaviour {
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
		
	// si mon vaisseau n'a plus de vie, l'animation "game over" est lancée, et le vaisseau détruit
	void Update () {
		if (! GameObject.FindGameObjectWithTag ("life1")) {
			anim.SetTrigger ("GameOver");
			if (GameObject.FindGameObjectWithTag ("myShip")) {
				Destroy (GameObject.FindGameObjectWithTag ("myShip").gameObject);
			}
		}		
	}
}
