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

        Vector3 outgoingLaserDirection = GetOutgoingLaserDirection(hitPoint, incomingLaserDirection);
        setupLaser.SetLaserDirection(outgoingLaserDirection);

        laserManager.SetupAndLaunchLaser();
    }

    Vector3 GetOutgoingLaserDirection(Vector3 hitPoint, Vector3 incomingLaserDirection) {
        Transform centerPoint = transform.Find("Center");
        Transform perpendicularPoint = transform.Find("Perpendicular");

        if (centerPoint == null || perpendicularPoint == null) return Vector3.positiveInfinity;

        Vector3 perpendicular = (perpendicularPoint.position - centerPoint.position).normalized;
        incomingLaserDirection = new Vector3(-incomingLaserDirection.x, -incomingLaserDirection.y, -incomingLaserDirection.z);

        float angle = Vector3.SignedAngle(incomingLaserDirection, perpendicular, Vector3.up);
        Vector3 outgoingLaserDirection = Vector3.positiveInfinity;
        if (Mathf.Abs(angle) > 90) {
            perpendicular = new Vector3(-perpendicular.x, -perpendicular.y, -perpendicular.z);
            angle = Vector3.SignedAngle(incomingLaserDirection, perpendicular, Vector3.up);
        }

        outgoingLaserDirection = Quaternion.AngleAxis(angle, Vector3.up) * perpendicular;
        float newAngle = Vector3.SignedAngle(outgoingLaserDirection, perpendicular, Vector3.up);

        return outgoingLaserDirection;
    }
}
