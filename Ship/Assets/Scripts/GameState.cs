using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour {
	static int scorePlayer;
	static int lifeEnnemy;

	public GameState(){

	}

	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.Landscape;
	}
	
	// Update is called once per frame
	void Update () {
		//mise à jour du score à l'écran
		GameObject.FindGameObjectWithTag ("score").GetComponent<Text> ().text = "" + scorePlayer;
	}

	//getter et setter du score du joueur
	public int getScore(){
		return scorePlayer;
	}

	public void setScore(int s){
		scorePlayer = s;
	}

	//getter et setter de la vie de l'ennemi
	public int getEnnemyLife(){
		return lifeEnnemy;
	}

	public void setEnnemyLife(int l){
		lifeEnnemy = l;
	}
}
