using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class launchLevel : MonoBehaviour {
	public int bouton;
	private GameState gs;

	// Use this for initialization
	void Start () {
		gs = gameObject.AddComponent<GameState> ();
	}
	
	// on lance une autre scène selon le bouton sur lequel on clique
	public void onClick () {
		if(bouton == 1){
			Invoke ("goScene1", 0.2f);
			}
		if (bouton == 2) {
			Invoke ("goScene2", 0.2f);
		}
		if(bouton == 3){
			Invoke ("goScene3", 0.5f);
		}
	}

	//scene du niveau normal
	void goScene1(){
		SceneManager.LoadScene ("scene1");
		gs.setScore (0);
	}

	//scene du niveau difficile
	void goScene2(){
		SceneManager.LoadScene ("scene2");
		gs.setScore (0);
	}

	//scene du menu
	void goScene3(){
		SceneManager.LoadScene ("scene3");
		gs.setScore (0);
	}
}
