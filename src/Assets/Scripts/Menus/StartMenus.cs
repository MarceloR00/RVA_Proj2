using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenus : MonoBehaviour
{
    public void EasyActioned() {
        SceneManager.LoadScene("Scenes/Levels/Easy/LevelOneEasy");
    }

    public void NormalActioned() {
        SceneManager.LoadScene("Scenes/Levels/Normal/LevelOneNormal");
    }

    public void HardActioned() {
        SceneManager.LoadScene("Scenes/Levels/Hard/LevelOneHard");
    }

    public void QuitActioned() {
        Application.Quit();
    }
}
