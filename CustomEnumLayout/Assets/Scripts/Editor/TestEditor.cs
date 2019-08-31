using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Editor
{
	[CustomEditor(typeof(Test))]
	public class TestEditor : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			var t = (Test)target;
			t.Enum1 = EditorGUILayoutExtended.PopupWithSpecificValues(t.Enum1, TestEnum.A, TestEnum.B);
			t.Enum2 = EditorGUILayoutExtended.PopupWithoutSpecificValues(t.Enum2, TestEnum.F);
			serializedObject.ApplyModifiedProperties();
		}
	}
}