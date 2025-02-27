using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System;

namespace Obi
{
    public abstract class ObiRopeBlueprintBase : ObiActorBlueprint
    {
        [HideInInspector] [SerializeField] public ObiPath path = new ObiPath();
        public float thickness = 0.1f;

        [Range(0, 1)]
        public float resolution = 1;

        [HideInInspector] [SerializeField] protected float m_InterParticleDistance;
        [HideInInspector] [SerializeField] protected int totalParticles;
        [HideInInspector] [SerializeField] protected float m_RestLength;

        [HideInInspector] public float[] restLengths;

        public float interParticleDistance
        {
            get { return m_InterParticleDistance; }
        }

        public float restLength
        {
            get { return m_RestLength; }
        }


        private void Awake()
        {
            path.OnPathChanged.RemoveAllListeners();
            path.OnControlPointAdded.RemoveAllListeners();
            path.OnControlPointRemoved.RemoveAllListeners();
            path.OnControlPointRenamed.RemoveAllListeners();

            path.OnPathChanged.AddListener(GenerateImmediate);
            path.OnControlPointAdded.AddListener(ControlPointAdded);
            path.OnControlPointRemoved.AddListener(ControlPointRemoved);
            path.OnControlPointRenamed.AddListener(ControlPointRenamed);
        }

        protected void OnValidate()
        {
            GenerateImmediate();
        }

        protected void ControlPointAdded(int index)
        {
            var group = InsertNewParticleGroup(path.GetName(index), index);
        }

        protected void ControlPointRenamed(int index)
        {
            SetParticleGroupName(index, path.GetName(index));
        }

        protected void ControlPointRemoved(int index)
        {
            RemoveParticleGroupAt(index);
        }

        protected override IEnumerator Initialize() { yield return null; }
    }
}