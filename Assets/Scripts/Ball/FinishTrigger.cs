using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour {
    public Rigidbody rball;
    private Collider cFinish;
    // Start is called before the first frame update
    void Start() {
        cFinish = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update() {

    }
    private void OnTriggerEnter(Collider cFinish) {
        GameObject.Find("ui_HealthText").GetComponent<HealthText>().HealthPoints = 3;
        //Vector3 refRespawnPosition = GameObject.Find("Ball").GetComponent<Death>().rRespawnXYZ.position;
        //rball.transform.position = Vector3.Lerp(rball.transform.position, refRespawnPosition, 1);
        //rball.rotation = new Quaternion(0, 0, 0, 0);
        //rball.velocity = new Vector3(0, 0, 0);
        SceneManager.LoadScene("MainMenu");
        SceneManager.UnloadSceneAsync("LevelDemo");
    }
}
