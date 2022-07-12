namespace Levels.UnitConversion
{
    using UnityEngine;
    
    public class UnitConversions
    {
        private const float _FEET_IN_METER = 3.28084f;
        private const float _METER_IN_FOOT = 0.3048f;
    
        public static Vector3 MeterToFeet(Vector3 sourceMeter)
        { return sourceMeter * _FEET_IN_METER; }
        
        public static float MeterToFeet(float sourceMeter)
        { return sourceMeter * _FEET_IN_METER; }

        public static Vector3 FeetToMeter(Vector3 sourceFeet)
        { return sourceFeet * _METER_IN_FOOT; }
        
        public static float FeetToMeter(float sourceFeet)
        { return sourceFeet * _METER_IN_FOOT; }
    }
}

