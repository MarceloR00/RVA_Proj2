using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            LaunchInitialLaser();
        }
    }

    public void LaunchInitialLaser() {
        GameObject laserGun = GameObject.Find("LaserGun");
        if (laserGun != null) {
            laserGun.GetComponent<LaserManager>().LaunchLaser();
            return;
        }

        Debug.Log("Couldn't find Laser Gun!");
    }
}
