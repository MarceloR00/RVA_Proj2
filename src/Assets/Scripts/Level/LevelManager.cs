using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager: MonoBehaviour {

    bool mapInPlace = false;
    bool laserReady = false;
    bool laserActive = false;
    float mapDetectedInstant = -1;
    float laserSetupTime = 1f;
    int numberOfTargetsReached = 0;
    LaserManager laserManager = null;

    [SerializeField] int numberOfTargetsToReach = 1;
    [SerializeField] GameObject gameInfo;
    [SerializeField] GameObject nextLevelMenu;
    [SerializeField] GameObject gameElements;

    void Update() {
        if (mapInPlace && !laserReady) {
            if (mapDetectedInstant < 0) return;

            if ((Time.time - mapDetectedInstant) < laserSetupTime) return;

            laserReady = true;
        }
        
        if(laserReady && !laserActive) {
            LaunchInitialLaser();
            laserActive = true;
        }
    }

    public bool GetLaserReady() {
        return laserReady;
    }

    public void LaunchInitialLaser() {
        GameObject laserGun = GameObject.Find("LaserGun");
        if (laserGun != null) {
            laserManager = laserGun.GetComponent<LaserManager>();
            laserManager.TurnOnLaserGun();
            return;
        }

        Debug.Log("Couldn't find Laser Gun!");
    }

    public void MapDetected() {
        mapInPlace = true;
        mapDetectedInstant = Time.time;
    }

    public void MapUndetected() {
        mapInPlace = false;
        laserReady = false;
        laserActive = false;
        mapDetectedInstant = -1;

        if (laserManager != null) {
            laserManager.TurnOffLaserGun();
        }
    }

    public void TargetReached() {
        numberOfTargetsReached += 1;

        if (numberOfTargetsReached == numberOfTargetsToReach) {
            LoadNextLevel();
        }
        
    }

    void LoadNextLevel() {
        gameInfo.SetActive(!gameInfo.activeSelf);
        gameElements.SetActive(!gameElements.activeSelf);
        nextLevelMenu.SetActive(!nextLevelMenu.activeSelf);
    }
}