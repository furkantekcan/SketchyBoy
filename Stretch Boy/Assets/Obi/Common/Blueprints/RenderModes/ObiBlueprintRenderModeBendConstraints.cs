using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections.Generic;

namespace Obi
{
#if UNITY_EDITOR

    public class ObiBlueprintRenderModeBendConstraints : ObiBlueprintRenderMode
    {
        public override string name
        {
            get { return "Bend constraints"; }
        }

        public ObiBlueprintRenderModeBendConstraints(ObiActorBlueprintEditor editor) : base(editor)
        {
        }

        public override void OnSceneRepaint(SceneView sceneView)
        {
            using (new Handles.DrawingScope(Color.magenta, Matrix4x4.identity))
            {
                var constraints = editor.Blueprint.GetConstraintsByType(Oni.ConstraintType.Bending) as ObiConstraints<ObiBendConstraintsBatch>;
                if (constraints != null)
                {
                    Vector3[] lines = new Vector3[constraints.GetActiveConstraintCount() * 2];
                    int lineIndex = 0;

                    foreach (var batch in constraints.batches)
                    {
                        for (int i = 0; i < batch.activeConstraintCount; ++i)
                        {
                            lines[lineIndex++] = editor.Blueprint.GetParticlePosition(batch.particleIndices[i * 3]);
                            lines[lineIndex++] = editor.Blueprint.GetParticlePosition(batch.particleIndices[i * 3 + 1]); 
                        }
                    }

                    Handles.DrawLines(lines);
                }
            } 
             
        }

    }
#endif

}