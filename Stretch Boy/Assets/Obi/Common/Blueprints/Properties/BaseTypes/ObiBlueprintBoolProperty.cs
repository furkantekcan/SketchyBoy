using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

namespace Obi
{
#if UNITY_EDITOR

    public abstract class ObiBlueprintBoolProperty : ObiBlueprintProperty<bool>
    {
        public override bool Equals(int firstIndex, int secondIndex)
        {
            return Get(firstIndex) == Get(secondIndex);
        }

        public override void PropertyField()
        {
            value = EditorGUILayout.Toggle(name, value);
        }

        public override Color ToColor(int index)
        {
            return value ? Color.white : Color.gray;
        }
    }
#endif

}
