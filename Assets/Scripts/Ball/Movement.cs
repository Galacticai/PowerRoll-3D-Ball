using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Movement : MonoBehaviour {
    public float Speed, maxSpeed, jumpHeight;
    public bool bouncyBall;
    private Rigidbody rball;

    void Start() {
        rball = GetComponent<Rigidbody>();
    }
    void FixedUpdate() {
        float CamAngle = GameObject.Find("Main Camera").GetComponent<CameraFollow>().CamAngle;


        Vector3 Inputs = new Vector3(Input.GetAxis("Horizontal") * Mathf.Sin(CamAngle),
                                     Input.GetAxis("Jump"),
                                     Input.GetAxis("Vertical") * Mathf.Cos(CamAngle));

        if (Input.GetKey(KeyCode.RightArrow)) Inputs.x = -1f;
        if (Input.GetKey(KeyCode.LeftArrow)) Inputs.x = 1f;
        if (Input.GetKey(KeyCode.UpArrow)) Inputs.z = -1f;
        if (Input.GetKey(KeyCode.DownArrow)) Inputs.z = 1f;

        if (Input.GetKeyDown(KeyCode.Space) && bouncyBall) Inputs.y = jumpHeight;

        Vector3 rballV = rball.velocity; //Speed cap
        if (rballV.x > maxSpeed) rballV.x = maxSpeed;
        else if (rballV.x < -maxSpeed) rballV.x = -maxSpeed;
        if (rballV.y > maxSpeed) rballV.y = maxSpeed;
        else if (rballV.y < -maxSpeed) rballV.y = -maxSpeed;
        if (rballV.z > maxSpeed) rballV.z = maxSpeed;
        else if (rballV.z < -maxSpeed) rballV.z = -maxSpeed;

        float CamAngleDeg = (180 / Mathf.PI) * CamAngle;
        Vector3 FinalInputs = Quaternion.AngleAxis(CamAngleDeg, Vector3.up) * Inputs;
        rball.AddForce(FinalInputs * Speed);

        rball.inertiaTensorRotation = new Quaternion(0.01f, 0.01f, 0.01f, 1);
        rball.AddTorque(-rball.angularVelocity * .1f);
    }
}
