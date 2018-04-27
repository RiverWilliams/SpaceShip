using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posShip : MonoBehaviour {
	public Vector2 mouvement;
	private Vector3 leftBottomCameraBorder;
	private Vector3 rightBottomCameraBorder;
	private Vector3 leftTopCameraBorder;
	private Vector3 siz;

	// Use this for initialization
	void Start () {
		leftBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0));
		rightBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0));
		leftTopCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 0));
	}
	
	// Update is called once per frame
	void Update () {
		//taille du vaiseau
		siz.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
		siz.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;

		//empêche le vaiseau de sortir des limites de la caméra
		if (transform.position.y < leftBottomCameraBorder.y + (siz.y / 2)) {
			gameObject.transform.position = new Vector3 (transform.position.x, leftBottomCameraBorder.y + (siz.y / 2), transform.position.z);
		}
		if (transform.position.y > leftTopCameraBorder.y - (siz.y / 2)) {
			gameObject.transform.position = new Vector3 (transform.position.x, leftTopCameraBorder.y - (siz.y / 2), transform.position.z);
		}

		if (transform.position.x < leftBottomCameraBorder.x + (siz.x / 2)) {
			gameObject.transform.position = new Vector3 (leftBottomCameraBorder.x + (siz.y / 2), transform.position.y, transform.position.z);
		}
		if (transform.position.x > rightBottomCameraBorder.x - (siz.x / 2)) {
			gameObject.transform.position = new Vector3 (rightBottomCameraBorder.x - (siz.y / 2), transform.position.y, transform.position.z);
		}
	}
}
