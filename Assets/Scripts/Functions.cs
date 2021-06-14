using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functions : MonoBehaviour {
    /*  
        Call this using:
            private Functions fun = GameObject.FindObjectOfType(typeof(Functions)) as Functions;
    
    */
    public float ForceInRange(ref float input, float min, float max) {
        if (input > max) return max;
        else if (input < min) return min;
        else return input;
    }
    public float ASinSmooth_StartEnd(float linear, float scale) {
        if (linear > 0 && linear < scale)
            return scale * (1 - (4 / Mathf.Pow(Mathf.PI, 2))
                * (Mathf.Pow(Mathf.Asin((2 * linear / scale) - 1), 2)));
        else if (linear < 0 && linear > scale)
            return -scale + scale * ((4 / Mathf.Pow(Mathf.PI, 2))
                * (Mathf.Pow(Mathf.Asin((2 * linear / scale) + 1), 2)));
        else return 0;
    }
    public float SinSmooth_StartEnd(float Linear, float range) {
        return range * Mathf.Sin((Mathf.PI * Linear) / range);
    }
    public float TanSmooth(float Linear50) {
        return 32 * Mathf.Tan(Linear50 / 50);
    }
    public float ASinSmooth(float Linear01) {
        return 4 / Mathf.Pow(Mathf.PI, 2) * Mathf.Pow(Mathf.Asin(2 * Linear01), 2);
    }
}
