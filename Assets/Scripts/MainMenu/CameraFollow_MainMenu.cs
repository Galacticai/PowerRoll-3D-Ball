using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow_MainMenu : MonoBehaviour {
    private Vector3 CamPos;
    void FixedUpdate() {
        Vector2 MousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 DisplaySize = new Vector2(Screen.width, Screen.height);
        // ]-inf, (  0 , screenXY), inf[
        Vector2 MousePos100 = (MousePos / DisplaySize) * 100;
        // ]-inf, (  0 , 100) , inf[
        MousePos100.x = ForceInRange(MousePos100.x, 0, 100);
        MousePos100.y = ForceInRange(MousePos100.y, 0, 100);
        // [  0 , 100]
        MousePos100.x -= 50; MousePos100.y -= 50;
        // [-50 , 50 ]
        Vector2 MousePosCentered
            = new Vector2(SinSmooth_StartEnd(MousePos100.x, 100),
                          SinSmooth_StartEnd(MousePos100.y, 100));

        CamPos = new Vector3( MousePosCentered.x,  MousePosCentered.y, transform.position.z);
    }
    void LateUpdate() {
        transform.position = CamPos;
        transform.LookAt(new Vector3( CamPos.x / 2,  CamPos.y / 2, 0));
    }

    float ForceInRange(float input, float min, float max) {
        if (input > max) return max;
        else if (input < min) return min;
        else return input;
    }
    float SinSmooth_StartEnd(float linearSpace, float scale) {
        return (Mathf.Sin((Mathf.PI * linearSpace) / scale)) * scale;
    }
    float ASinSmooth_StartEnd(float linear, float scale) {
        if (linear > 0)
            return scale * (1 - (4 / Mathf.Pow(Mathf.PI, 2))
                * (Mathf.Pow(Mathf.Asin((2 * linear / scale) - 1), 2)));
        else if (linear < 0)
            return -scale + scale * ((4 / Mathf.Pow(Mathf.PI, 2))
                * (Mathf.Pow(Mathf.Asin((2 * linear / scale) + 1), 2)));
        else return 0;
    }
    float TanSmooth(float Linear50) {
        return 32 * Mathf.Tan(Linear50 / 50);
    }
    float ASinSmooth(float Linear01) {
        return 4 / Mathf.Pow(Mathf.PI, 2) * Mathf.Pow(Mathf.Asin(2 * Linear01), 2);
    }


}
