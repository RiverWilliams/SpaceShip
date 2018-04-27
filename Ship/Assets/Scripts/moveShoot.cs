using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveShoot : MonoBehaviour {
	private Vector2 mouvement;
	private Vector3 rightBottomCameraBorder;
	public float speed;
	private GameState gs;
	private int ennemyLife;
	private int score;

	// Use this for initialization
	void Start () {
		rightBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0));
		gs = gameObject.AddComponent<GameState> ();
	}
	
	// Update is called once per frame
	//suppression des shoots quand ils sortent de l'écran
	void Update () {
		mouvement = new Vector3 (1.0F * speed, 0.0F, 0);
		gameObject.GetComponent<Rigidbody2D>().velocity = mouvement;
		if (transform.position.x > rightBottomCameraBorder.x) {
			this.gameObject.AddComponent<fadeOut> ();
		}
	}

	//collision
	void OnTriggerEnter2D(Collider2D collider) {
		//cas de mes tirs (shoots jaunes)
		//ils disparaissent quand ils touchent un objet
		//si je touche un astéroide il disparait et je gagne 1 point
		//si j'intercepte un tir ennemi je gagne aussi 1 point
		if(this.gameObject.tag.Equals("shootJaune")){
			if (collider.name != "boss" && collider.name != "myShip") {
				Destroy (collider.gameObject);
				Destroy (gameObject);
				score = gs.getScore ();
				score++;
				gs.setScore (score);
			}
			//si je touche un ennemi je lui enlève 1 point de vie et je gagne 1 point
			else if (collider.name == "boss") {
				int life = gs.getEnnemyLife ();
				life--;
				gs.setEnnemyLife (life);
				//si l'ennemi n'a plus de vie il disparait et je gagne 5 points
				if (life == 0) {
					GameObject.FindGameObjectWithTag ("boss").AddComponent<fadeOut> ();
					score = gs.getScore ();
					gs.setScore (score+5);
				}
			}
		}
		//cas des tirs de l'enemi (lasers rouges)
		else{
			//si je suis touché par un tir ennemi, explosion, je perds 1 point de vie
			if (collider.name == "myShip") {
				Destroy (this.gameObject);
				Vector3 tmpPos = new Vector3 (transform.position.x, transform.position.y, 2.0F);
				GameObject boom = Instantiate(Resources.Load("explosion"),tmpPos, Quaternion.identity) as GameObject;
				boom.AddComponent<fadeOut> ();
												
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
	}
		
}
