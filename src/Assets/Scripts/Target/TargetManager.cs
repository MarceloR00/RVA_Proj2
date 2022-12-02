using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    ILevelManager levelManager = null;

    void Start() {
        GameObject obj = GameObject.Find("LevelManager");
        if (obj != null) {
            levelManager = obj.GetComponent<ILevelManager>();
        }
    }

    public void LaserHit() {
        if (levelManager == null) {
            Debug.Log("Couldn't find LevelManager");
            return;
        }

        levelManager.LoadNextLevel();
    }
}
