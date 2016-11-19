//using UnityEngine;
//using UnityEditor;
//using System.Collections;
//
//public class MyEditor : EditorWindow {
//	private static int target = -1;
//   
////	[MenuItem ("Editor10/Question3 _c")]
////	static void ShowQuestion3() {
////		EditorWindow.GetWindow<MyEditor>( "Question3" );
////		Debug.Log ("ShowQuestion3");
////		target = 3;
////	}
////
////	[MenuItem ("Editor10/Question4")]
////	static void ShowQuestion4() {
////		Debug.Log ("ShowQuestion4");
////		target = 4;
////	}
//
////    void OnGUI()
////    {
////		if (Event.current.type == EventType.ContextClick) {
////			GenericMenu genericMenu = new GenericMenu();
////			genericMenu.AddItem(new GUIContent("CreateCube"), false, Callback, "item 1");
////			genericMenu.ShowAsContext();
////			Debug.Log ("右クリックされました!");
////    }
////
////	public static void Callback(object obj) {
////		Debug.Log ("Callback!");
////	}
////
//	// Use this for initialization
//	void Start () {
//	
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
//}
