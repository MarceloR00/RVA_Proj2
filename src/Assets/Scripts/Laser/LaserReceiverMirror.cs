using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserReceiverMirror : MonoBehaviour, ILaserReceiver
{
    SetupLaserMirror setupLaser;
    LaserManager laserManager;

    void Start() {
        GameObject laser = transform.Find("Laser").gameObject;

        setupLaser = laser.GetComponent<SetupLaserMirror>();
        laserManager = laser.GetComponent<LaserManager>();
    }

    public void ReceiveLaser(Vector3 hitPoint, Vector3 incomingLaserDirection) {
        setupLaser.SetLaserStartPoint(hitPoint);

        Vector3 outgoingLaserDirection = GetOutgoingLaserDirection(incomingLaserDirection);
        setupLaser.SetLaserDirection(outgoingLaserDirection);

        laserManager.SetupAndLaunchLaser();
    }

    Vector3 GetOutgoingLaserDirection(Vector3 incomingLaserDirection) {
        Vector3 perpendicular = transform.right;

        float angle = Vector3.Angle(incomingLaserDirection, perpendicular);

        Vector3 outgoingLaserDirection = Quaternion.AngleAxis(-angle, perpendicular) * perpendicular;

        return outgoingLaserDirection;
    }
}
