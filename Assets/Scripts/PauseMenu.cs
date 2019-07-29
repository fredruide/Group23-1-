using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject objPauseMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseControl();
        }
    }

    public void PauseControl()
    {
            Debug.Log("press");

            if (Time.timeScale == 1)
            {
                Debug.Log("pause");
                Time.timeScale = 0;
                objPauseMenu.SetActive(true);
            }

            else if (Time.timeScale == 0)
            {
                Debug.Log("unpause");
                Time.timeScale = 1;
                objPauseMenu.SetActive(false);
            }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
