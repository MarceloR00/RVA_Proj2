using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    void Start() {
        GameObject laserGun = GameObject.Find("LaserGun");
        if (laserGun != null) {
            Transform laser = laserGun.transform.Find("Laser");
            if (laser != null) {
                laser.GetComponent<LaserManager>().SetupAndLaunchLaser();
                return;
            }
        }

        Debug.Log("Couldn't find Laser Gun!");
    }
}
