
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class Buttons_MainMenu : MonoBehaviour {

    //// 105.5    -9  -332 /// Offset

    ////     Button idle: (104, 71, 43)   #68472b
    //// Button selected: (255,255,255)   #ffffff

    ////       Text idle: (233,209,169)   #e9d1a9
    ////   Text selected: ( 78, 58, 35)   #4e3a23


    public TextMeshProUGUI text;
    private RectTransform rtbutton;
    private Transform tMainMenu;
    private CanvasGroup gMainMenu;
    private Transform tLevelsMenu;
    public Animator animMenuFly;
    public Animator animFade;
    public float animationWait;


    float tbuttonZset; RectTransform tbuttonFinal; bool bSel = false;
    float tMainMenuZset; Vector3 tMainMenuFinal; bool tMainMenuFly = false; float alphaMainMenu = 1;

    private float tMainMenuZoriginal;
    private static float tbuttonX, tbuttonY;
    void Start() {
        rtbutton = GetComponent<RectTransform>();
        tbuttonX = rtbutton.position.x; tbuttonY = rtbutton.position.y;


        tMainMenu = GameObject.Find("Buttons-MainMenu").GetComponent<Transform>();
        gMainMenu = GameObject.Find("Buttons-MainMenu").GetComponent<CanvasGroup>();
        tMainMenuZoriginal = tMainMenu.position.z;

        text.color = new Color32(233, 209, 169, 255);
    }


    void FixedUpdate() {
        if (bSel) {
            tbuttonZset = -50;
            //tbuttonFinal.sizeDelta
        } else {
            tbuttonZset = 0;
        }
        tbuttonFinal.localPosition = new Vector3(rtbutton.localPosition.x, rtbutton.localPosition.y, tbuttonZset);


        if (tMainMenuFly) {
            tMainMenuZset = 500;
            gMainMenu.interactable = false;
            alphaMainMenu = 0;
        } else {
            tMainMenuZset = tMainMenuZoriginal;
            gMainMenu.interactable = true;
            alphaMainMenu = 1;
        }
        tMainMenuFinal = new Vector3(tMainMenu.position.x, tMainMenu.position.y, tMainMenuZset);
    }
    void LateUpdate() {
        rtbutton.localPosition = Vector3.Lerp(rtbutton.localPosition, tbuttonFinal, .125f);

        tMainMenu.position = Vector3.Lerp(tMainMenu.position, tMainMenuFinal, .125f);
        gMainMenu.alpha = Mathf.Lerp(gMainMenu.alpha, alphaMainMenu, .125f);

    }
    public void PointerEnter() {
        bSel = true;
        text.color = new Color32(78, 58, 35, 255);
    }
    public void PointerExit() {
        bSel = false;
        text.color = new Color32(233, 209, 169, 255);
    }
    public void OnSelect() {
        bSel = true;
        text.color = new Color32(78, 58, 35, 255);
    }
    public void OnDeselect() {
        bSel = false;
        text.color = new Color32(233, 209, 169, 255);
    }
    public bool MenuFliedAway = false;
    public void OnClick() {

        switch (gameObject.name) {
            case "Start-MainMenu":
                StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
                break;
            case "Levels-MainMenu":
                tMainMenuFly = true; //LevelsMenu(true);
                break;
            case "Options-MainMenu":

                break;
            case "About-MainMenu":

                break;
            case "Close-MainMenu":
                Application.Quit();//CloseConfirm();
                break;
        }
        if (Input.GetKeyDown(KeyCode.Escape)) CloseConfirm();
    }
    IEnumerator LoadLevel(int LevelIndex) {
        animFade.SetTrigger("Start");
        SceneManager.LoadScene(LevelIndex);
        yield return new WaitForSeconds(animationWait);
    }

    IEnumerator LevelsMenu(bool SetMenuFliedAway) {
        MenuFliedAway = SetMenuFliedAway;
        animMenuFly.SetTrigger("MenuFly_Out");
        yield return new WaitForSeconds(animationWait);
    }
    void CloseConfirm() {
        Application.Quit();
    }
}
