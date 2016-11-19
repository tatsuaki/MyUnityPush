using UnityEngine;
using UnityEditor;
using System.Collections;

public class Question1 : EditorWindow {

	[MenuItem ("Editor10/Question1")]
	static void OpenWindow() {
		GetWindow<Question1>();
	}

	void OnGUI() {
		Debug.Log ("Question1");
	}
}
