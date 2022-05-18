using UnityEngine;
#if UNITY_EDITOR
#if UNITY_EDITOR
using UnityEditor;
#endif
#endif
using System.Collections;

namespace Obi
{
#if UNITY_EDITOR

    public abstract class ObiBlueprintRenderMode
    {
        protected ObiActorBlueprintEditor editor;
        public abstract string name
        {
            get;
        }
        public ObiBlueprintRenderMode(ObiActorBlueprintEditor editor)
        {
            this.editor = editor;
        }

        public virtual void DrawWithCamera(Camera camera) {}
        public virtual void OnSceneRepaint(SceneView sceneView) {}
        public virtual void Refresh(){}

        public virtual void OnDestroy() { }
    }
#endif

}