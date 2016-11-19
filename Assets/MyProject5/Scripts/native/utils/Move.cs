using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	GameObject Player;
	GameObject mainCamera;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");
		mainCamera = GameObject.Find ("MainCamera");
	}
	// Update is called once per frame
	void Update () {

		mainCamera.transform.position = new Vector3 (Player.transform.position.x, Player.transform.position.y, Player.transform.position.z - 10);

	}
}