using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAsteroid : MonoBehaviour {
	private Vector2 mouvement;
	private Vector3 leftBottomCameraBorder;
	private Vector3 rightBottomCameraBorder;
	private Vector3 leftTopCameraBorder;
	private Vector3 siz;
	public float speed;
	public AudioClip explode;

	// Use this for initialization
	void Start () {
		leftBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0));
		rightBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0));
		leftTopCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 0));
	}
	
	// Update is called once per frame
	void Update () {
		//taille de l'astéroide
		siz.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
		siz.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;

		//déplacement de l'astéroide vers la gauche à une certaine vitesse
		mouvement = new Vector2 (-1.0F * speed, 0.0F);
		gameObject.GetComponent<Rigidbody2D>().velocity = mouvement;

		//destruction si l'astéroide sort de la caméra
		if (transform.position.x + siz.x < leftBottomCameraBorder.x + (siz.x / 2)) {
			OnHit ();
		}
	}

	//quand le vaisseau rentre dans un astéroide, explosion, le vaisseau perd une vie et l'astéroide disparait
	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.name == "myShip") {
			Vector3 tmpPos1 = new Vector3 (transform.position.x, transform.position.y, 2.0F);
			GameObject boom = Instantiate(Resources.Load("explosion"),tmpPos1, Quaternion.identity) as GameObject;
			AudioSource.PlayClipAtPoint (explode, new Vector3(0,0,0));
			Destroy (this.gameObject);
			boom.AddComponent<fadeOut> ();
			//on cherche l'item de vie le plus à gauche restant, quand on le trouve, on le supprime
			//pendant que l'item disparait progressivement, le vaisseau est invicible
			if (GameObject.FindGameObjectWithTag("life5")) {
				GameObject.FindGameObjectWithTag("life5").AddComponent<fadeOut>();
			}
			else if (GameObject.FindGameObjectWithTag("life4")) {
				GameObject.FindGameObjectWithTag("life4").AddComponent<fadeOut>();
			}
			else if (GameObject.FindGameObjectWithTag("life3")) {
				GameObject.FindGameObjectWithTag("life3").AddComponent<fadeOut>();
			}
			else if (GameObject.FindGameObjectWithTag("life2")) {
				GameObject.FindGameObjectWithTag("life2").AddComponent<fadeOut>();
			}
			else if (GameObject.FindGameObjectWithTag("life1")) {
				GameObject.FindGameObjectWithTag("life1").AddComponent<fadeOut>();
			}
		}
	}

	//quand un astéroide est détruit, on en fait apparaitre un nouveau à droite à une hauteur aléatoire
	void OnHit() {
		Destroy (this.gameObject);
		Vector3 tmpPos = new Vector3 (rightBottomCameraBorder.x + (siz.y / 2), Random.Range (leftTopCameraBorder.y - (siz.y / 2), leftBottomCameraBorder.y + (siz.y / 2)), transform.position.z);
		GameObject gY = Instantiate (Resources.Load ("asteroidSP"), tmpPos, Quaternion.identity) as GameObject;
	}
		
}
