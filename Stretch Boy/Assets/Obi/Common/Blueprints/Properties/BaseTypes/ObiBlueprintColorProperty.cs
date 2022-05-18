using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

namespace Obi
{
#if UNITY_EDITOR

    public abstract class ObiBlueprintColorProperty : ObiBlueprintProperty<Color>
    {

        public ObiActorBlueprintEditor editor;

        public ObiBlueprintColorProperty(ObiActorBlueprintEditor editor)
        {
            this.editor = editor;
        }

        public override bool Equals(int firstIndex, int secondIndex)
        {
            return Get(firstIndex) == Get(secondIndex);
        }

        public override void PropertyField()
        {
            value = EditorGUILayout.ColorField(name, value);
        }

        public override Color ToColor(int index)
        {
            return editor.Blueprint.colors[index];
        }

    }
#endif

}
