using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Obi
{
#if UNITY_EDITOR

    public abstract class ObiBrushMode
    {

        protected ObiBlueprintPropertyBase property; 

        public abstract string name
        {
            get;
        }

        public virtual bool needsInputValue
        {
            get { return true; }
        }

        public ObiBrushMode(ObiBlueprintPropertyBase property)
        {
            this.property = property;
        }

        public abstract void ApplyStamps(ObiBrushBase brush, bool modified);
    }
#endif

}
