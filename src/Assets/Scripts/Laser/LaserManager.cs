using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{
    ISetupLaser setupLaser;
    ILauncherMethod launcherMethod;

    Vector3 laserStartPoint;
    Vector3 laserDirection;
    Vector3 laserEndPoint;

    void Start()
    {
        setupLaser = GetComponent<ISetupLaser>();
        launcherMethod = GetComponent<ILauncherMethod>();

        SetupAndLaunchLaser();
    }

    void SetupAndLaunchLaser() {
        SetupLaser();
        LaunchLaser();
    }

    void SetupLaser() {
        laserStartPoint = setupLaser.GetLaserStartPoint();
        laserDirection = setupLaser.GetLaserDirection();
        laserEndPoint = setupLaser.GetLaserEndPoint(laserStartPoint, laserDirection);
    }

    void LaunchLaser() {
        launcherMethod.Launch(laserStartPoint, laserEndPoint);
    }
}
