using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    Image imgYou;       // your selected image (rock, paper scissor)
    Image imgCom;       // computer selected image (rock, paper scissor)

    Text txtYou;        // the score you win
    Text txtCom;        // the score computer win
    Text txtResult;     // the result
   
    int cntYou = 0;     // number you win
    int cntCom = 0;     // number computer win
    SwitchScene switchScene; // instance or object of the class Swich Scene

    private void InitGame()
    {
        imgYou = GameObject.Find("ImgYou").GetComponent<Image>();
        imgCom = GameObject.Find("ImgCom").GetComponent<Image>();

        txtYou = GameObject.Find("TxtYou").GetComponent<Text>();
        txtCom = GameObject.Find("TxtCom").GetComponent<Text>();
        txtResult = GameObject.Find("TxtResult_").GetComponent<Text>();
      
        //init the text before the game start
        txtResult.text = "Select the button below";
    }

    void Start()
    {
        // init the game
        InitGame();
        switchScene = GameObject.FindObjectOfType<SwitchScene>();
    }

    // Update is called once per frame
    void Update()
    {
        //exit if press escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void OnButtonClick(GameObject buttonObject)
    {
        //event when button is clicked
        int you = int.Parse(buttonObject.name.Substring(0, 1));
        CheckResult(you);
        Debug.Log("clicked: " + you);
    }

    void CheckResult(int yourResult)
    {
        // algorithm determine the result

        int comResult = UnityEngine.Random.Range(1, 4);
        int k = yourResult - comResult;
        if (k == 0)
        {
            txtResult.text = "Draw.";
        }
        else if (k == 1 || k == -2)
        {
            cntYou++;
            txtResult.text = "You win.";
        }
        else
        {
            cntCom++;
            txtResult.text = "Computer win.";
        }
        SetResult(yourResult, comResult);    // set game result to UI
        GetFinalResult();
    }
  
    void GetFinalResult(){
        if (cntYou==5){
            switchScene.LoadVictoryScene();
        }
        else if (cntCom==5){
            switchScene.LoadGameOverScene();
        }
    }

    void SetResult(int you, int com)
    {
        // change image
        imgYou.sprite = Resources.Load("img_" + you, typeof(Sprite)) as Sprite;
        imgCom.sprite = Resources.Load("img_" + com, typeof(Sprite)) as Sprite;

        // invert image com in x axis
        imgCom.transform.localScale = new Vector3(-1, 1, 1);
        // winning score
        txtYou.text = cntYou.ToString();
        txtCom.text = cntCom.ToString();
    }
  
    // method to restart game, reset to start
    public void onRestartGame()
    {

        cntYou = 0;
        cntCom = 0;

        // Reset text
        txtYou.text = "0";
        txtCom.text = "0";

        InitGame();

    }
}
