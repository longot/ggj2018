using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameScript : MonoBehaviour {
	private GameManagerScript gameManager;
	public GameObject panel;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown(){
		gameManager.gamePlay = true;
		transform.Translate (new Vector3(0,-5,0));
		panel.transform.Translate (new Vector3(0,-5,0));
	}
}
