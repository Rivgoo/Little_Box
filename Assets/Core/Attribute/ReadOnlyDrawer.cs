using UnityEngine;

#if UNITY_EDITOR
 	[UnityEditor.CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
	internal class ReadOnlyDrawer : UnityEditor.PropertyDrawer 
 	{
		public bool DebugMode = true;
		
     	public override void OnGUI(Rect position, UnityEditor.SerializedProperty property, GUIContent label)
     	{
     		GUI.enabled = false;
     		 
     		if (DebugMode)
     		{
     			UnityEditor.EditorGUI.PropertyField(position, property, label, true);
     		}
     		else
     		{
     		 	var style = new GUIStyle();
     		 	style.fontSize = 11;
     		 	
	         	UnityEditor.EditorGUI.LabelField(position, "Disable Debug Mode", style);
     		}
	         GUI.enabled = true;
     	}
 	}
#endif
