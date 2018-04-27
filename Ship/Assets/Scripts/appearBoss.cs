using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appearBoss : MonoBehaviour {
	private GameState gs;
	public int ennemyLife;

	// Use this for initialization
	void Start () {
		gs = gameObject.AddComponent<GameState> ();
	}
	
	// lorsque mon score est un multiple de 30, et s'il n'y a pas déja de boss ennemi, on en fait apparaître un
	void Update () {
		int mod = gs.getScore ();
		if((mod % 30 == 0) && (mod != 0) && (! GameObject.FindGameObjectWithTag ("boss"))){
			gs.setEnnemyLife (ennemyLife);
			Vector3 tmpPos = new Vector3(10.19f,1.29f,0);
			GameObject boss = Instantiate(Resources.Load("boss"),tmpPos, Quaternion.identity) as GameObject;
		}
	}
}
