using UnityEngine;
using UnityEditor;

public class Question3 : EditorWindow {

	[MenuItem ("Question3/EditorWindow")]
	static void OpenWindow() {
		GetWindow<Question3>();
	}

	private string userName;
	private int hp, atk, agi;

	float angle = 0;
	int selected;

	void OnGUI() {
		if (Event.current.type == EventType.ContextClick) {
			GenericMenu genericMenu = new GenericMenu();
			genericMenu.AddItem(new GUIContent("Create Cube"), false,
				()=> GameObject.CreatePrimitive(PrimitiveType.Cube));
			genericMenu.ShowAsContext();
		}

		angle = EditorGUILayout.Knob (Vector2.one * 64,
			angle, 0, 360, "度", Color.gray, Color.red, true);

		selected = GUILayout.Toolbar (selected, new string[]{ "1", "2", "3" });
	}
}
