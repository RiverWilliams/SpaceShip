using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBackground : MonoBehaviour {

	private Vector3 leftBottomCameraBorder;
	private Vector2 movement;
	private Vector2 siz;
	public float positionRestartX;

	// Use this for initialization
	void Start () {
		leftBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0));
		positionRestartX = GameObject.FindGameObjectWithTag ("bck3").transform.position.x;
	}

	//le fond se décale vers la gauche, et retourne au bout de la file à droite quand il sort de la caméra par la gauche
	void Update () {
		movement = new Vector2 (1.0F * -1.0F, 0.0F);
		GetComponent<Rigidbody2D> ().velocity = movement;
		siz.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
		siz.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;

		if (transform.position.x < leftBottomCameraBorder.x - (siz.x / 2)) {
			transform.position = new Vector3 (positionRestartX, transform.position.y, transform.position.y);
		}
	}
}
