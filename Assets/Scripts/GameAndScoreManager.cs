using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;


public class GameAndScoreManager : MonoBehaviour {

    public Canvas gameOverMenu;
    public FirstPersonController playerController;



    void Start()
    {

        gameOverMenu = gameOverMenu.GetComponent<Canvas>();

        gameOverMenu.enabled = false;


    }


    // Update is called once per frame
    public void GameOver()
    {
        Cursor.visible = true;
        Screen.lockCursor = false;

        playerController.enabled = false;

        gameOverMenu.enabled = true;

    }

    public void ReturnToMain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void ReplayPress()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene("CatAttackGame");

    }



}
