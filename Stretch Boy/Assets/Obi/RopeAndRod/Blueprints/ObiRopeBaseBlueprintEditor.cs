using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections.Generic;
using System.Collections;
using System;

namespace Obi
{
#if UNITY_EDITOR

    [CustomEditor(typeof(ObiRopeBlueprintBase), true)]
    public class ObiRopeBaseBlueprintEditor : ObiActorBlueprintEditor
    {

        public override void OnInspectorGUI()
        {

            serializedObject.UpdateIfRequiredOrScript();

            EditorGUILayout.BeginVertical(EditorStyles.inspectorDefaultMargins);
            Editor.DrawPropertiesExcluding(serializedObject, "m_Script");

            EditorGUILayout.EndVertical();

            if (GUI.changed)
            {
                serializedObject.ApplyModifiedProperties();

                // There might be blueprint editing operations that have no undo entry, so do this to 
                // ensure changes are serialized to disk by Unity.
                EditorUtility.SetDirty(this);
            }
        }
    }

#endif

}
