using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    bool mapInPlace = false;
    LaserManager laserManager = null; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.Space) && mapInPlace) {
            LaunchInitialLaser();
        }
    }

    public void LaunchInitialLaser() {
        GameObject laserGun = GameObject.Find("LaserGun");
        if (laserGun != null) {
            laserManager = laserGun.GetComponent<LaserManager>();
            laserManager.LaunchLaser();
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
            laserManager.RemoveLaser();
        }
    }
}
