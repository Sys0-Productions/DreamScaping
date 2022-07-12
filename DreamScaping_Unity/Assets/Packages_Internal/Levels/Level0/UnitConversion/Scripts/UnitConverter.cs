namespace Levels.UnitConversion
{
    using System;
    using UnityEngine;
    using Levels.DataTypes;
    using Unity.VisualScripting;
    using UnityEditor;

    // TODO: Make custom drawer with Odin
    [ExecuteInEditMode]
    public class UnitConverter : MonoBehaviour
    {
        private bool _dirty;

        public Units UnitTo;

        [SerializeField] public Vector3 Size;
        [SerializeField] public Vector3 Position;

        private void Update()
        {
            if (!Selection.activeTransform)
                return;
            
            var holder = Selection.activeTransform.gameObject;

            if (gameObject.IsUnityNull())
            {
                // TODO: Add the other units to switch between.
                switch (UnitTo)
                {
                    case Units.Feet:
                        Size = UnitConversions.MeterToFeet(transform.localScale);
                        Position = UnitConversions.MeterToFeet(transform.position);
                        break;
                }
                
                _dirty = false;
            }
            else if (!_dirty && holder != this.gameObject)
            {
                _dirty = true;
            }
        }

        private void OnValidate()
        {
            // TODO: Add the other units to switch between.
            switch (UnitTo)
            {
                case Units.Feet:
                    transform.localScale = UnitConversions.FeetToMeter(Size);
                    transform.position = UnitConversions.FeetToMeter(Position);
                    break;
            }

        }
    }
}

