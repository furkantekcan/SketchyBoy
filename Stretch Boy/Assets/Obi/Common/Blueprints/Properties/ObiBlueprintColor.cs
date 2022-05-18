using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

namespace Obi
{
#if UNITY_EDITOR

    public class ObiBlueprintColor : ObiBlueprintColorProperty
    {
        public ObiBlueprintColor(ObiActorBlueprintEditor editor) : base(editor)
        {
            brushModes.Add(new ObiColorPaintBrushMode(this)); 
            brushModes.Add(new ObiColorSmoothBrushMode(this)); 
        }

        public override string name
        {
            get { return "Color"; }
        }

        public override Color Get(int index)
        {
            return editor.Blueprint.colors[index];
        }
        public override void Set(int index, Color value)
        {
            editor.Blueprint.colors[index] = value;
        }
        public override bool Masked(int index)
        {
            return !editor.Editable(index);
        }

    }
#endif

}
