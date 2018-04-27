using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBoss : MonoBehaviour {
	private Vector3 rightBottomCameraBorder;
	private Vector3 rightTopCameraBorder;
	private Vector3 leftTopCameraBorder;
	private Vector2 mouvement;
	private Vector2 siz;
	private int sens; //0 -> vers le bas, 1 -> vers le haut


	// Use this for initialization
	void Start () {
		rightBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0));
		rightTopCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 0));
		leftTopCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 0));
		sens = 0;
		siz.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
		siz.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;
	}

	// Update is called once per frame
	void Update () {
		//l'ennemi suit un pattern bas-hat-bas... vers la gauche
		//quand il touche un bord, il part dans la direction opposée
		if (sens == 0) {
			mouvement = new Vector2 (-1.0F,-1.0F);
			gameObject.GetComponent<Rigidbody2D>().velocity = mouvement;
			if(transform.position.y < rightBottomCameraBorder.y){
				sens = 1;
			}
		}
		if (sens == 1) {
			mouvement = new Vector2 (-1.0F,1.0F);
			gameObject.GetComponent<Rigidbody2D>().velocity = mouvement;
			if(transform.position.y > rightTopCameraBorder.y){
				sens = 0;
			}
		}

		//destruction de l'ennemi lorsqu'il sort de la caméra
		if(this.transform.position.x +(siz.x / 2) < leftTopCameraBorder.x) {
			Destroy(this.gameObject);
		}

	}
}
