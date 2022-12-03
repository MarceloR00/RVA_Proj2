using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPassed : MonoBehaviour
{

    [SerializeField] string nextSceneName;

    public void NextLevelActioned() {
        SceneManager.LoadScene(nextSceneName);
    }

    public void MainMenuActioned() {
        SceneManager.LoadScene("Scenes/MainMenu");
    }

    public void QuitActioned() {
        Application.Quit();
    }
}
