using UnityEngine;
#if UNITY_EDITOR

#if UNITY_EDITOR
using UnityEditor;
#endif
#endif

using System;
            

namespace Obi
{
#if UNITY_EDITOR

    public class ObiTethersTool
    {
        protected Rect tetherDropdownRect;
        protected bool[] tetheredGroups = new bool[0];

        // the GenericMenu.MenuFunction2 event handler for when a menu item is selected
        void OnTetherGroupSelected(object index)
        {
            int i = (int)index;
            tetheredGroups[i] = !tetheredGroups[i];
        }

        public void DoTethers(ObiActorBlueprintEditor editor)
        {
            EditorGUILayout.LabelField("Tethers", EditorStyles.boldLabel);

            var tethers = editor.Blueprint.GetConstraintsByType(Oni.ConstraintType.Tether);
            int tetherCount = 0;
            if (tethers != null)
                tetherCount = tethers.GetConstraintCount();
            
            if (tetherCount > 0)
                EditorGUILayout.LabelField("" + tetherCount + " tether constraints.", EditorStyles.helpBox);
            else
                EditorGUILayout.LabelField("No tether constraints. Select at least one particle group in the dropdown, then click 'Generate Tethers'.", EditorStyles.helpBox);

            Array.Resize(ref tetheredGroups, editor.Blueprint.groups.Count);

            // display the GenericMenu when pressing a button
            if (GUILayout.Button("Tethered groups", EditorStyles.popup))
            {
                // create the menu and add items to it
                GenericMenu menu = new GenericMenu();

                // forward slashes nest menu items under submenus
                for (int i = 0; i < editor.Blueprint.groups.Count; ++i)
                {
                    menu.AddItem(new GUIContent(editor.Blueprint.groups[i].name), tetheredGroups[i], OnTetherGroupSelected, i);
                }

                // display the menu
                menu.DropDown(tetherDropdownRect);
            }

            if (Event.current.type == EventType.Repaint)
                tetherDropdownRect = GUILayoutUtility.GetLastRect();


            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Generate tethers",GUILayout.MinHeight(32)))
            {
                // Select all particles in the tethered groups:
                for (int i = 0; i < editor.selectionStatus.Length; ++i)
                {
                    editor.selectionStatus[i] = false;
                    for (int j = 0; j < tetheredGroups.Length; ++j)
                    {
                        if (tetheredGroups[j] && editor.Blueprint.groups[j].ContainsParticle(i))
                        {
                            editor.selectionStatus[i] = true;
                            break;
                        }
                    }
                }

                editor.Blueprint.GenerateTethers(editor.selectionStatus);
                editor.Refresh();
            }

            if (GUILayout.Button("Clear tethers",GUILayout.MinHeight(32)))
            {
                editor.Blueprint.ClearTethers();
                editor.Refresh();
            }
            EditorGUILayout.EndHorizontal();

        }
    }
#endif

}
