using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


//using System.Linq;
//using System;
//using System.IO;
//using System.Text;

public class MenuScript : MonoBehaviour
{

    public Canvas quitMenu;

    public Button startButton;
    public Button exitButton;

  //  public Text text1;
    //public Text text2;



    // Use this for initialization
    void Start()
    {
        quitMenu = quitMenu.GetComponent<Canvas>();

        //text1 = text1.GetComponent<Text>();
        //text2 = text2.GetComponent<Text>();

        startButton = startButton.GetComponent<Button>();
        exitButton = exitButton.GetComponent<Button>();

        quitMenu.enabled = false;

    }

    public void ExitPress()
    {
        quitMenu.enabled = true;
        startButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
       // text1.enabled = false;
        //text2.enabled = false;

    }

    public void ReturnToMain()
    {
        quitMenu.enabled = false;
        startButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
       // text1.enabled = true;
       // text2.enabled = true;

    }


    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("CatAttackGame");
    }

    // Update is called once per frame
    void Update()
    {

    }



}
