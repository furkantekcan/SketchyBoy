using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

namespace Obi
{
#if UNITY_EDITOR

    public class ObiBlueprintRadius : ObiBlueprintFloatProperty
    {

        public ObiBlueprintRadius(ObiActorBlueprintEditor editor) : base(editor,0.0000001f) 
        { 
            brushModes.Add(new ObiFloatPaintBrushMode(this)); 
            brushModes.Add(new ObiFloatAddBrushMode(this)); 
            brushModes.Add(new ObiFloatSmoothBrushMode(this)); 
        }

        public override string name
        {
            get { return "Radius"; }
        }

        public override float Get(int index)
        {
            return editor.Blueprint.principalRadii[index][0];
        }
        public override void Set(int index, float value)
        {
            value = Mathf.Max(0.0000001f, value);
            float ratio = value / Get(index);
            editor.Blueprint.principalRadii[index] = editor.Blueprint.principalRadii[index] * ratio;
        }
        public override bool Masked(int index)
        {
            return !editor.Editable(index);
        }
    }
#endif

}
