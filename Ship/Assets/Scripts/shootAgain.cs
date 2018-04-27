using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootAgain : MonoBehaviour {
	private Vector3 siz;
	private int tir;
	public float tempsEntreTirsBoss;

	private int touchCount;
	private Touch t1;
	private Touch t2;

	// Use this for initialization
	void Start () {
		tir = 1;
	}
	
	// Update is called once per frame
	void Update () {
		siz.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
		siz.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;

		//gestion des tirs
		//cas de mes tirs
		if(this.gameObject.name.Equals("myShip")){
			//cas du jeu au clavier
			//si la touche espace est enfoncée, je tire (tir au coup par coup en appuyant, pas en rafale en restant appuyé)
			bool sp = Input.GetKeyDown(KeyCode.Space);
			if (sp) {
				Vector3 tmpPos = new Vector3 (transform.position.x + (siz.x/2), transform.position.y, transform.position.z);
				GameObject gY = Instantiate (Resources.Load ("shootJaune"), tmpPos, Quaternion.identity) as GameObject;
			}
			//cas du jeu tactile
			// Sauvegarde combien de doigt touchent l'écran
			touchCount = Input.touchCount;
			// S'il y a deux doigts, au touché du 2eme on tire
			if (touchCount > 0) {
				t2 = Input.GetTouch(1); //doigt 2
				if (t2.phase == TouchPhase.Began && touchCount == 2) {
					Vector3 tmpPos = new Vector3 (transform.position.x + (siz.x / 2), transform.position.y, transform.position.z);
					GameObject gY = Instantiate (Resources.Load ("shootJaune"), tmpPos, Quaternion.identity) as GameObject;
				}
			}
		}
		//cas des tirs de l'ennemi
		else {
			if (tir == 1) {
				StartCoroutine (Tir ());
			}
		}
	}

	//coroutine de tir de l'ennemi toutes les X secondes
	IEnumerator Tir(){
		Vector3 tmpPos = new Vector3 (transform.position.x - (siz.x / 2), transform.position.y, transform.position.z);
		GameObject gY = Instantiate (Resources.Load ("shootLaserRouge"), tmpPos, Quaternion.identity) as GameObject;
		tir = 0;
		yield return new WaitForSecondsRealtime (tempsEntreTirsBoss);
		tir = 1;

	}

}
