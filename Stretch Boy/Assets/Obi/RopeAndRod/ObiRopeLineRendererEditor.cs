#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Obi{
#if UNITY_EDITOR

	[CustomEditor(typeof(ObiRopeLineRenderer)), CanEditMultipleObjects] 
	public class  ObiRopeLineRendererEditor : Editor
	{
		
		ObiRopeLineRenderer renderer;
		
		public void OnEnable(){
			renderer = (ObiRopeLineRenderer)target;
		}
		
		public override void OnInspectorGUI() {
			
			serializedObject.UpdateIfRequiredOrScript();
			
			Editor.DrawPropertiesExcluding(serializedObject,"m_Script");
			
			// Apply changes to the serializedProperty
			if (GUI.changed){
				
				serializedObject.ApplyModifiedProperties();
				
                renderer.UpdateRenderer(null);
				
			}
			
		}
		
	}
#endif

}

