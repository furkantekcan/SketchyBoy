using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections.Generic;

namespace Obi
{
#if UNITY_EDITOR

    public class ObiBlueprintRenderModeAerodynamicConstraints : ObiBlueprintRenderMode
    {
        public override string name
        {
            get { return "Aerodynamic constraints"; }
        }

        public ObiMeshBasedActorBlueprintEditor meshBasedEditor
        {
            get { return editor as ObiMeshBasedActorBlueprintEditor; }
        }

        public ObiBlueprintRenderModeAerodynamicConstraints(ObiMeshBasedActorBlueprintEditor editor) : base(editor)
        {
        }

        public override void OnSceneRepaint(SceneView sceneView)
        {
            var meshEditor = editor as ObiMeshBasedActorBlueprintEditor;
            if (meshEditor != null)
            {
                // Get per-particle normals:
                Vector3[] normals = meshEditor.sourceMesh.normals;
                Vector3[] particleNormals = new Vector3[meshEditor.Blueprint.particleCount];
                for (int i = 0; i < normals.Length; ++i)
                {
                    int welded = meshEditor.VertexToParticle(i);
                    particleNormals[welded] = normals[i];
                }

                using (new Handles.DrawingScope(Color.blue, Matrix4x4.identity))
                {
                    var constraints = editor.Blueprint.GetConstraintsByType(Oni.ConstraintType.Aerodynamics) as ObiConstraints<ObiAerodynamicConstraintsBatch>;
                    if (constraints != null)
                    {
                        Vector3[] lines = new Vector3[constraints.GetActiveConstraintCount() * 2];
                        int lineIndex = 0;

                        foreach (var batch in constraints.batches)
                        {
                            for (int i = 0; i < batch.activeConstraintCount; ++i)
                            {
                                int particleIndex = batch.particleIndices[i];
                                Vector3 position = editor.Blueprint.GetParticlePosition(particleIndex);
                                lines[lineIndex++] = position;
                                lines[lineIndex++] = position + particleNormals[particleIndex] * 0.025f;
                            }
                        }

                        Handles.DrawLines(lines);
                    }
                }
            }
        }

    }
#endif

}