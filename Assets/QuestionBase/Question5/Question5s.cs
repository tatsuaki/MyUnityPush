using UnityEngine;
using System.Collections;

public class Question5s : MonoBehaviour {

	public Vector3[] positions = new Vector3[] 
	{
		new Vector3(0, 0, 0),
		new Vector3(-5, 0, 0),
		new Vector3(0, 5, 0),
		new Vector3(0, 0, 5),
		new Vector3(5, -5, 5),
	};

	void OnDrawGizmos() {
		foreach(var potison in positions) {
			Gizmos.DrawWireSphere(potison, 0.5f);
		}
	}
}
