using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MonoBehaviour), true)]
public class AllSpawnerEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		IUISpawner uiSpawner = target as IUISpawner;

		if (uiSpawner != null)
		{
			GUILayout.Space(15);

			if (GUILayout.Button("Rigenera UI"))
			{
				uiSpawner.DrawUI();
			}
		}
	}
}
