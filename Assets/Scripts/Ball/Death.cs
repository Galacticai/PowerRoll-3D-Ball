using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour {
    public float DeathY;
    public Rigidbody rRespawnXYZ;
    private Vector3 rballDeathPos;
    private bool Dead, Respawned;
    private float HealthPoints;
    void start() {
        rballDeathPos = transform.position;
        HealthPoints = GameObject.Find("ui_HealthText").GetComponent<HealthText>().HealthPoints;
    }

    void FixedUpdate() {
        if (transform.position.y < DeathY) {
            if (Respawned) Dead = true;
            if (Dead && HealthPoints > 0) {
                HealthPoints -= 1;
                Dead = false;
            }
        }
    }
    float DeadTime = 0;
    void LateUpdate() {
        if (transform.position.y <= DeathY) {
            DeadTime += Time.deltaTime;
            if (DeadTime >= 5) {
                SceneManager.LoadScene("MainMenu");
                SceneManager.UnloadSceneAsync("LevelDemo");
                DeadTime = 0;
            }
            /*rball.useGravity = false;
            cball.enabled = false;
            rball.velocity = Vector3.zero;
            transform.rotation = Qzero.normalized;
            transform.position = Vector3.Lerp(transform.position, rRespawnXYZ.position, .125f);
            cball.enabled = true;
            rball.useGravity = true;
            Dead = false;*/
        }
    }
}
