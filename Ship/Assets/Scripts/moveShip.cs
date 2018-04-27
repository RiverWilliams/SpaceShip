using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveShip : MonoBehaviour {
	private float translationV;
	private float translationH;
	private Touch t;
	private int moveTheShip;
	public Vector2 speed;
	private Vector2 mouvement;

	// Use this for initialization
	void Start () {
		moveTheShip = 0;
	}

	// Update is called once per frame
	void Update () {
		
		//cas du jeu tactile
		if (Input.touchCount > 0) {
			t = Input.GetTouch (0);
			//on récupère les coordonnées du vaisseau et du doigt 
			Vector3 positionDoigt = Camera.main.ScreenToWorldPoint (t.position);
			positionDoigt.z = transform.position.z;
			Vector3 maPosition = transform.position;

			//quand le doigt touche l'écran on autorize le mouvement
			if (t.phase == TouchPhase.Began && GetComponentInChildren<SpriteRenderer>().bounds.Contains (positionDoigt)) { 
				moveTheShip = 1;
			//quand on ne touche plus l'écran, on arrête le mouvement
			} else if (t.phase == TouchPhase.Ended) { 
				moveTheShip = 0;
			//si le déplacement est autorisé alors on le calcule
			} else if (moveTheShip == 1) {
				//on calcule la direction
				Vector2 deplacement =  positionDoigt - maPosition;
				if (deplacement.magnitude > 1) { 
					deplacement.Normalize ();
				}

				translationH = deplacement.x;
				translationV = deplacement.y;
			}
		}

		//cas du jeu au clavier, on récupère la direction
		else {
			translationV = Input.GetAxis ("Vertical");
			translationH = Input.GetAxis ("Horizontal");
		}

		//on effectue le déplacement
		mouvement = new Vector2 (speed.x = translationH * 5.0F, speed.y = translationV * 5.0F);
		gameObject.GetComponent<Rigidbody2D>().velocity = mouvement;
	}

	void FixedUpdate() {

	}
}
