using UnityEditor;

[CustomEditor(typeof(Question4))]
public class Question4Inspector : Editor {

	public override void OnInspectorGUI() {
		Question4 question4 = (Question4)target;
		question4.userName = EditorGUILayout.TextField("名前", question4.userName);
		question4.hp = EditorGUILayout.IntSlider("HP", question4.hp, 0, 10);
		question4.atk = EditorGUILayout.IntSlider("力", question4.atk, 0, 10);
		question4.agi = EditorGUILayout.IntSlider("すばやさ", question4.agi, 0, 10);
	}
}