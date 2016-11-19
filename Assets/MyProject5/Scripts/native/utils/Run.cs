//using UnityEngine;
//using System.Collections;
//
//public class Run : MonoBehaviour {
//
//	GameObject Player;
//	int horizon;
//	int vertical;
//	// Use this for initialization
//	void Start () {
//		Player = GameObject.Find ("Player");
//	}
//
//	// Update is called once per frame
//	void Update () {
//
//		if (Input.GetKey (KeyCode.RightArrow)) {
//			horizon = 10;
//
//			// object obj = Player.GetComponent();
//			Transform tran = (Transform)Player.GetComponent("transform");
//			//tran = new Vector3(horizon, tran.position.y, 0);
//		} else if (Input.GetKey (KeyCode.LeftArrow)) {
//			horizon = 10;
//			//Player.GetComponent().velocity = new Vector3(-horizon, Player.GetComponent().velocity.y, 0);
//		}
//		if (Input.GetButtonDown ("Jump")) {
//			vertical = 100;
//			//Player.GetComponent().velocity = new Vector3 (Player.GetComponent().velocity.x, vertical, 0);
//		}
//	}
//}