using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    [SerializeField] GameObject gameInfo;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameElements;

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            EscapeActioned();
        }
    }
    
    public void EscapeActioned() {
        gameInfo.SetActive(!gameInfo.activeSelf);
        gameElements.SetActive(!gameElements.activeSelf);
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }

    public void MainMenuActioned() {
        SceneManager.LoadScene("Scenes/MainMenu");
    }

    public void QuitActioned() {
        Application.Quit();
    }
}