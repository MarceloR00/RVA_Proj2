using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOneEasyManager : LevelManager
{
    protected override void LoadNextLevel() {
        SceneManager.LoadScene("Scenes/Levels/Easy/LevelTwoEasy");
    }
}
