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

    GameObject target;

    void Awake() {
        setupLaser = GetComponent<ISetupLaser>();
        launcherMethod = GetComponent<ILauncherMethod>();
    }

    public void SetupAndLaunchLaser() {
        SetupLaser();
        LaunchLaser();
    }

    void SetupLaser() {
        laserStartPoint = setupLaser.GetLaserStartPoint();
        laserDirection = setupLaser.GetLaserDirection();

        LockTarget();
    }

    void LockTarget() {
        // default values for target
        target = null;
        laserEndPoint = laserDirection * 1000;

        RaycastHit hit;
        if (Physics.Raycast(laserStartPoint, laserDirection, out hit)) {
            target = hit.transform.gameObject;
            laserEndPoint = hit.point;
        }
    }

    void LaunchLaser() {
        launcherMethod.Launch(laserStartPoint, laserEndPoint, this);
    }

    public void NotifyTarget() {
        if (target == null) return;

        ILaserReceiver laserReceiver = target.GetComponent<ILaserReceiver>();
        if (laserReceiver != null) {
            laserReceiver.ReceiveLaser(laserEndPoint, laserDirection);
        }
    }
}
