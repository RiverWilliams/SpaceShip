using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectIfAsteroid : MonoBehaviour {

	private GameObject[] respawns;
	private Vector2 siz;
	private Vector3 rightBottomCameraBorder;
	private Vector3 rightTopCameraBorder;
	public int nbAsteroids;

	// Use this for initialization
	void Start () {
		rightBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0));
		rightTopCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 0));
	}
	
	//selon le nombre d'astéroides présents sur l'écran, on en fait apparaitre de nouveaux aléatoirement
	void Update () {
		respawns = GameObject.FindGameObjectsWithTag ("asteroid");
		if (respawns.Length > 0) {
			siz.x = respawns [0].GetComponent<SpriteRenderer> ().bounds.size.x;
			siz.y = respawns [0].GetComponent<SpriteRenderer> ().bounds.size.y;
		}
		if (respawns.Length < nbAsteroids) {
			if (Random.Range (1, 100) == 50 || respawns.Length < nbAsteroids) {
				Vector3 tmpPos = new Vector3 (rightBottomCameraBorder.x + (siz.x / 2), Random.Range (rightBottomCameraBorder.y + (siz.y / 2), rightTopCameraBorder.y - (siz.y / 2)), transform.position.z);
				GameObject gY = Instantiate (Resources.Load ("asteroidSP"), tmpPos, Quaternion.identity) as GameObject;
			}
		}
	}
}
