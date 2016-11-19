using UnityEditor;
using UnityEngine;

public class Qustion7Editor
{
	[MenuItem("Question7/Create")]
	static void CreateAsset()
	{
		Question7 question7 = ScriptableObject.CreateInstance<Question7>();
		AssetDatabase.CreateAsset(question7, "Assets/QuestionBase/Question7/Question7.asset");
	}
}
