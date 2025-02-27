#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Obi
{
#if UNITY_EDITOR

    [CustomEditor(typeof(ObiPathSmoother), true), CanEditMultipleObjects]
    public class ObiPathSmootherEditor : Editor
    {

        ObiPathSmoother shape;

        public void OnEnable()
        {
            shape = (ObiPathSmoother)target;
        }

        public override void OnInspectorGUI()
        {

            serializedObject.UpdateIfRequiredOrScript();

            Editor.DrawPropertiesExcluding(serializedObject, "m_Script");

            // Apply changes to the serializedProperty
            if (GUI.changed)
                serializedObject.ApplyModifiedProperties();

        }

    }
#endif

}

