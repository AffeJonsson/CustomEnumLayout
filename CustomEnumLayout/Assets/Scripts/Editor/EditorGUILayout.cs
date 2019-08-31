using System;
using System.Linq;
using UnityEngine;

namespace UnityEditor
{
	public sealed partial class EditorGUILayoutExtended
	{
		#region PopupWithSpecificValues
		public static T PopupWithSpecificValues<T>(T selected, params T[] values) where T : IComparable
		{
			string[] names;
			int selectedIndex;
			GetNamesAndSelectedIndexFromValues(selected, values, out names, out selectedIndex);
			var newSelectedIndex = EditorGUILayout.Popup(selectedIndex, names);
			return values[newSelectedIndex];
		}

		public static T PopupWithSpecificValues<T>(string label, T selected, params T[] values) where T : IComparable
		{
			string[] names;
			int selectedIndex;
			GetNamesAndSelectedIndexFromValues(selected, values, out names, out selectedIndex);
			var newSelectedIndex = EditorGUILayout.Popup(label, selectedIndex, names);
			return values[newSelectedIndex];
		}

		public static T PopupWithSpecificValues<T>(GUIContent label, T selected, params T[] values) where T : IComparable
		{
			return PopupWithSpecificValues(label.text, selected, values);
		}

		public static T PopupWithSpecificValues<T>(string label, T selected, GUIStyle style, params T[] values) where T : IComparable
		{
			string[] names;
			int selectedIndex;
			GetNamesAndSelectedIndexFromValues(selected, values, out names, out selectedIndex);
			var newSelectedIndex = EditorGUILayout.Popup(label, selectedIndex, names, style);
			return values[newSelectedIndex];
		}

		public static T PopupWithSpecificValues<T>(GUIContent label, T selected, GUIStyle style, params T[] values) where T : IComparable
		{
			return PopupWithSpecificValues(label.text, selected, style, values);
		}

		private static void GetNamesAndSelectedIndexFromValues<T>(T selected, T[] values, out string[] names, out int selectedIndex) where T : IComparable
		{
			names = values.Select(v => v.ToString()).ToArray();
			selectedIndex = -1;
			for (var i = 0; i < values.Length; i++)
			{
				if (values[i].CompareTo(selected) == 0)
				{
					selectedIndex = i;
					break;
				}
			}
		}
		#endregion

		#region PopupWithoutSpecificValues
		public static T PopupWithoutSpecificValues<T>(T selected, params T[] excluded) where T : struct, IConvertible
		{
			if (!typeof(T).IsEnum)
			{
				Debug.LogError("Type <T> (" + typeof(T) + ") is not an enum type, which is required for method EditorGUILayoutExtended.PopupWithoutSpecificValues");
				return default(T);
			}
			string[] names;
			int selectedIndex;
			GetNamesAndSelectedIndexExcludingValues(selected, excluded, out names, out selectedIndex);
			var newSelectedIndex = EditorGUILayout.Popup(selectedIndex, names);
			return (T)Enum.Parse(typeof(T), names[newSelectedIndex]);
		}

		public static T PopupWithoutSpecificValues<T>(string label, T selected, params T[] excluded) where T : struct, IConvertible
		{
			if (!typeof(T).IsEnum)
			{
				Debug.LogError("Type <T> (" + typeof(T) + ") is not an enum type, which is required for method EditorGUILayoutExtended.PopupWithoutSpecificValues");
				return default(T);
			}
			string[] names;
			int selectedIndex;
			GetNamesAndSelectedIndexExcludingValues(selected, excluded, out names, out selectedIndex);
			var newSelectedIndex = EditorGUILayout.Popup(label, selectedIndex, names);
			return (T)Enum.Parse(typeof(T), names[newSelectedIndex]);
		}

		public static T PopupWithoutSpecificValues<T>(GUIContent label, T selected, params T[] excluded) where T : struct, IConvertible
		{
			return PopupWithoutSpecificValues(label.text, selected, excluded);
		}

		public static T PopupWithoutSpecificValues<T>(string label, T selected, GUIStyle style, params T[] excluded) where T : struct, IConvertible
		{
			if (typeof(T).IsEnum)
			{
				Debug.LogError("Type <T> (" + typeof(T) + ") is not an enum type, which is required for method EditorGUILayoutExtended.PopupWithoutSpecificValues");
				return default(T);
			}
			string[] names;
			int selectedIndex;
			GetNamesAndSelectedIndexExcludingValues(selected, excluded, out names, out selectedIndex);
			var newSelectedIndex = EditorGUILayout.Popup(label, selectedIndex, names, style);
			return (T)Enum.Parse(typeof(T), names[newSelectedIndex]);
		}

		public static T PopupWithoutSpecificValues<T>(GUIContent label, T selected, GUIStyle style, params T[] excluded) where T : struct, IConvertible
		{
			return PopupWithoutSpecificValues(label.text, selected, style, excluded);
		}

		private static void GetNamesAndSelectedIndexExcludingValues<T>(T selected, T[] excluded, out string[] names, out int selectedIndex) where T : struct, IConvertible
		{
			names = Enum.GetNames(typeof(T)).Except(excluded.Select(e => e.ToString())).ToArray();
			selectedIndex = -1;
			for (var i = 0; i < names.Length; i++)
			{
				if (selected.ToString() == names[i])
				{
					selectedIndex = i;
					return;
				}
			}
		}
		#endregion
	}
}
