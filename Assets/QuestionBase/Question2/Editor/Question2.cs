using UnityEngine;
using UnityEditor;
using System.Collections;

public class Question2 : EditorWindow {

	[MenuItem ("Editor10/Question2 #")]
	static void OpenWindow() {
		GetWindow<Question2>();
	}

	private string userName;
	private int hp, atk, agi;

	void OnGUI() {
		userName = EditorGUILayout.TextField("名前", userName);
		hp = EditorGUILayout.IntSlider("HP", hp, 0, 10);
		atk = EditorGUILayout.IntSlider("力", atk, 0, 10);
		agi = EditorGUILayout.IntSlider("すばやさ", agi, 0, 10);
	}
}
