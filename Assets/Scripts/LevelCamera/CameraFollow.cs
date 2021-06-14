using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    private Rigidbody rCam;
    private SphereCollider cCam;
    public float CamDistance, CamAngle, CamAngleDeg;
    public GameObject ball;
    private Transform tball;
    private Rigidbody rball;
    private float ballDeathY;
    private Vector3 cameraPosition;
    void Start() {
        tball = ball.GetComponent<Transform>();
        rball = ball.GetComponent<Rigidbody>();

        ballDeathY = GameObject.Find("Ball").GetComponent<Death>().DeathY;
        CamAngle = Mathf.PI;
    }
    void LateUpdate() {

        CamAngleDeg = (180 / Mathf.PI) * CamAngle;
        if (Input.GetKey(KeyCode.LeftShift)) {
            if (Input.GetKeyDown(KeyCode.Q)) CamAngleDeg += 90;
            if (Input.GetKeyDown(KeyCode.E)) CamAngleDeg -= 90;
        } else {
            if (Input.GetKey(KeyCode.Q)) CamAngleDeg += 2;
            if (Input.GetKey(KeyCode.E)) CamAngleDeg -= 2;
        }
        CamAngle = (Mathf.PI / 180) * CamAngleDeg;

        int distanceMax = 20, distanceMin = 5;
        if (CamDistance > distanceMax) CamDistance = distanceMax;
        else if (CamDistance < distanceMin) CamDistance = distanceMin;
        if (Input.GetKey(KeyCode.V)) CamDistance += .5f;
        if (Input.GetKey(KeyCode.C)) CamDistance -= .5f;


        if (Input.GetKey(KeyCode.RightArrow)) CamAngle += .005f;
        if (Input.GetKey(KeyCode.LeftArrow)) CamAngle -= .005f;


        cameraPosition = tball.position + new Vector3(
                                            CamDistance * Mathf.Sin(CamAngle),
                                            CamDistance * 0.5f,
                                            CamDistance * Mathf.Cos(CamAngle)
                                          );
    }
    void FixedUpdate() {
        if (cameraPosition.y > ballDeathY) {
            transform.position = Vector3.Lerp(transform.position, cameraPosition, 0.125f);
        }
        transform.LookAt(tball.position + new Vector3(0, 1, 0));
    }
    float force = 1000; Vector3 dir;
    void OnCollisionEnter(Collision collision) {
        dir = collision.contacts[0].point - transform.position;
        dir = -dir.normalized;
        GetComponent<Rigidbody>().AddForce(dir * force);
    }
    void OnCollisionExit(Collision collision) {
        GetComponent<Rigidbody>().AddForce(-dir * force);
    }
}
