using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTwoEasyManager : LevelManager
{
    protected override void LoadNextLevel() {
        SceneManager.LoadScene("Scenes/Levels/Easy/LevelOneEasy");
    }
}
