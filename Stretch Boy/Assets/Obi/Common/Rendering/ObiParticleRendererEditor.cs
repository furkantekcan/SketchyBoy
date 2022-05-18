#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Obi{

	/**
	 * Custom inspector for ObiParticleRenderer component. 
	 */
#if UNITY_EDITOR

	[CustomEditor(typeof(ObiParticleRenderer)), CanEditMultipleObjects] 
	public class ObiParticleHandleEditor : Editor
	{
		
		public override void OnInspectorGUI() {
			
			serializedObject.UpdateIfRequiredOrScript();
			
			Editor.DrawPropertiesExcluding(serializedObject,"m_Script");
			
			// Apply changes to the serializedProperty
			if (GUI.changed){
				
				serializedObject.ApplyModifiedProperties();
				
			}
			
		}
		
	}
#endif

}

