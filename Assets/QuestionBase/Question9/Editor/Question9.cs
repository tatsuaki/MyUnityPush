using UnityEditor;
using UnityEditor.SceneManagement;
using System.Collections.Generic;

public class Question9
{

	private static List<string> scenePaths = new List<string>();

	[MenuItem("File/AdditiveScenes")]
	static void Additive()
	{
		scenePaths.Clear();

		while (true)
		{
			string sceneParh = EditorUtility.OpenFilePanel("Select Additive Scene", "Assets/Question9", "unity");

			if (string.IsNullOrEmpty(sceneParh))
			{
				break;
			}
			scenePaths.Add(sceneParh);
		}

		foreach (var scenePath in scenePaths)
		{
			string projectRelativePath = FileUtil.GetProjectRelativePath(scenePath);
			EditorSceneManager.OpenScene(projectRelativePath);
		}
	}

}