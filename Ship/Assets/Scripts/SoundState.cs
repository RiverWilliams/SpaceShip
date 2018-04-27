using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundState : MonoBehaviour {

	public AudioClip playerShotSound;

	public SoundState(){

	}

	// Use this for initialization
	void Start () {
		
	}

	//joue le son voulu
	void Update () {
		bool sp = Input.GetKeyDown(KeyCode.Space);
		if (sp) {
			touchButtonSound (playerShotSound);
		}
	}

	public void touchButtonSound(AudioClip audio) {
		MakeSound (audio);
	}

	private void MakeSound(AudioClip originalClip){
		AudioSource.PlayClipAtPoint (originalClip, new Vector3(0,0,0));
	}
}
