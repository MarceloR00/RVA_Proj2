using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelManager: MonoBehaviour {

    bool mapInPlace = false;
    LaserManager laserManager = null;
    [SerializeField] int numberOfTargetsToReach = 1;
    int numberOfTargetsReached = 0;

    protected abstract void LoadNextLevel();

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space) && mapInPlace) {
            LaunchInitialLaser();
        }
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
    }

    public void MapUndetected() {
        mapInPlace = false;
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

}